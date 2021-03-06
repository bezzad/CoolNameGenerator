using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Populations;

namespace CoolNameGenerator.GA.Selections
{
    /// <summary>
    ///     Selects the chromosomes with the best fitness.
    /// </summary>
    /// <remarks>
    ///     Also know as: Truncation Selection.
    /// </remarks>
    [DisplayName("Elite")]
    public sealed class EliteSelection : SelectionBase
    {
        #region ISelection implementation

        /// <summary>
        ///     Performs the selection of chromosomes from the generation specified.
        /// </summary>
        /// <param name="number">The number of chromosomes to select.</param>
        /// <param name="generation">The generation where the selection will be made.</param>
        /// <returns>The select chromosomes.</returns>
        protected override IList<IChromosome> PerformSelectChromosomes(int number, Generation generation)
        {
            var ordered = generation.Chromosomes.OrderByDescending(c => c.Fitness);
            return ordered.Take(number).ToList();
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="EliteSelection" /> class.
        /// </summary>
        public EliteSelection() : this(2)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EliteSelection" /> class.
        /// </summary>
        public EliteSelection(int minNumberChromosomes) : base(minNumberChromosomes)
        {
        }

        #endregion
    }
}