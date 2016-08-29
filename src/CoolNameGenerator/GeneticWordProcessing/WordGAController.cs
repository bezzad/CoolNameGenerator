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
            var fitness = new WordFitness();

            fitness.EvaluateFunc = word =>
            {
                var scores = new Dictionary<string, int>
                {
                    ["lengthEvaluationScore"] = fitness.EvaluateLength(word.Length)
                };

                return scores.Sum(s => s.Value).EvaluateScoreByIntVal();
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
