using System;
using System.Collections.Generic;
using System.Linq;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Fitnesses;
using CoolNameGenerator.Helper;
using Enumerable = System.Linq.Enumerable;

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
        /// <param name="englishWords">English words library.</param>
        /// <param name="englishNames">English names library.</param>
        /// <param name="finglishWords">Persian words library converted to english characters (Finglish).</param>
        /// <param name="finglishNames">Persian names library converted to english characters (Finglish).</param>
        /// <returns>Score of matching word.</returns>
        public virtual int EvaluateMatchingEnglishCharWords(string word, HashSet<string> englishWords,
            HashSet<string> englishNames, HashSet<string> finglishWords, HashSet<string> finglishNames)
        {
            var score = 0;
            var countOfNatrualWords = 0;
            var matchWords = new HashSet<string>();

            var subWords = word.GetSubWords();

            foreach (var subWord in subWords)
            {
                if (englishWords.Contains(subWord))
                {
                    if (matchWords.Add(subWord)) score += 3;
                    else score -= 1; // duplicate natural word
                    countOfNatrualWords++;
                }
                if (englishNames.Contains(subWord))
                {
                    if (matchWords.Add(subWord)) score += 2;
                    else score -= 1; // duplicate natural word
                    countOfNatrualWords++;
                }
                if (finglishWords.Contains(subWord))
                {
                    if (matchWords.Add(subWord)) score += 1;
                    else score -= 1; // duplicate natural word
                    countOfNatrualWords++;
                }
                if (finglishNames.Contains(subWord))
                {
                    if (matchWords.Add(subWord)) score += 4;
                    else score -= 1; // duplicate natural word
                    countOfNatrualWords++;
                }
            }
            //
            // Check overlapping natural words
            //
            if (countOfNatrualWords > 1)
            {
                var overlapCont = word.CountOverlap(matchWords);
                if (overlapCont == 0) score += 2;
                else if (overlapCont == 1 && countOfNatrualWords == 2) score++;
                else score--;
            }
            //
            // Check Matching Natural Words Count Score
            //
            if (countOfNatrualWords < 3) score += countOfNatrualWords / 2; // good word
            else if (countOfNatrualWords == 3) score = 0; // not good or bad word
            else if (countOfNatrualWords > 3) score = (countOfNatrualWords - 3) * -1; // bad word

            return score;
        }

        public virtual int EvaluateDuplicatChar(string word)
        {
            var score = 0;

            var previewPairCharDuplicated = false;

            for (var i = 0; i < word.Length - 1; i++)
            {
                if (word[i] == word[i + 1])
                {
                    score -= previewPairCharDuplicated ? 2 : 1;
                    previewPairCharDuplicated = true;
                }
                else
                {
                    previewPairCharDuplicated = false;
                }
            }

            if (!previewPairCharDuplicated && score >= 0) score++;

            return score;
        }
    }
}
