using System;
using System.Collections.Generic;
using System.Linq;
using CoolNameGenerator.Helper;
using CoolNameGenerator.Properties;

namespace CoolNameGenerator.GA.Terminations
{
    /// <summary>
    /// A base class for logical operator terminations.
    /// </summary>
    public abstract class LogicalOperatorTerminationBase : ITermination
    {
        #region Fields
        private readonly int _mMinOperands;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="LogicalOperatorTerminationBase"/> class.
        /// </summary>
        /// <param name="minOperands">The minimum number of operands.</param>
        protected LogicalOperatorTerminationBase(int minOperands)
        {
            _mMinOperands = minOperands;
            Terminations = new List<ITermination>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicalOperatorTerminationBase"/> class.
        /// </summary>
        /// <param name="terminations">The terminations.</param>
        protected LogicalOperatorTerminationBase(params ITermination[] terminations)
            : this(2)
        {
            if (terminations != null)
            {
                foreach (var t in terminations)
                {
                    AddTermination(t);
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the terminations.
        /// </summary>
        protected IList<ITermination> Terminations { get; private set; }
        #endregion

        #region Properties
        /// <summary>
        /// Adds the termination.
        /// </summary>
        /// <param name="termination">The termination.</param>
        public void AddTermination(ITermination termination)
        {
            if (termination == null) throw new ArgumentNullException(nameof(termination));

            Terminations.Add(termination);
        }

        /// <summary>
        /// Determines whether the specified geneticAlgorithm reached the termination condition.
        /// </summary>
        /// <param name="geneticAlgorithm">The genetic algorithm.</param>
        /// <returns>
        /// True if termination has been reached, otherwise false.
        /// </returns>
        public bool HasReached(IGeneticAlgorithm geneticAlgorithm)
        {
            if (geneticAlgorithm == null) throw new ArgumentNullException(nameof(geneticAlgorithm));

            if (Terminations.Count < _mMinOperands)
            {
                throw new InvalidOperationException("The {0} needs at least {1} terminations to perform. Please, add the missing terminations.".With(GetType().Name, _mMinOperands));
            }

            return PerformHasReached(geneticAlgorithm);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="LogicalOperatorTerminationBase"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="LogicalOperatorTerminationBase"/>.</returns>
        public override string ToString()
        {
            return "{0} ({1})".With(GetType().Name, string.Join(", ", Terminations.Select(t => t.ToString()).ToArray()));
        }

        /// <summary>
        /// Determines whether the specified geneticAlgorithm reached the termination condition.
        /// </summary>
        /// <param name="geneticAlgorithm">The genetic algorithm.</param>
        /// <returns>
        /// True if termination has been reached, otherwise false.
        /// </returns>
        protected abstract bool PerformHasReached(IGeneticAlgorithm geneticAlgorithm);
        #endregion
    }
}