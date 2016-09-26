using System;
using System.Collections.Generic;
using System.Linq;
using CoolNameGenerator.Helper;

namespace CoolNameGenerator.GeneticWordProcessing
{
    public class UniqueWords : HashSet<string>, IEquatable<UniqueWords>
    {
        public static double CheckWordsCoveragePercentageFor(string subWord)
        {
            if (SubWordsCoverage.ContainsKey(subWord))
            {
                return ApplySubWordsCoverageValueFunc?.Invoke(SubWordsCoverage[subWord]) ?? SubWordsCoverage[subWord];
            }

            return 0;
        }

        public static void ServeWordsCoverage(IEnumerable<UniqueWords> words)
        {
            SubWordsCoverage = new Dictionary<string, double>();

            foreach (var uw in words)
            {
                foreach (var wordCoverage in uw.GetUniqueSubWordsCoverage(uw.IncludeMiddleSubWords))
                {
                    if (SubWordsCoverage.ContainsKey(wordCoverage.Key))
                    {
                        SubWordsCoverage[wordCoverage.Key] += wordCoverage.Value*uw.MatchingFitness;
                    }
                    else
                    {
                        SubWordsCoverage[wordCoverage.Key] = wordCoverage.Value*uw.MatchingFitness;
                    }
                }
            }
        }

        #region Properties

        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the fitness value for assign to a word when it find at this list.
        /// </summary>
        /// <value>
        ///     The matching fitness.
        /// </value>
        public double MatchingFitness { get; set; } = 1;

        /// <summary>
        ///     Gets or sets the fitness value for assign to a word when it NOT find at this list.
        /// </summary>
        /// <value>
        ///     The no matching any word fitness.
        /// </value>
        public double NoMatchingFitness { get; set; }

        /// <summary>
        ///     Gets or sets the fitness value for assign to a word when it find again at this list.
        /// </summary>
        /// <value>
        ///     The duplicate matching fitness.
        /// </value>
        public double DuplicateMatchingFitness { get; set; }

        /// <summary>
        ///     Weather include middle sub words of words or not?
        /// </summary>
        public bool IncludeMiddleSubWords { get; set; }

        public static Func<double, double> ApplySubWordsCoverageValueFunc { get; set; }

        public string this[int index] => this.ElementAt(index);

        /// <summary>
        ///     Sum of the all sub words by unique overall coverage
        /// </summary>
        public static Dictionary<string, double> SubWordsCoverage { get; set; }

        #endregion

        #region Constructors

        public UniqueWords(string name)
        {
            Name = name;
        }

        public UniqueWords(string name, IEnumerable<string> words) : this(name, words, false)
        {
        }

        public UniqueWords(string name, IEnumerable<string> words, bool includeMiddleSubWords) : base(words)
        {
            Name = name;
            IncludeMiddleSubWords = includeMiddleSubWords;
        }

        #endregion

        #region Methods

        public bool Equals(UniqueWords other)
        {
            if (other == null) return false;

            return other.Name == Name
                   && other.MatchingFitness == MatchingFitness
                   && other.NoMatchingFitness == NoMatchingFitness;
        }

        public override bool Equals(object obj)
        {
            var words = obj as UniqueWords;
            return words != null && words.Equals(this);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ MatchingFitness.GetHashCode();
                hashCode = (hashCode*397) ^ NoMatchingFitness.GetHashCode();
                hashCode = (hashCode*397) ^ DuplicateMatchingFitness.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(UniqueWords first, UniqueWords second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (((object) first == null) || ((object) second == null))
            {
                return false;
            }

            return first.Equals(second);
        }

        public static bool operator !=(UniqueWords first, UniqueWords second)
        {
            return !(first == second);
        }

        #endregion
    }
}