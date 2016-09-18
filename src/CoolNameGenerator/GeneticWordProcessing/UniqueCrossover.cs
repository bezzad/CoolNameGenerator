using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Crossovers;
using CoolNameGenerator.GA.Populations;
using CoolNameGenerator.GA.Randomizations;

namespace CoolNameGenerator.GeneticWordProcessing
{
    /// <summary>
    /// The Uniform Crossover uses a fixed mixing ratio between two parents. 
    /// Unlike one-point and two-point crossover, the Uniform Crossover enables the parent chromosomes to contribute the gene level rather than the segment level.
    /// <remarks>
    /// If the mix probability is 0.5, the offspring has approximately half of the genes from first parent and the other half from second parent, although cross over points can be randomly chosen.
    /// </remarks>
    /// <see href="http://en.wikipedia.org/wiki/Crossover_(genetic_algorithm)#Uniform_Crossover_and_Half_Uniform_Crossover">Wikipedia</see>
    /// </summary>
    [DisplayName("Unique")]
    public class UniqueCrossover : UniformCrossover
    {
        private Population _population;

        public UniqueCrossover(Population pop)
        {
            _population = pop;
        }

        #region Methods
        /// <summary>
        /// Performs the cross with specified parents generating the children.
        /// </summary>
        /// <param name="parents">The parents chromosomes.</param>
        /// <returns>The offspring (children) of the parents.</returns>
        protected override IList<IChromosome> PerformCross(IList<IChromosome> parents)
        {
            IList<IChromosome> result;

            bool find;
            do
            {
                result = base.PerformCross(parents);

                if ((ChromosomeBase)result[0] == (ChromosomeBase)result[1]) { find = true; continue; }

                find = _population.CurrentGeneration.Chromosomes.Any(ch => result.Any(child => (ChromosomeBase)child == (ChromosomeBase)ch));

            } while (find);

            return result;
        }
        #endregion
    }
}
