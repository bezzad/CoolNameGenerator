using System;
using System.Collections.Generic;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Fitnesses;
using CoolNameGenerator.Helper;

namespace CoolNameGenerator.GeneticWordProcessing
{

    /// <summary>
    /// Word chromosome fitness.
    /// </summary>
    /// <seealso cref="CoolNameGenerator.GA.Fitnesses.IFitness" />
    public class WordFitness : IFitness
    {
        /// <summary>
        /// Gets or sets the evaluate function.
        /// </summary>
        /// <value>The evaluate function.</value>
        public Func<string, double> EvaluateFunc { get; set; }

        /// <summary>
        /// Evaluates the specified chromosome.
        /// </summary>
        /// <param name="chromosome">The chromosome.</param>
        /// <returns>The chromosome fitness.</returns>
        public double Evaluate(IChromosome chromosome)
        {
            return EvaluateFunc(chromosome.ToString());
        }

        /// <summary>
        /// Evaluates the length of word.
        /// </summary>
        /// <param name="len">The word length.</param>
        /// <returns>Score between -10 ~ 10</returns>
        public virtual int EvaluateLength(int len)
        {
            if (len == 6 || len == 7) return 10;
            if (len == 5 || len == 8) return 9;
            if (len == 9) return 8;
            if (len == 10) return 7;
            if (len == 4 || len == 11 || len == 12) return 3;
            if (len == 3 || len == 13) return 1;
            if (len == 2 || (len > 13 && len < 20)) return 0;

            return -1 * Math.Abs(len - 19);
        }

        /// <summary>
        /// Evaluates the matching english character words.
        /// </summary>
        /// <param name="word">The chromosome word.</param>
        /// <returns>Score of matching word.</returns>
        public virtual int EvaluateMatchingEnglishCharWords(string word, IEnumerable<string> englishWords,
            IEnumerable<string> englishNames, IEnumerable<string> finglishWords, IEnumerable<string> finglishNames)
        {
            var score = 0;

            var subWords = word.GetSubWords();

            foreach (var subWord in subWords)
            {
                for (int i = 0; i < subWord.Length; i++)
                {
                    if (subWord[i] == 'a') score+=2;
                    if (subWord[i] == 'b') score--;
                }
            }

            return score;
        }
    }
}
