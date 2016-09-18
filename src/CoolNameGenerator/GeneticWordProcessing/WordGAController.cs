using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoolNameGenerator.GA;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Crossovers;
using CoolNameGenerator.GA.Fitnesses;
using CoolNameGenerator.GA.Mutations;
using CoolNameGenerator.GA.Populations;
using CoolNameGenerator.GA.Selections;
using CoolNameGenerator.GA.Terminations;
using CoolNameGenerator.Helper;
using CoolNameGenerator.Helper.Threading;

namespace CoolNameGenerator.GeneticWordProcessing
{
    public class WordGaController : GeneticControllerBase
    {
        public static volatile List<UniqueWords> WordsDic = new List<UniqueWords>();

        public Func<IChromosome> ChromosomeFactory;
        public Action<IList<IChromosome>> DrawAllAction;
        public Action<IChromosome> DrawAction;

        public WordGaController(Func<IChromosome> chromosomeFactory, Action<IList<IChromosome>> drawAllAction)
        {
            ChromosomeFactory = chromosomeFactory;
            DrawAllAction = drawAllAction;
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

            ga.MutationProbability = 0.7f;
            ga.CrossoverProbability = 0.7f;
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
                var scores = new List<int>()
                {
                    fitness.EvaluateLength(word.Length),
                    (int)fitness.EvaluateMatchingEnglishWords(word, WordsDic.ToArray()),
                    fitness.EvaluateDuplicatChar(word)
                };

                return scores.Sum().EvaluateScoreByIntVal();
            };

            return fitness;
        }

        public override void Draw(IChromosome bestChromosome)
        {
            DrawAction?.Invoke(bestChromosome);
        }

        public void DrawAll(IList<IChromosome> chromosomes)
        {
            DrawAllAction?.Invoke(chromosomes);
        }

        public async Task LoadWordFiles()
        {
            //WordsDic.Add(new UniqueWords("EnglishWords", await FileExtensions.ReadWordFileAsync("EnglishWords"), false, Math.Log)
            //{
            //    DuplicateMatchingFitness = -4,
            //    MatchingFitness = 5,
            //    UnMatchingFitness = -3
            //});

            //WordsDic.Add(new UniqueWords("EnglishNames", await FileExtensions.ReadWordFileAsync("EnglishNames"), false, Math.Log)
            //{
            //    DuplicateMatchingFitness = -4,
            //    MatchingFitness = 4,
            //    UnMatchingFitness = -1
            //});

            //WordsDic.Add(new UniqueWords("FinglishWords", await FileExtensions.ReadWordFileAsync("FinglishWords"), false, Math.Log)
            //{
            //    DuplicateMatchingFitness = -5,
            //    MatchingFitness = 4,
            //    UnMatchingFitness = -1
            //});


            //WordsDic.Add(new UniqueWords("FinglishNames", await FileExtensions.ReadWordFileAsync("FinglishNames"), false, Math.Log)
            //{
            //    DuplicateMatchingFitness = -2,
            //    MatchingFitness = 6,
            //    UnMatchingFitness = -4
            //});

            WordsDic.Add(new UniqueWords("FinglishNames", await FileExtensions.ReadWordFileAsync("FinglishNames"), false)
            {
                DuplicateMatchingFitness = -2,
                MatchingFitness = 6,
                UnMatchingFitness = -4
            });
        }

        public override ITermination CreateTermination()
        {
            //return new OrTermination(new TimeEvolvingTermination(TimeSpan.FromHours(2)), new FitnessThresholdTermination(0.99999995));
            return new TimeEvolvingTermination(TimeSpan.FromHours(2));
        }
        public override ICrossover CreateCrossover()
        {
            //return new UniqueCrossover();
            return new UniformCrossover(0.5f);
            //return new TwoPointCrossover();
            //return new ThreeParentCrossover();
            //return new OnePointCrossover();
        }

        public ICrossover CreateCrossover(Population pop)
        {
            //return new UniqueCrossover(pop);
            return new UniformCrossover(0.5f);
            //return new TwoPointCrossover();
            //return new ThreeParentCrossover();
            //return new OnePointCrossover();
        }

        public override IMutation CreateMutation()
        {
             return new UniformMutation(true);

            //return new ReverseSequenceMutation();
        }



        public ICrossover[] CreateCrossovers()
        {
            return new ICrossover[]
            {
                new UniformCrossover(),
                new TwoPointCrossover(),
                new ThreeParentCrossover(),
                new OnePointCrossover()
            };
        }
        public IMutation[] CreateMutations()
        {
            return new IMutation[]
            {
                new UniformMutation(),
                new ReverseSequenceMutation()
            };
        }

        public override ISelection CreateSelection()
        {
            //return new RouletteWheelSelection();
            //return new StochasticUniversalSamplingSelection();
            // new TournamentSelection();
            return new EliteSelection(30);
        }
    }
}