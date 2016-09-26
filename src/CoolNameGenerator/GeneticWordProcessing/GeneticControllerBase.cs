using CoolNameGenerator.GA;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Crossovers;
using CoolNameGenerator.GA.Fitnesses;
using CoolNameGenerator.GA.Mutations;
using CoolNameGenerator.GA.Selections;
using CoolNameGenerator.GA.Terminations;

namespace CoolNameGenerator.GeneticWordProcessing
{
    public abstract class GeneticControllerBase : IGeneticAlgoritmController
    {
        /// <summary>
        ///     Gets the Genetic Algorithm.
        /// </summary>
        /// <value>The Genetic Algorithm.</value>
        protected GeneticAlgorithm GA { get; private set; }

        /// <summary>
        ///     Creates the chromosome.
        /// </summary>
        /// <returns>
        ///     The chromosome.
        /// </returns>
        public abstract IChromosome CreateChromosome();

        /// <summary>
        ///     Creates the fitness.
        /// </summary>
        /// <returns>
        ///     The fitness.
        /// </returns>
        public abstract IFitness CreateFitness();

        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        ///     Configure the Genetic Algorithm.
        /// </summary>
        /// <param name="ga">The genetic algorithm.</param>
        public virtual void ConfigGa(GeneticAlgorithm ga)
        {
            GA = ga;
        }

        /// <summary>
        ///     Draws the sample.
        /// </summary>
        /// <param name="bestChromosome">The current best chromosome</param>
        public abstract void Draw(IChromosome bestChromosome);

        /// <summary>
        ///     Creates the termination.
        /// </summary>
        /// <returns>
        ///     The termination.
        /// </returns>
        public virtual ITermination CreateTermination()
        {
            return new FitnessStagnationTermination(100);
        }

        /// <summary>
        ///     Creates the crossover.
        /// </summary>
        /// <returns>The crossover.</returns>
        public virtual ICrossover CreateCrossover()
        {
            return new UniformCrossover();
        }

        /// <summary>
        ///     Creates the mutation.
        /// </summary>
        /// <returns>The mutation.</returns>
        public virtual IMutation CreateMutation()
        {
            return new UniformMutation(true);
        }

        /// <summary>
        ///     Creates the selection.
        /// </summary>
        /// <returns>The selection.</returns>
        public virtual ISelection CreateSelection()
        {
            return new EliteSelection();
        }
    }
}