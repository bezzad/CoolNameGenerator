using System.ComponentModel;

namespace CoolNameGenerator.GA.Terminations
{
    /// <summary>
    ///     Fitness Stagnation Termination.
    ///     <remarks>
    ///         The genetic algorithm will be terminate when the best chromosome's fitness has no change in the last
    ///         generations specified.
    ///     </remarks>
    /// </summary>
    [DisplayName("Fitness Stagnation")]
    public class FitnessStagnationTermination : TerminationBase
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the expected stagnant generations number to reach the termination.
        /// </summary>
        public int ExpectedStagnantGenerationsNumber { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Determines whether the specified geneticAlgorithm reached the termination condition.
        /// </summary>
        /// <returns>True if termination has been reached, otherwise false.</returns>
        /// <param name="geneticAlgorithm">The genetic algorithm.</param>
        protected override bool PerformHasReached(IGeneticAlgorithm geneticAlgorithm)
        {
            var bestFitness = geneticAlgorithm.BestChromosome.Fitness.Value;

            if (_mLastFitness == bestFitness)
            {
                _mStagnantGenerationsCount++;
            }
            else
            {
                _mStagnantGenerationsCount = 1;
            }

            _mLastFitness = bestFitness;

            return _mStagnantGenerationsCount >= ExpectedStagnantGenerationsNumber;
        }

        #endregion

        #region Fields

        private double _mLastFitness;
        private int _mStagnantGenerationsCount;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FitnessStagnationTermination" /> class.
        /// </summary>
        /// <remarks>
        ///     The ExpectedStagnantGenerationsNumber default value is 100.
        /// </remarks>
        public FitnessStagnationTermination() : this(100)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FitnessStagnationTermination" /> class.
        /// </summary>
        /// <param name="expectedStagnantGenerationsNumber">The expected stagnant generations number to reach the termination.</param>
        public FitnessStagnationTermination(int expectedStagnantGenerationsNumber)
        {
            ExpectedStagnantGenerationsNumber = expectedStagnantGenerationsNumber;
        }

        #endregion
    }
}