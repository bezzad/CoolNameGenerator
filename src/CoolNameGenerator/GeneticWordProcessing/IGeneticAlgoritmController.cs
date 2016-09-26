using CoolNameGenerator.GA;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Crossovers;
using CoolNameGenerator.GA.Fitnesses;
using CoolNameGenerator.GA.Mutations;
using CoolNameGenerator.GA.Selections;
using CoolNameGenerator.GA.Terminations;

namespace CoolNameGenerator.GeneticWordProcessing
{
    public interface IGeneticAlgoritmController
    {
        /// <summary>
        ///     Creates the fitness.
        /// </summary>
        /// <returns>The fitness.</returns>
        IFitness CreateFitness();

        /// <summary>
        ///     Creates the chromosome.
        /// </summary>
        /// <returns>The chromosome.</returns>
        IChromosome CreateChromosome();

        /// <summary>
        ///     Creates the termination.
        /// </summary>
        /// <returns>The termination.</returns>
        ITermination CreateTermination();

        /// <summary>
        ///     Creates the crossover.
        /// </summary>
        /// <returns>The crossover.</returns>
        ICrossover CreateCrossover();

        /// <summary>
        ///     Creates the mutation.
        /// </summary>
        /// <returns>The mutation.</returns>
        IMutation CreateMutation();

        /// <summary>
        ///     Creates the selection.
        /// </summary>
        /// <returns>The selection.</returns>
        ISelection CreateSelection();

        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        void Initialize();

        /// <summary>
        ///     Configure the Genetic Algorithm.
        /// </summary>
        /// <param name="ga">The genetic algorithm.</param>
        void ConfigGa(GeneticAlgorithm ga);

        /// <summary>
        ///     Draws the sample.
        /// </summary>
        /// <param name="bestChromosome">The current best chromosome</param>
        void Draw(IChromosome bestChromosome);
    }
}