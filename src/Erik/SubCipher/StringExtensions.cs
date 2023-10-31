using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SubCipher
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Returns the index of a letter in the alphabet given an ASCII character.
        /// Non-ascii characters may produce unexpected results.
        /// Note that A is 0.
        /// </summary>
        /// <param name="c">The character who's index we want.</param>
        /// <returns></returns>
        public static int AlphabetIndex(this char c) => char.IsUpper(c) ? c - 65 : c - 97;
        public static string RemoveNonLetterChars(this string s) => Regex.Replace(s, @"[^A-Za-z0-9]", "");
    }
}
