﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoolNameGenerator.GA;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Crossovers;
using CoolNameGenerator.GA.Fitnesses;
using CoolNameGenerator.GA.Mutations;
using CoolNameGenerator.GA.Selections;
using CoolNameGenerator.GA.Terminations;
using CoolNameGenerator.Helper;
using CoolNameGenerator.Helper.Threading;

namespace CoolNameGenerator.GeneticWordProcessing
{
    public class WordGaController : GeneticControllerBase
    {
        public static volatile List<UniqueWords> WordsDic = new List<UniqueWords>();

        /// <summary>
        /// Gets or sets the mutation probability.
        /// </summary>
        public float MutationProbability { get; set; } = 0.7f;

        /// <summary>
        /// Gets or sets the crossover probability.
        /// </summary>
        public float CrossoverProbability { get; set; } = 0.7f;

        /// <summary>
        /// Minimum number chromosomes support to be selected.
        /// </summary>
        public int EliteSelectionNumber { get; set; } = 30;

        /// <summary>
        /// The number of generations to keep in the population
        /// </summary>
        public int GenerationsNumber { get; set; } = 10;

        public Func<IChromosome> ChromosomeFactory { get; set; }
        public Action<IChromosome> DrawAction { get; set; }

        public WordGaController(Func<IChromosome> chromosomeFactory)
        {
            ChromosomeFactory = chromosomeFactory;
        }
        public WordGaController()
        {
            ChromosomeFactory = () => new WordChromosome();
        }

        public override void ConfigGa(GeneticAlgorithm ga)
        {
            base.ConfigGa(ga);
            ga.TaskExecutor = new SmartThreadPoolTaskExecutor()
            {
                MinThreads = 25,
                MaxThreads = 50
            };

            ga.MutationProbability = MutationProbability;
            ga.CrossoverProbability = CrossoverProbability;
        }

        public override IChromosome CreateChromosome()
        {
            return ChromosomeFactory();
        }
        public override IFitness CreateFitness()
        {
            var fitness = new WordFitness();

            fitness.EvaluateFunc = word =>
            {
                word.EvaluateInfo.Reset();

                var scores = new List<int>()
                {
                    fitness.EvaluateLength(word.Length),
                    (int)fitness.EvaluateMatchingEnglishWords(word, WordsDic.ToArray()),
                    fitness.EvaluateDuplicatChar(word.ToString())
                };

                return scores.Sum().EvaluateScoreByIntVal();
            };

            return fitness;
        }
        public override void Draw(IChromosome bestChromosome)
        {
            DrawAction?.Invoke(bestChromosome);
        }

        public async Task LoadWordFiles()
        {
            UniqueWords.ApplySubWordsCoverageValueFunc = Math.Log;

            WordsDic.Add(new UniqueWords("EnglishWords", await FileExtensions.ReadWordFileAsync("EnglishWords"), false)
            {
                DuplicateMatchingFitness = -4,
                MatchingFitness = 6,
                UnMatchingFitness = -1
            });

            WordsDic.Add(new UniqueWords("EnglishNames", await FileExtensions.ReadWordFileAsync("EnglishNames"), false)
            {
                DuplicateMatchingFitness = -20,
                MatchingFitness = 4,
                UnMatchingFitness = 0
            });

            WordsDic.Add(new UniqueWords("FinglishWords", await FileExtensions.ReadWordFileAsync("FinglishWords"), false)
            {
                DuplicateMatchingFitness = -10,
                MatchingFitness = 4,
                UnMatchingFitness = 0
            });


            WordsDic.Add(new UniqueWords("FinglishNames", await FileExtensions.ReadWordFileAsync("FinglishNames"), false)
            {
                DuplicateMatchingFitness = -4,
                MatchingFitness = 10,
                UnMatchingFitness = -2
            });
        }

        public override ITermination CreateTermination()
        {
            return new OrTermination(new TimeEvolvingTermination(TimeSpan.FromHours(2)), new FitnessThresholdTermination(0.99999995));
        }
        public override ICrossover CreateCrossover()
        {
            return new UniformCrossover();
        }
        public override IMutation CreateMutation()
        {
            return new UniformMutation(true);
        }
        public override ISelection CreateSelection()
        {
            return new EliteSelection(EliteSelectionNumber);
        }
    }
}