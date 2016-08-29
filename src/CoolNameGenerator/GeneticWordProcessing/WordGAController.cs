using System;
using System.Collections.Generic;
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
        public Func<IChromosome> ChromosomeFactory;
        public Action<IList<IChromosome>> DrawAllAction;
        public Action<IChromosome> DrawAction;

        public WordGaController(Func<IChromosome>  chromosomeFactory, Action<IList<IChromosome>> drawAllAction)
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
        }

        public override IChromosome CreateChromosome()
        {
            return ChromosomeFactory();
        }

        public override IFitness CreateFitness()
        {
            var f = new WordFitness
            {
                EvaluateFunc = (text) =>
                {
                    switch (text.Length)
                    {
                        case 2:
                            return 0.1;
                        case 3:
                            return 0.15;
                        case 4:
                            return 0.2;
                        case 5:
                            return 0.25;
                        case 6:
                            return 0.3;
                        case 7:
                            return 0.25;
                        case 8:
                            return 0.2;
                        case 9:
                            return 0.15;
                        case 10:
                            return 0.1;
                        case 11:
                            return 0.05;
                        case 12:
                            return 0.025;
                        default:
                            return 0;
                    }
                }
            };

            return f;
        }

        public override void Draw(IChromosome bestChromosome)
        {
            DrawAction?.Invoke(bestChromosome);
        }

        public void DrawAll(IList<IChromosome> chromosomes)
        {
            DrawAllAction?.Invoke(chromosomes);
        }

        public override ITermination CreateTermination()
        {
            return new OrTermination(new TimeEvolvingTermination(TimeSpan.FromHours(1)), new FitnessThresholdTermination(0.9));
        }

        //public override ICrossover CreateCrossover()
        //{
        //    return new OrderedCrossover();
        //}
        //public override IMutation CreateMutation()
        //{
        //    return new ReverseSequenceMutation();
        //}
        //public override ISelection CreateSelection()
        //{
        //    return new EliteSelection();
        //}
    }
}
