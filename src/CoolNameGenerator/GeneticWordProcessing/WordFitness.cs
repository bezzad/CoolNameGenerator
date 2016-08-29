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

        /// <summary>
        /// Evaluates the length of word.
        /// </summary>
        /// <param name="len">The word length.</param>
        /// <returns>Score between -10 ~ 10</returns>
        public virtual int EvaluateLength(int len)
        {
            if (len == 6 || len == 7) return 10;
            if (len == 5 || len == 8) return 9;
            if (len == 9) return 8;
            if (len == 10) return 7;
            if (len == 4 || len == 11 || len == 12) return 3;
            if (len == 3 || len == 13) return 1;
            if (len == 2 || (len > 13 && len < 20)) return 0;

            return -1 * Math.Abs(len - 19);
        }

        
    }
}
