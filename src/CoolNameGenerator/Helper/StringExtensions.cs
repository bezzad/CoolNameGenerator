using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CoolNameGenerator.GA.Chromosomes;

namespace CoolNameGenerator.Helper
{
    /// <summary>String extensions.</summary>
    public static class StringExtensions
    {
        private static readonly Regex SInsertUnderscoreBeforeUppercase = new Regex("(?<!_|^)([A-Z])", RegexOptions.Compiled);
        private static readonly Regex SCapitalizeRegex = new Regex("((\\s|^)\\S)(\\S+)", RegexOptions.Compiled);

        /// <summary>Gets the word in the specified index.</summary>
        /// <returns>The word from index.</returns>
        /// <param name="source">The source string.</param>
        /// <param name="index">The index.</param>
        public static string GetWordFromIndex(this string source, int index)
        {
            int wordStartIndex;
            return source.GetWordFromIndex(index, out wordStartIndex);
        }

        /// <summary>Gets the word in the specified index.</summary>
        /// <returns>The word from index.</returns>
        /// <param name="source">The source string.</param>
        /// <param name="index">The index.</param>
        /// <param name="wordStartIndex">Word start index.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", Justification = "It's necessary for the method purpose.", MessageId = "2#")]
        public static string GetWordFromIndex(this string source, int index, out int wordStartIndex)
        {
            string[] strArray = source.Split(' ');
            int length = strArray.Length;
            int num1 = -1;
            for (int index1 = 0; index1 < length; ++index1)
            {
                string str = strArray[index1];
                int num2 = num1 + str.Length;
                if (num2 >= index)
                {
                    wordStartIndex = num2 - (str.Length - 1);
                    return str;
                }
                num1 = num2 + 1;
                if (num1 == index)
                {
                    wordStartIndex = num1;
                    return " ";
                }
            }
            wordStartIndex = 0;
            return source;
        }

