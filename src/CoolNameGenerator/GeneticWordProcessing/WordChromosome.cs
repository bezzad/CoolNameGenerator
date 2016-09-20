using System.Collections.Generic;
using System.Linq;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Randomizations;
using CoolNameGenerator.Helper;

namespace CoolNameGenerator.GeneticWordProcessing
{
    public class WordChromosome : ChromosomeBase
    {
        #region Properties     
         
        public const int MaxCharactersLong = 67;
        public const int MaxHyphenUsage = 4;
        public bool HasNumeric { get; set; }
        public bool HasHyphen { get; set; }

        public WordChromosomeInfo EvaluateInfo { get; set; }

        #endregion

        #region Constructors  

        public WordChromosome(int length, bool hasNumeric, bool hasHyphen) : base(length)
        {
            HasNumeric = hasNumeric;
            HasHyphen = hasHyphen;
            EvaluateInfo = new WordChromosomeInfo();
            ReplaceGenes(0, GenerateGens(Length, hasNumeric, hasHyphen));
        }

        public WordChromosome(bool hasNumeric, bool hasHyphen) : this(FastRandom.Next(3, 8), hasNumeric, hasHyphen)
        { }

        public WordChromosome() : this(FastRandom.Next(3, 8), false, false)
        { }

        #endregion

        #region Methods    

        /// <summary>
        /// Generates the gene.
        /// </summary>
        /// <param name="geneIndex">Index of the gene.</param>
        /// <returns>The new Gene.</returns>
        public override Gene GenerateGene(int geneIndex)
        {
            return GenerateGens(1, HasNumeric, HasHyphen)[0];
        }

        /// <summary>
        /// Generates the gens.
        /// </summary>
        /// <param name="wordLength">Length of the word.</param>
        /// <param name="hasNumeric">if set to <c>true</c> [has numeric].</param>
        /// <param name="hasHyphen">if set to <c>true</c> [has hyphen].</param>
        /// <returns></returns>
        public Gene[] GenerateGens(int wordLength, bool hasNumeric, bool hasHyphen)
        {
            var resourceChars = hasNumeric && hasHyphen ? Words.EnglishNumericLettersByHyphen
                : hasNumeric ? Words.EnglishNumericLetters
                    : hasHyphen ? Words.EnglishLettersByHyphen
                        : Words.EnglishLetters;

            var genes = new List<Gene>();
            for (var index = 0; index < wordLength; index++)
            {
                // First and Last char of word must be has not hyphen or number
                if (index == 0 || index == wordLength - 1)
                {
                    genes.Add(new Gene(Words.EnglishLetters[FastRandom.Next(0, Words.EnglishLetters.Length - 1)]));
                }
                else
                {
                    genes.Add(new Gene(resourceChars[FastRandom.Next(0, resourceChars.Length - 1)]));
                }
            }

            return genes.ToArray();
        }

        /// <summary>
        /// Creates a new chromosome using the same structure of this.
        /// </summary>
        /// <returns>
        /// The new chromosome.
        /// </returns>
        public override IChromosome CreateNew()
        {
            return new WordChromosome(Length, HasNumeric, HasHyphen);
        }

        public override string ToString()
        {
            return string.Join("", GetGenes().Select(g => g.Value.ToString()).ToArray());
        }

        public static WordChromosome Factory(string word)
        {
            var wch = new WordChromosome(word.Length, word.Any(char.IsDigit), word.Contains(Words.HyphenChar));
            wch.ReplaceGenes(0, word.Select(ch => new Gene(ch)).ToArray());

            return wch;
        }

        #endregion
    }
}