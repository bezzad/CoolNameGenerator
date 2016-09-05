using System;
using System.Collections.Generic;
using System.Linq;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Fitnesses;
using CoolNameGenerator.Helper;
using CoolNameGenerator.Properties;
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
            if (len < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(len),
                    Localization.The_argument_must_be_have_more_than_2_length);
            }
            //          +0                  +10                  +20
            // Length:   0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9  0 1 2 3 ...
            //           - - - - - - - - - - - - - - - - - - - -  - - - - ...
            // Fitness:  × × 0 1 3 9 _10 9 8 7 3 3 1 0 0 0 0 0 0 -1-2-3-4 ...  
            //
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
        public virtual int EvaluateMatchingEnglishWords(
            string word,
            HashSet<string> englishWords,
            HashSet<string> englishNames,
            HashSet<string> finglishWords,
            HashSet<string> finglishNames)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            if (word.Length < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(word), Localization.The_argument_must_be_have_more_than_2_length);
            }

            var score = 0;
            var countOfNatrualWords = 0;
            var englishMatchingWords = new HashSet<string>();
            var finglishMatchingWords = new HashSet<string>();

            var subWords = word.GetSubWords();

            foreach (var subWord in subWords)
            {
                if (englishWords?.Contains(subWord) == true)
                {
                    if (englishMatchingWords.Add(subWord))
                    {
                        score += 3;
                        if (finglishMatchingWords.Contains(subWord)) score += 4;
                    }
                    else score -= 1; // duplicate natural word
                    countOfNatrualWords++;
                }
                if (englishNames?.Contains(subWord) == true)
                {
                    if (englishMatchingWords.Add(subWord))
                    {
                        score += 2;
                        if (finglishMatchingWords.Contains(subWord)) score += 4;
                    }
                    else score -= 1; // duplicate natural word
                    countOfNatrualWords++;
                }
                if (finglishWords?.Contains(subWord) == true)
                {
                    if (finglishMatchingWords.Add(subWord))
                    {
                        score += 1;
                        if (englishMatchingWords.Contains(subWord)) score += 4;
                    }
                    else score -= 1; // duplicate natural word
                    countOfNatrualWords++;
                }
                if (finglishNames?.Contains(subWord) == true)
                {
                    if (finglishMatchingWords.Add(subWord))
                    {
                        score += 4;
                        if (englishMatchingWords.Contains(subWord)) score += 4;
                    }
                    else score -= 1; // duplicate natural word
                    countOfNatrualWords++;
                }
            }
            //
            // Check overlapping natural words
            //
            if (countOfNatrualWords > 1)
            {
                var overlapCount = word.CountOverlap(englishMatchingWords.Concat(finglishMatchingWords));
                if (overlapCount == 0) score += 2;
                else if (overlapCount == 1 && countOfNatrualWords == 2) score++;
                else score--;
            }
            else if (countOfNatrualWords == 1) score++;
            //
            // Check Matching Natural Words Count Score
            //
            if (countOfNatrualWords < 3) score += countOfNatrualWords / 2; // good word
            else if (countOfNatrualWords == 3) score = 0; // not good or bad word
            else if (countOfNatrualWords > 3) score = (countOfNatrualWords - 3) * -1; // bad word

            return score;

            //return word.Contains("book")
            //    ? 10
            //    : word.Contains("boo") ? 5 : word.Contains("bo") ? 2 : word.Contains("b") ? 0 : -10;

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
