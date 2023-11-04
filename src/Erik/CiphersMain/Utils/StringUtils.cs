using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CiphersMain.Utils
{
    /// <summary>
    /// Generic static utility functions for strings.
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// The alphabet in caps, from A-Z.
        /// </summary>
        public static readonly char[] ALPHABET = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
        /// <summary>
        /// The length of the English alphabet.
        /// </summary>
        public const int ALPHABET_LENGTH = 26;
        /// <summary>
        /// Splits a string into chunks of <paramref name="length"/> characters.
        /// </summary>
        /// <param name="toSplit">The string to split.</param>
        /// <param name="length">The length of one chunk.</param>
        /// <param name="paddingChar">The char used to pad the final chunk.</param>
        /// <param name="offset">How much to offset each chunk from the last.</param>
        /// <returns>The split string</returns>
        public static IEnumerable<string> DivideIntoChunks(this string toSplit, int length, char paddingChar = ' ', int offset = 1)
        {
            string paddedString = toSplit + new string(paddingChar, length - toSplit.Length % length);
            for (int i = 0; i < paddedString.Length - length - offset; i += offset)
            {
                var substring = toSplit.Substring(i, length);
                if (Regex.IsMatch(substring, @"[^a-zA-Z0-9]*"))
                    yield return substring;
            }
        }
        /// <summary>
        /// Displays an <see cref="IEnumerable{T}"/> as best as it can.
        /// Can be slow.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The IEnumerable to output.</param>
        public static void WriteEnumerable<T>(IEnumerable<T> enumerable, string separator = ", ")
        {
            foreach (var item in enumerable)
            {
#pragma warning disable CS8600, CS8604, CS8605, CS8614, CS8618
                switch (typeof(T))
                {
                    case var t when t is IEnumerable<object>:
                        Console.Write($"{string.Join(", ", (IEnumerable<object>)item)}{separator}");
                        break;
                    case var t when t is KeyValuePair<object, object>:
                        KeyValuePair<object, object> pair = (KeyValuePair<object, object>)(object)item;
                        Console.Write($"{pair.Key}, {pair.Value}{separator}");
                        break;
                    default:
                        Console.Write($"{item}{separator}");
                        break;
                }
#pragma warning restore CS8600, CS8604, CS8605, CS8614, CS8618 // 'is' expression's given expression is never of the provided type
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Format plaintext into text the ciphers are programmed to work with.
        /// Removes all non-letter characters and makes everything uppercase.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string CipherFormat(string s) => Regex.Replace(s, "[^a-zA-Z]*", "").ToUpper();
        /// <summary>
        /// Format plaintext into text the ciphers are programmed to work with.
        /// Removes all non-letter characters except whitespace and makes everything uppercase.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string CipherFormatKeepWhitespace(string s) => Regex.Replace(s, "[^a-zA-Z\\w]*", "").ToUpper();
        /// <summary>
        /// Gets the index of a letter. A is 0.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int GetLetterIndex(char c)
        {
            int index = (int)c;
            if (index > 64 && c < 90)
                index -= 65;
            else if (index > 94)
                index -= 95;
            return index;
        }
        /// <summary>
        /// Gets a character given its index in the alphabet. 0 is A.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static char GetCharFromIndex(int i)
        {
            return (char)(i + 65);
        }
    }
}
