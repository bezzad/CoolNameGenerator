using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Fitnesses;
using CoolNameGenerator.Helper;
using CoolNameGenerator.Properties;

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
        public Func<WordChromosome, double> EvaluateFunc { get; set; }

        /// <summary>
        /// Evaluates the specified chromosome.
        /// </summary>
        /// <param name="chromosome">The chromosome.</param>
        /// <returns>The chromosome fitness.</returns>
        public double Evaluate(IChromosome chromosome)
        {
            if (chromosome.GetType() != typeof(WordChromosome))
            {
                throw new ArgumentException("Argument must be type of 'WordChromosome'.", nameof(chromosome));
            }

            return EvaluateFunc(chromosome as WordChromosome);
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


        public virtual int EvaluateDuplicatChar(string word)
        {
            var score = 0;

            var previewPairCharDuplicated = false;

            for (var i = 0; i < word.Length - 1; i++)
            {
                if (word[i] == word[i + 1])
                {
                    score -= previewPairCharDuplicated ? 20 : 10;
                    previewPairCharDuplicated = true;
                }
                else
                {
                    previewPairCharDuplicated = false;
                }
            }

            if (!previewPairCharDuplicated && score >= 0) score += 5; // positive if not any serial duplicate char

            return score;
        }


        /// <summary>
        /// Evaluates the matching English character words.
        /// </summary>
        /// <param name="word">The chromosome word.</param>
        /// <param name="wordsLists">The list of words to matching by them.</param>
        /// <returns>Score of matching word.</returns>
        public virtual double EvaluateMatchingEnglishWords(WordChromosome word, params UniqueWords[] wordsLists)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            if (word.Length < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(word), Localization.The_argument_must_be_have_more_than_2_length);
            }

            if (!wordsLists.Any())
            {
                throw new EvaluateException("The matching words list is empty.");
            }

            double score = 0;
            var countOfNatrualWords = 0;
            var matchedWords = new Dictionary<string, HashSet<string>>(wordsLists.Length);
            foreach (var lstWords in wordsLists)
            {
                matchedWords[lstWords.Name] = new HashSet<string>();
            }

            var subWords = word.GetSubWords();
            double sumCoveragePercent = 0;
            for (var c = 0; c < subWords.Count; c++) // Get all sub words of the word
            {
                foreach (var lst in wordsLists) // read and matching by all words list
                {
                    if (lst?.Contains(subWords[c]) == true) // Is Matched Word!?
                    {
                        word.EvaluateInfo.MatchedUniqueWords.Add(Tuple.Create(subWords[c], lst.Name)); // add found sub word to chromosome info

                        if (matchedWords[lst.Name].Add(subWords[c])) // Able to add matched subWord (or Not if duplicate match)?
                        {
                            score += lst.MatchingFitness; // Add match fitness of this list
                        }
                        else score += lst.DuplicateMatchingFitness; // duplicate match word
                        countOfNatrualWords++; // increase match count
                    }
                    else // No Match Word!
                    {
                        score += lst?.UnMatchingFitness ?? 0; // increase or decrease no match fitness according by this list 
                    }
                }
                //
                // Check this sub word in all sub words of all words by coverage percentage for any matched sub word by sub word
                var coverageOfSubWord = UniqueWords.CheckWordsCoveragePercentageFor(subWords[c]);
                sumCoveragePercent += coverageOfSubWord;
                if (coverageOfSubWord > 0) word.EvaluateInfo.MatchedUniqueSubWords.Add(subWords[c]); // add found sub word to chromosome info
                //
                // decrease score if exist duplicate sub words in a word
                for (var i = c + 1; i < subWords.Count; i++)
                {
                    if (subWords[i] == subWords[c])
                        score -= 5;
                }
            }
            //
            // Check overlapping natural words
            //
            if (countOfNatrualWords > 1)
            {
                var overlapCount = word.CountOverlap(matchedWords.SelectMany(x => x.Value));
                if (overlapCount == 0) score += 3;
                else if (overlapCount == 1) score += 10;
                else if (countOfNatrualWords == 2) score += 7;
                else score -= overlapCount * 5;
            }
            else if (countOfNatrualWords == 1) score += 10;
            //
            // Check Matching Natural Words Count Score
            //
            if (countOfNatrualWords < 3) score += (double)countOfNatrualWords * 5 / 2; // good word
            else if (countOfNatrualWords == 3) score += 0; // not good or bad word
            else if (countOfNatrualWords > 3) score += (countOfNatrualWords - 3) * -5; // bad word

            return (score) + sumCoveragePercent;
        }
    }
}
