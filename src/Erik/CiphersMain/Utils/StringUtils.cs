using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CiphersMain.Utils
{
    public static class StringUtils
    {
        public static readonly char[] ALPHABET = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
        public const int ALPHABET_LENGTH = 26;
        public static IEnumerable<string> SplitIntoChunks(this string toSplit, int length, char paddingChar = ' ', int offset = 1)
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
        /// Displays an IEnumerable of as best as it can.
        /// May be slow.
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
        public static string CipherFormat(string s) => Regex.Replace(s, "[^a-zA-Z0-9]*", "").ToUpper();
        public static string CipherFormatKeepWhitespace(string s) => Regex.Replace(s, "[^a-zA-Z0-9\\w]*", "").ToUpper();

        public static int GetLetterIndex(char c)
        {
            int index = (int)c;
            if (index > 64 && c < 90)
                index -= 65;
            else if (index > 94)
                index -= 95;
            return index;
        }
        public static char GetCharFromIndex(int i)
        {
            return (char)(i + 65);
        }
    }
}
