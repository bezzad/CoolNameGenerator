using System;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Fitnesses;

namespace CoolNameGenerator.GeneticWordProcessing
{

    /// <summary>
    /// Word chromosome fitness.
    /// </summary>
    /// <seealso cref="CoolNameGenerator.GA.Fitnesses.IFitness" />
    public class WordFitness : IFitness
    {
        /// <summary>
        /// Gets or sets the evaluate function.
        /// </summary>
        /// <value>The evaluate function.</value>
        public Func<string, double> EvaluateFunc { get; set; }

        /// <summary>
        /// Evaluates the specified chromosome.
        /// </summary>
        /// <param name="chromosome">The chromosome.</param>
        /// <returns>The chromosome fitness.</returns>
        public double Evaluate(IChromosome chromosome)
        {
            return EvaluateFunc(chromosome.ToString());
        }
    }
}
