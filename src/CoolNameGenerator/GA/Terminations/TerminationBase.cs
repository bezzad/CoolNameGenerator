using System;
using CoolNameGenerator.Helper;
using CoolNameGenerator.Properties;

namespace CoolNameGenerator.GA.Terminations
{
    /// <summary>
    /// Base class for ITerminations implementations.
    /// </summary>
    public abstract class TerminationBase : ITermination
    {
        #region Fields
        private bool _mHasReached;
        #endregion

        #region Methods
        /// <summary>
        /// Determines whether the specified geneticAlgorithm reached the termination condition.
        /// </summary>
        /// <returns>True if termination has been reached, otherwise false.</returns>
        /// <param name="geneticAlgorithm">The genetic algorithm.</param>
        public bool HasReached(IGeneticAlgorithm geneticAlgorithm)
        {
            if (geneticAlgorithm == null) throw new ArgumentNullException(nameof(geneticAlgorithm));

            _mHasReached = PerformHasReached(geneticAlgorithm);

            return _mHasReached;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="LogicalOperatorTerminationBase"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="LogicalOperatorTerminationBase"/>.</returns>
        public override string ToString()
        {
            return "{0} (HasReached: {1})".With(GetType().Name, _mHasReached);
        }

        /// <summary>
        /// Determines whether the specified geneticAlgorithm reached the termination condition.
        /// </summary>
        /// <returns>True if termination has been reached, otherwise false.</returns>
        /// <param name="geneticAlgorithm">The genetic algorithm.</param>
        protected abstract bool PerformHasReached(IGeneticAlgorithm geneticAlgorithm);
        #endregion
    }
}
