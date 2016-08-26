using System;

namespace CoolNameGenerator.GA.Chromosomes
{
    /// <summary>
    /// Represents a gene of a chromosome.
    /// </summary>
    public struct Gene : IEquatable<Gene>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CoolNameGenerator.GA.Chromosomes.Gene"/> struct.
        /// </summary>
        /// <param name="val">The gene initial value.</param>
        public Gene(object val)
        {
            Value = val;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public object Value { get; }

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
        public static bool operator ==(Gene first, Gene second)
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
        public static bool operator !=(Gene first, Gene second)
        {
            return !(first == second);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="CoolNameGenerator.GA.Chromosomes.Gene"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="CoolNameGenerator.GA.Chromosomes.Gene"/>.</returns>
        public override string ToString()
        {
            return Value?.ToString() ?? string.Empty;
        }

        /// <summary>
        /// Determines whether the specified <see cref="CoolNameGenerator.GA.Chromosomes.Gene"/> is equal to the current <see cref="CoolNameGenerator.GA.Chromosomes.Gene"/>.
        /// </summary>
        /// <param name="other">The <see cref="CoolNameGenerator.GA.Chromosomes.Gene"/> to compare with the current <see cref="CoolNameGenerator.GA.Chromosomes.Gene"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="CoolNameGenerator.GA.Chromosomes.Gene"/> is equal to the current
        /// <see cref="CoolNameGenerator.GA.Chromosomes.Gene"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(Gene other)
        {
            return Value.Equals(other.Value);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="CoolNameGenerator.GA.Chromosomes.Gene"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="CoolNameGenerator.GA.Chromosomes.Gene"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
        /// <see cref="CoolNameGenerator.GA.Chromosomes.Gene"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Gene)
            {
                var other = (Gene)obj;

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
            return Value?.GetHashCode() ?? 0;
        }

        #endregion
    }
}