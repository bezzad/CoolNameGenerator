using System;
using System.Collections.Generic;
using System.Linq;
using CoolNameGenerator.GA.Randomizations;

namespace CoolNameGenerator.GA.Chromosomes
{
    public class ChromosomeWord : ChromosomeBase
    {
        public const int MaxCharactersLong = 67;
        public const int MaxHyphenUsage = 4;
        public const char HyphenChar = '-';

        public static readonly char[] NotIgnoreChars = { ' ', ',', '|', '~', '!', '@', '#', '$', '%', '^', '&',
            '*', '(', ')', '-', '=', '+', '_', '/', '\\', '\r', '\n', '\b', '\t', '[', ']', '{', '}', '?', '>', '<', '.' };

        public static char[] EnglishLetters { get; } = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public static char[] NumericLetters { get; } = "0123456789".ToCharArray();
        public static char[] EnglishNumericLetters { get; } = EnglishLetters.Concat(NumericLetters).ToArray();
        public static char[] EnglishLettersByHyphen { get; } = EnglishLetters.Concat(new[] { HyphenChar }).ToArray();
        public static char[] EnglishNumericLettersByHyphen { get; } = EnglishLetters.Concat(NumericLetters).Concat(new[] { HyphenChar }).ToArray();



        public ChromosomeWord(int length, bool hasNumeric, bool hasHyphen) : base(length)
        {
            ReplaceGenes(0, GenerateGens(length, hasNumeric, hasHyphen));
        }

        public ChromosomeWord(bool hasNumeric, bool hasHyphen) : this(FastRandom.Next(3, 8), hasNumeric, hasHyphen)
        { }

        public ChromosomeWord() : this(FastRandom.Next(3, 8), false, false)
        { }

        public override Gene GenerateGene(int geneIndex)
        {
            return new Gene(EnglishLetters[FastRandom.Next(0, EnglishLetters.Length - 1)]);
        }

        public Gene GenerateGene(bool hasNumeric, bool hasHyphen)
        {
            return GenerateGens(1, hasNumeric, hasHyphen)[0];
        }

        public Gene[] GenerateGens(int wordLength, bool hasNumeric, bool hasHyphen)
        {
            var resourceChars = hasNumeric && hasHyphen ? EnglishNumericLettersByHyphen
                : hasNumeric ? EnglishNumericLetters
                    : hasHyphen ? EnglishLettersByHyphen
                        : EnglishLetters;

            var genes = new List<Gene>();
            for (var index = 0; index < wordLength; index++)
            {
                // First and Last char of word must be has not hyphen or number
                if (index == 0 || index == wordLength - 1)
                {
                    genes.Add(new Gene(EnglishLetters[FastRandom.Next(0, EnglishLetters.Length - 1)]));
                }
                else
                {
                    genes.Add(new Gene(resourceChars[FastRandom.Next(0, resourceChars.Length - 1)]));
                }
            }

            return genes.ToArray();
        }

        public override IChromosome CreateNew()
        {
            return new ChromosomeWord();
        }
    }
}
