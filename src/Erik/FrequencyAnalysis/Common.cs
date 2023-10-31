using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FrequencyAnalysis
{
    public static class Common
    {
        public static IEnumerable<string> SplitStringIntoChunks(string toSplit, int length, char paddingChar = ' ', int offset = 1)
        {
            string paddedString = toSplit + new string(paddingChar, length - toSplit.Length % length);
            for (int i = 0; i < paddedString.Length-length-offset; i+= offset)
            {
                yield return toSplit.Substring(i, length);
            }
        }

        public static string FormatString(string s) => Regex.Replace(s, "[^a-zA-Z0-9]*", "").ToUpper();
    }
}
