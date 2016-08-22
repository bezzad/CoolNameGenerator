using System.Linq;

namespace CoolNameGenerator.Helper
{
    public static class WordHelper
    {
        public const int MaxCharactersLong = 67;
        public const int MaxHyphenUsage = 4;
        public const char HyphenChar = '-';

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

            var resourceLen = resourceChars.Length;

            var word = "";
            for (var index = 0; index < wordLength; index++)
            {
                word += resourceChars[RandomNumber.Next(0, resourceLen - 1)];
            }

            return word;
        }
    }
}
