using System;
using System.Collections.Generic;
using System.Linq;
using CoolNameGenerator.GA.Randomizations;
using CoolNameGenerator.Helper;

namespace CoolNameGenerator.GA.Chromosomes
{
    public class ChromosomeWord : ChromosomeBase
    {
        public const int MaxCharactersLong = 67;
        public const int MaxHyphenUsage = 4;


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
            return new Gene(Words.EnglishLetters[FastRandom.Next(0, Words.EnglishLetters.Length - 1)]);
        }

        public Gene GenerateGene(bool hasNumeric, bool hasHyphen)
        {
            return GenerateGens(1, hasNumeric, hasHyphen)[0];
        }

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

        public override IChromosome CreateNew()
        {
            return new ChromosomeWord();
        }
    }
}
