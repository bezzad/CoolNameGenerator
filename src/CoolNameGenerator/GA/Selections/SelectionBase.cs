using System;
using System.Collections.Generic;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Populations;
using CoolNameGenerator.Helper;
using CoolNameGenerator.Properties;

namespace CoolNameGenerator.GA.Selections
{
    /// <summary>
    /// A base class for selection.
    /// </summary>
    public abstract class SelectionBase : ISelection
    {
        #region Fields
        private readonly int _mMinNumberChromosomes;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionBase"/> class.
        /// </summary>
        /// <param name="minNumberChromosomes">Minimum number chromosomes support to be selected.</param>
        protected SelectionBase(int minNumberChromosomes)
        {
            _mMinNumberChromosomes = minNumberChromosomes;
        }
        #endregion

        #region ISelection implementation
        /// <summary>
        /// Selects the number of chromosomes from the generation specified.
        /// </summary>
        /// <returns>The selected chromosomes.</returns>
        /// <param name="number">The number of chromosomes to select.</param>
        /// <param name="generation">The generation where the selection will be made.</param>
        public IList<IChromosome> SelectChromosomes(int number, Generation generation)
        {
            if (number < _mMinNumberChromosomes)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "The number of selected chromosomes should be at least {0}.".With(_mMinNumberChromosomes));
            }

            if (generation == null) throw new ArgumentNullException(nameof(generation));
            
            return PerformSelectChromosomes(number, generation);
        }

        /// <summary>
        /// Performs the selection of chromosomes from the generation specified.
        /// </summary>
        /// <returns>The selected chromosomes.</returns>
        /// <param name="number">The number of chromosomes to select.</param>
        /// <param name="generation">The generation where the selection will be made.</param>
        protected abstract IList<IChromosome> PerformSelectChromosomes(int number, Generation generation);
        #endregion
    }
}