        /// <summary>Counts the words.</summary>
        /// <returns>The words.</returns>
        /// <param name="source">The source string.</param>
        public static int CountWords(this string source)
        {
            return source.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>Removes the accents.</summary>
        /// <returns>The accents.</returns>
        /// <param name="source">The source string.</param>
        public static string RemoveAccents(this string source)
        {
            string str = source.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < str.Length; ++index)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(str[index]) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(str[index]);
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>Removes the non alphanumeric chars.</summary>
        /// <returns>The non alphanumeric.</returns>
        /// <param name="source">The source string.</param>
        public static string RemoveNonAlphanumeric(this string source)
        {
            return Regex.Replace(source, "[^0-9A-Za-záàãâäéèêëíìîïóòõôöúùûüñ]*", string.Empty);
        }

        /// <summary>Removes the non numeric chars.</summary>
        /// <returns>The non numeric.</returns>
        /// <param name="source">The source string.</param>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Ok.", MessageId = "NonNumeric")]
        public static string RemoveNonNumeric(this string source)
        {
            return Regex.Replace(source, "[^0-9]*", string.Empty);
        }

        /// <summary>Removes the specified string from borders.</summary>
        /// <returns>The from borders.</returns>
        /// <param name="source">The source string.</param>
        /// <param name="remove">The string to remove.</param>
        public static string RemoveFromBorders(this string source, string remove)
        {
            remove = Regex.Escape(remove);
            return Regex.Replace(source, string.Format((IFormatProvider)CultureInfo.InvariantCulture, "(^{0}|{1}$)", new object[2]
            {
        (object) remove,
        (object) remove
            }), string.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>Removes the chars "remove" from source borders.</summary>
        /// <returns>The from borders.</returns>
        /// <param name="source">The source string.</param>
        /// <param name="remove">The chars to remove.</param>
        public static string RemoveFromBorders(this string source, params char[] remove)
        {
            string str = Regex.Escape(new string(remove));
            return Regex.Replace(source, string.Format((IFormatProvider)CultureInfo.InvariantCulture, "(^[{0}]|[{1}]$)", new object[2]
            {
        (object) str,
        (object) str
            }), string.Empty);
        }

        /// <summary>Removes the punctuations.</summary>
        /// <returns>The clean string.</returns>
        /// <param name="source">The source string.</param>
        public static string RemovePunctuations(this string source)
        {
            return Regex.Replace(source, "[!\\(\\)\\[\\]{}\\:;\\.,?'\"]*", string.Empty);
        }

        /// <summary>Escapes the accents to hexadecimal equivalent.</summary>
        /// <returns>The accents to hex.</returns>
        /// <param name="source">The source string.</param>
        public static string EscapeAccentsToHex(this string source)
        {
            StringBuilder stringBuilder = new StringBuilder(source.Length);
            int length = source.Length;
            for (int index = 0; index < length; ++index)
            {
                if (source[index].HasAccent())
                    stringBuilder.Append(Uri.HexEscape(source[index]));
                else
                    stringBuilder.Append(source[index]);
            }
            return stringBuilder.ToString();
        }

        /// <summary>Escapes the accents to html entities.</summary>
        /// <returns>The accents to html entities.</returns>
        /// <param name="source">The source string.</param>
        public static string EscapeAccentsToHtmlEntities(this string source)
        {
            int length = source.Length;
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < length; ++index)
            {
                char ch = source[index];
                if ((int)ch >= 160 && (int)ch < 256)
                    stringBuilder.AppendFormat("&#{0};", (object)((int)ch).ToString((IFormatProvider)NumberFormatInfo.InvariantInfo));
                else
                    stringBuilder.Append(ch);
            }
            return stringBuilder.ToString();
        }

        /// <summary>Verify if source ends the with punctuation.</summary>
        /// <returns><c>true</c>, if with punctuation was the end, <c>false</c> otherwise.</returns>
        /// <param name="source">The source string.</param>
        public static bool EndsWithPunctuation(this string source)
        {
            return Regex.IsMatch(source, "[!\\(\\)\\[\\]{}\\:;\\.,?'String.Empty]$");
        }

        /// <summary>Determines if has accent.</summary>
        /// <returns><c>true</c> if has accent the specified source; otherwise, <c>false</c>.</returns>
        /// <param name="source">The source string.</param>
        public static bool HasAccent(this string source)
        {
            int length = source.Length;
            for (int index = 0; index < length; ++index)
            {
                if (source[index].HasAccent())
                    return true;
            }
            return false;
        }

        /// <summary>Inserts the underscore before every upper case char.</summary>
        /// <returns>The result string.</returns>
        /// <param name="input">The source string.</param>
        public static string InsertUnderscoreBeforeUppercase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            return StringExtensions.SInsertUnderscoreBeforeUppercase.Replace(input, "_$1");
        }

        /// <summary>
        /// Format the specified string. Is a String.Format(CultureInfo.InvariantCulture,..) shortcut.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>The formatted string.</returns>
        public static string With(this string source, params object[] args)
        {
            return string.Format((IFormatProvider)CultureInfo.InvariantCulture, source, args);
        }

        /// <summary>Capitalize the string.</summary>
        /// <param name="source">The source string.</param>
        /// <param name="ignoreWordsLowerThanChars">The words lower than specified chars will be ignored.</param>
        /// <returns>The capitalized string.</returns>
        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public static string Capitalize(this string source, int ignoreWordsLowerThanChars = 3)
        {
            return StringExtensions.SCapitalizeRegex.Replace(source.ToLowerInvariant(), (MatchEvaluator)(m =>
            {
                if (m.Value.Trim().Length < ignoreWordsLowerThanChars)
                    return m.Value;
                return m.Groups[1].Value.ToUpperInvariant() + m.Groups[3].Value;
            }));
        }

        /// <summary>
        ///  Returns a value indicating whether the specified substring occurs within this string
        ///  <remarks>
        ///  Based on http://stackoverflow.com/a/444818/956886.
        /// </remarks>
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>True se if substring occurs, otherwise false.</returns>
        public static bool ContainsIgnoreCase(this string source, string substring)
        {
            return source.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static Dictionary<string, string> GetPairUniqueWords(this IEnumerable<string> source)
        {
            var res = source.SelectMany(x => new string(x.Where(w => w != '\t' && w != ' ').ToArray())
                .Split(Words.NotIgnoreChars.Concat(Words.NumericLetters)
                    .ToArray())).Where(word => word.Length > 1).Distinct();

            var pairWords = res.Select(x => new
            {
                persian = x.Contains(':') ? x.Substring(x.IndexOf(':') + 1) : x,
                finglish = x.Contains(':') ? x.Substring(0, x.IndexOf(':')) : null
            });

            var uniqueWords = pairWords.Distinct((a, b) => a.persian == b.persian, c => c.persian.GetHashCode()).ToDictionary(p => p.persian, p => p.finglish);

            return uniqueWords;
        }

        public static HashSet<string> GetUniqueWords(this IEnumerable<string> source)
        {
            var res = source.SelectMany(x => new string(x.Where(w => w != '\t' && w != ' ').ToArray())
                .Split(Words.NotIgnoreChars.Concat(Words.NumericLetters)
                    .ToArray())).Where(word => word.Length > 1).Distinct();

            var pairWords = res.Select(x => x.Contains(':') ? x.Substring(0, x.IndexOf(':')) : x);

            var uniqueWords = new HashSet<string>(pairWords.Distinct());

            return uniqueWords;
        }

        /// <summary>
        /// Gets the sub words.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>Sub words.</returns>
        public static IList<string> GetSubWords(this string word)
        {
            // word:    a b c d
            //          0 1 2 3
            //
            // sub words:        
            //          a b , a b c , a b c d
            //          0 1   0 1 2   0 1 2 3   
            //
            //          b c , b c d
            //          1 2   1 2 3
            //
            //          c d
            //          2 3
            //
            var subWords = new List<string>();

            for (var i = 0; i < word.Length - 1; i++)
            {
                for (var j = 2; j <= word.Length - i; j++)
                {
                    subWords.Add(word.Substring(i, j));
                }
            }

            return subWords;
        }
    }
}