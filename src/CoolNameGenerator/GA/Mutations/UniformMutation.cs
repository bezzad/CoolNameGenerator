using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Randomizations;
using CoolNameGenerator.Helper;

namespace CoolNameGenerator.GA.Mutations
{
    /// <summary>
    ///     This operator replaces the value of the chosen gene with a uniform random value selected
    ///     between the user-specified upper and lower bounds for that gene.
    ///     <see href="http://en.wikipedia.org/wiki/Mutation_(genetic_algorithm)">Wikipedia</see>
    /// </summary>
    [DisplayName("Uniform")]
    public class UniformMutation : MutationBase
    {
        #region Methods

        /// <summary>
        ///     Mutate the specified chromosome.
        /// </summary>
        /// <param name="chromosome">The chromosome.</param>
        /// <param name="probability">The probability to mutate each chromosome.</param>
        protected override void PerformMutate(IChromosome chromosome, float probability)
        {
            if (chromosome == null) throw new ArgumentNullException(nameof(chromosome));

            var genesLength = chromosome.Length;

            if (_mMutableGenesIndexes == null || _mMutableGenesIndexes.Length == 0)
            {
                _mMutableGenesIndexes = _mAllGenesMutable
                    ? Enumerable.Range(0, genesLength).ToArray()
                    : FastRandom.GetInts(1, 0, genesLength);
            }

            foreach (var i in _mMutableGenesIndexes)
            {
                if (i >= genesLength)
                {
                    throw new MutationException(this,
                        "The chromosome has no gene on index {0}. The chromosome genes length is {1}.".With(i,
                            genesLength));
                }

                if (FastRandom.Next() <= probability)
                {
                    chromosome.ReplaceGene(i, chromosome.GenerateGene(i));
                }
            }
        }

        #endregion

        #region Fields

        private int[] _mMutableGenesIndexes;

        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "mall")] private readonly bool _mAllGenesMutable;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="UniformMutation" /> class.
        /// </summary>
        /// <param name="mutableGenesIndexes">Mutable genes indexes.</param>
        public UniformMutation(params int[] mutableGenesIndexes)
        {
            _mMutableGenesIndexes = mutableGenesIndexes;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UniformMutation" /> class.
        /// </summary>
        /// <param name="allGenesMutable">If set to <c>true</c> all genes are mutable.</param>
        public UniformMutation(bool allGenesMutable)
        {
            _mAllGenesMutable = allGenesMutable;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UniformMutation" /> class.
        /// </summary>
        /// <remarks>Creates an instance of UniformMutation where some random genes will be mutated.</remarks>
        public UniformMutation() : this(true)
        {
        }

        #endregion
    }
}