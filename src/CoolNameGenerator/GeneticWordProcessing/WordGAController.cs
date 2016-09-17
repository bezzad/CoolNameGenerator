using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        public static volatile UniqueWords EnglishWords;
        public static volatile UniqueWords EnglishNames;
        public static volatile UniqueWords FinglishWords;
        public static volatile UniqueWords FinglishNames;

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
                MinThreads = 30,
                MaxThreads = 50
            };
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
                    (int)fitness.EvaluateMatchingEnglishWords(word, EnglishWords, EnglishNames, FinglishWords, FinglishNames),
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
            EnglishWords = new UniqueWords("EnglishWords", await FileExtensions.ReadWordFileAsync("EnglishWords"))
            {
                DuplicateMatchingFitness = -2,
                MatchingFitness = 3,
                UnMatchingFitness = -2
            };

            EnglishNames = new UniqueWords("EnglishNames", await FileExtensions.ReadWordFileAsync("EnglishNames"))
            {
                DuplicateMatchingFitness = -2,
                MatchingFitness = 2,
                UnMatchingFitness = 0
            };

            FinglishWords = new UniqueWords("FinglishWords", await FileExtensions.ReadWordFileAsync("FinglishWords"))
            {
                DuplicateMatchingFitness = -3,
                FriendWordList = new List<UniqueWords>() { EnglishWords, EnglishNames },
                MatchingFitness = 2,
                MatchingFriendsFitness = 2,
                UnMatchingFitness = 0
            };


            FinglishNames = new UniqueWords("FinglishNames", await FileExtensions.ReadWordFileAsync("FinglishNames"))
            {
                DuplicateMatchingFitness = -2,
                FriendWordList = new List<UniqueWords>() { EnglishWords, EnglishNames, FinglishWords },
                MatchingFitness = 4,
                MatchingFriendsFitness = 4,
                UnMatchingFitness = -2
            };
        }

        public override ITermination CreateTermination()
        {
            //return new OrTermination(new TimeEvolvingTermination(TimeSpan.FromHours(2)), new FitnessThresholdTermination(0.99999995));
            return new TimeEvolvingTermination(TimeSpan.FromHours(2));
        }
        public override ICrossover CreateCrossover()
        {
            //return new UniformCrossover();
            return new TwoPointCrossover();
        }
        public override IMutation CreateMutation()
        {
            return new UniformMutation();
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
            return new EliteSelection(40);
        }
    }
}