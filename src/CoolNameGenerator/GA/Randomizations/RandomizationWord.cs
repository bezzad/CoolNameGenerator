using System.Linq;

namespace CoolNameGenerator.GA.Randomizations
{
    public static class RandomizationWord
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

        public static string GenerateWord(int wordLength, bool hasNumeric, bool hasHyphen)
        {
            var resourceChars = hasNumeric && hasHyphen ? EnglishNumericLettersByHyphen
                : hasNumeric ? EnglishNumericLetters
                    : hasHyphen ? EnglishLettersByHyphen
                        : EnglishLetters;

            var word = "";
            for (var index = 0; index < wordLength; index++)
            {
                // First and Last char of word must be has not hyphen or number
                if (index == 0 || index == wordLength - 1)
                {
                    word += EnglishLetters[FastRandom.Next(0, EnglishLetters.Length - 1)];
                }
                else
                {
                    word += resourceChars[FastRandom.Next(0, resourceChars.Length - 1)];
                }
            }

            return word;
        }
    }
}
