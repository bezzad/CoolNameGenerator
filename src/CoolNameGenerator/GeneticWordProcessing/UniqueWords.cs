using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CoolNameGenerator.Helper;

namespace CoolNameGenerator.GeneticWordProcessing
{
    public class UniqueWords : Dictionary<string, Dictionary<string, double>>, IEquatable<UniqueWords>
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

        /// <summary>
        /// Gets or sets the fitness value for assign to a word when it find again at this friend lists.
        /// </summary>
        /// <value>
        /// The matching friends fitness.
        /// </value>
        public int MatchingFriendsFitness { get; set; }

        /// <summary>
        /// Gets or sets the friend word list. If find the word in both of this and friend list then have positive score.
        /// </summary>
        /// <value>
        /// The friend word list.
        /// </value>
        public List<UniqueWords> FriendWordList { get; set; } = new List<UniqueWords>();

        public string this[int index] => this.ElementAt(index).Key;

        #endregion

        #region Constructors

        public UniqueWords(string name)
        {
            Name = name;
        }

        public UniqueWords(string name, IEnumerable<string> words) : base(words.GetWordsBySubWordsCoveragePercent())
        {
            Name = name;
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
                hashCode = (hashCode * 397) ^ (FriendWordList?.GetHashCode() ?? 0);
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
    }
}