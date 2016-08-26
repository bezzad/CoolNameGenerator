using System;

namespace CoolNameGenerator.PGA.Chromosomes
{
    /// <summary>
    /// Represents a gene of a chromosome.
    /// </summary>
    public struct Gene<T> : IEquatable<Gene<T>>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CoolNameGenerator.PGA.Chromosomes.Gene"/> struct.
        /// </summary>
        /// <param name="val">The gene initial value.</param>
        public Gene(T val)
        {
            Value = val;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public T Value { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Gene<T> first, Gene<T> second)
        {
            return first.Equals(second);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Gene<T> first, Gene<T> second)
        {
            return !(first == second);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="GeneticSharp.Domain.Chromosomes.Gene"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="GeneticSharp.Domain.Chromosomes.Gene"/>.</returns>
        public override string ToString()
        {
            return Value?.ToString() ?? string.Empty;
        }

        /// <summary>
        /// Determines whether the specified <see cref="CoolNameGenerator.PGA.Chromosomes.Gene"/> is equal to the current <see cref="CoolNameGenerator.PGA.Chromosomes.Gene"/>.
        /// </summary>
        /// <param name="other">The <see cref="CoolNameGenerator.PGA.Chromosomes.Gene"/> to compare with the current <see cref="CoolNameGenerator.PGA.Chromosomes.Gene"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="CoolNameGenerator.PGA.Chromosomes.Gene"/> is equal to the current
        /// <see cref="CoolNameGenerator.PGA.Chromosomes.Gene"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(Gene<T> other)
        {
            return Value.Equals(other.Value);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="GeneticSharp.Domain.Chromosomes.Gene"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="GeneticSharp.Domain.Chromosomes.Gene"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
        /// <see cref="GeneticSharp.Domain.Chromosomes.Gene"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Gene<T>)
            {
                var other = (Gene<T>)obj;

                return Value.Equals(other.Value);
            }

            return false;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Value == null ? 0 : Value.GetHashCode();
        }

        #endregion
    }
}