using System;
using System.Linq;

namespace CoolNameGenerator.Helper
{
    public static class Words
    {
        public const char HyphenChar = '-';

        public static char[] NotIgnoreChars { get; }  = { ' ', ',', '|', '~', '!', '@', '#', '$', '%', '^', '&',
            '*', '(', ')', '-', '=', '+', '_', '/', '\\', '\r', '\n', '\b', '\t', '[', ']', '{', '}', '?', '>', '<', '.' };

        public static char[] EnglishLetters { get; } = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public static char[] NumericLetters { get; } = "0123456789".ToCharArray();
        public static char[] EnglishNumericLetters { get; } = EnglishLetters.Concat(NumericLetters).ToArray();
        public static char[] EnglishLettersByHyphen { get; } = EnglishLetters.Concat(new[] {HyphenChar }).ToArray();
        public static char[] EnglishNumericLettersByHyphen { get; } = EnglishLetters.Concat(NumericLetters).Concat(new[] {HyphenChar }).ToArray();
    }
}