using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CoolNameGenerator.Helper;

namespace CoolNameGenerator.GeneticWordProcessing
{
    public class UniqueWords : HashSet<string>, IEquatable<UniqueWords>
    {
        #region Properties

        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the fitness value for assign to a word when it find at this list.
        /// </summary>
        /// <value>
        /// The matching fitness.
        /// </value>
        public int MatchingFitness { get; set; } = 1;

        /// <summary>
        /// Gets or sets the fitness value for assign to a word when it NOT find at this list.
        /// </summary>
        /// <value>
        /// The no matching any word fitness.
        /// </value>
        public int UnMatchingFitness { get; set; }

        /// <summary>
        /// Gets or sets the fitness value for assign to a word when it find again at this list.
        /// </summary>
        /// <value>
        /// The duplicate matching fitness.
        /// </value>
        public int DuplicateMatchingFitness { get; set; }

        public static Func<double, double> ApplySubWordsCoverageValueFunc { get; set; }

        public string this[int index] => this.ElementAt(index);

        /// <summary>
        /// Sum of the all sub words by unique overall coverage 
        /// </summary>
        public static Dictionary<string, double> SubWordsCoverage { get; set; } = new Dictionary<string, double>();

        #endregion

        #region Constructors

        public UniqueWords(string name)
        {
            Name = name;
        }

        public UniqueWords(string name, IEnumerable<string> words) : this(name, words, false)
        { }

        public UniqueWords(string name, IEnumerable<string> words, bool includeMiddleSubWords) : base(words)
        {
            Name = name;

            foreach (var wordCoverage in this.GetUniqueSubWordsCoverage(includeMiddleSubWords))
            {
                if (SubWordsCoverage.ContainsKey(wordCoverage.Key))
                {
                    SubWordsCoverage[wordCoverage.Key] += wordCoverage.Value;
                }
                else
                {
                    SubWordsCoverage[wordCoverage.Key] = wordCoverage.Value;
                }
            }
        }

        #endregion

        #region Methods


        public bool Equals(UniqueWords other)
        {
            if (other == null) return false;

            return other.Name == this.Name
                   && other.MatchingFitness == this.MatchingFitness
                   && other.UnMatchingFitness == this.UnMatchingFitness;
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
                hashCode = (hashCode * 397) ^ MatchingFitness;
                hashCode = (hashCode * 397) ^ UnMatchingFitness;
                return hashCode;
            }
        }

        public static bool operator ==(UniqueWords first, UniqueWords second)
        {
            if (object.ReferenceEquals(first, second))
            {
                return true;
            }

            if (((object)first == null) || ((object)second == null))
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

        public static double CheckWordsCoveragePercentageFor(string subWord)
        {
            if (SubWordsCoverage.ContainsKey(subWord))
            {
                return ApplySubWordsCoverageValueFunc?.Invoke(SubWordsCoverage[subWord]) ?? SubWordsCoverage[subWord];
            }

            return 0;
        }
    }
}