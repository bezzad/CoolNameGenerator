using System;
using System.Collections.Generic;
using System.Linq;
using CoolNameGenerator.GA;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Crossovers;
using CoolNameGenerator.GA.Fitnesses;
using CoolNameGenerator.GA.Mutations;
using CoolNameGenerator.GA.Selections;
using CoolNameGenerator.GA.Terminations;
using CoolNameGenerator.Helper.Threading;

namespace CoolNameGenerator.GeneticWordProcessing
{
    public class WordGaController : GeneticControllerBase
    {
        #region Properties

        public static volatile IList<UniqueWords> WordsDic;

        public Func<IChromosome> ChromosomeFactory { get; set; }

        public Action<IChromosome> DrawAction { get; set; }

        /// <summary>
        /// Gets or sets the crossover pointer.
        /// </summary>
        public ICrossover CrossoverPointer { get; set; }

        /// <summary>
        ///     Gets or sets the crossover probability.
        /// </summary>
        public float CrossoverProbability { get; set; } = 0.7f;

        /// <summary>
        /// Gets or sets the mutation pointer.
        /// </summary>
        public IMutation MutationPointer { get; set; }

        /// <summary>
        ///     Gets or sets the mutation probability.
        /// </summary>
        public float MutationProbability { get; set; } = 0.5f;

        /// <summary>
        /// Gets or sets the selection pointer.
        /// </summary>
        public ISelection SelectionPointer { get; set; }

        /// <summary>
        ///     Minimum number chromosomes support to be selected.
        /// </summary>
        public int EliteSelectionNumber { get; set; } = 30;

        /// <summary>
        /// Gets or sets the minimum size of the population.
        /// </summary>
        public int MinimumPopulationSize { get; set; }

        /// <summary>
        ///     The number of generations to keep in the population
        /// </summary>
        public int GenerationsNumber { get; set; } = 10;

        /// <summary>
        ///     Gets or sets the time evolving termination.
        /// </summary>
        public TimeSpan TimeEvolvingTermination { get; set; } = TimeSpan.FromHours(4);

        /// <summary>
        ///     Gets or sets the fitness threshold termination.
        /// </summary>
        /// <value>
        ///     The fitness threshold termination.
        /// </value>
        public double FitnessThresholdTermination { get; set; } = 0.99999995;

        /// <summary>
        ///     Gets or sets the minimum thread.
        /// </summary>
        public int MinimumThread { get; set; } = Environment.ProcessorCount;

        /// <summary>
        ///     Gets or sets the maximum thread.
        /// </summary>
        public int MaximumThread { get; set; } = 50;

        #endregion

        #region Constructors

        public WordGaController(Func<IChromosome> chromosomeFactory)
        {
            ChromosomeFactory = chromosomeFactory;
        }

        public WordGaController()
        {
            ChromosomeFactory = () => new WordChromosome();
        }

        #endregion

        #region Methods

        public override void ConfigGa(GeneticAlgorithm ga)
        {
            base.ConfigGa(ga);
            ga.TaskExecutor = new SmartThreadPoolTaskExecutor
            {
                MinThreads = MinimumThread,
                MaxThreads = MaximumThread
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

                var scores = new List<int>
                {
                    fitness.EvaluateLength(word.Length),
                    (int) fitness.EvaluateMatchingEnglishWords(word, WordsDic.ToArray()),
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

        public void LoadWordFiles(IList<UniqueWords> dics, Func<double, double> applyOnSubWordsSumCoverageablityValueFunc)
        {
            UniqueWords.ApplySubWordsCoverageValueFunc = applyOnSubWordsSumCoverageablityValueFunc ?? Math.Log;

            WordsDic = dics;
            UniqueWords.ServeWordsCoverage(WordsDic);
        }

        public override ITermination CreateTermination()
        {
            return new OrTermination(new TimeEvolvingTermination(TimeEvolvingTermination),
                new FitnessThresholdTermination(FitnessThresholdTermination));
        }

        public override ICrossover CreateCrossover()
        {
            return CrossoverPointer ?? new UniformCrossover();
        }

        public override IMutation CreateMutation()
        {
            return MutationPointer ?? new UniformMutation(true);
        }

        public override ISelection CreateSelection()
        {
            return SelectionPointer ?? new EliteSelection(EliteSelectionNumber);
        }

        #endregion

    }
}