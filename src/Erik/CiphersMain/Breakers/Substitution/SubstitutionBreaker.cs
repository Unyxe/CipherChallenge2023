using CiphersMain.Keys;
using CiphersMain.Utils;
using FrequencyAnalysis;
using FrequencyAnalysis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Substitution
{
    public class SubstitutionBreaker
    {
        /// <summary>
        /// Creates a <see cref="CharacterKey"/> based on frequency analysis.
        /// </summary>
        /// <param name="text">The text to analyse.</param>
        /// <param name="knownChars">The known character map.</param>
        /// <returns></returns>
        public CharacterKey CreateGoodKey(string text, IDictionary<char, char> knownChars) => CreateGoodKey(FrequencyAnalyser.AnalyseText(text), knownChars);
        /// <summary>
        /// Creates a <see cref="CharacterKey"/> based on frequency analysis.
        /// </summary>
        /// <param name="text">The text to analyse.</param>
        /// <returns></returns>
        public CharacterKey CreateGoodKey(string text) => CreateGoodKey(FrequencyAnalyser.AnalyseText(text), new Dictionary<char, char>());
        /// <summary>
        /// Creates a <see cref="CharacterKey"/> based on frequency analysis.
        /// </summary>
        /// <param name="result">The frequency analysis table.</param>
        /// <param name="knownChars">The known character map.</param>
        /// <returns></returns>
        public CharacterKey CreateGoodKey(IFrequencyAnalysisResult result, IDictionary<char,char> knownChars)
        {
            CharacterKey key = new CharacterKey();
            foreach (char c in StringUtils.ALPHABET)
            {
                if (knownChars.ContainsKey(c))
                {
                    key.SetForward(c, knownChars[c]);
                    continue;
                }
                else
                {
                    char bestMatchChar = '\0';
                    double minDifference = 2;
                    double diff;
                    foreach (char c2 in StringUtils.ALPHABET)
                    {
                        string charS = c2.ToString();
                        diff = Math.Abs((DataTables.Instance.MonogramAnalysis[charS] - result[charS])/ DataTables.Instance.MonogramAnalysis[charS]);
                        if (diff < minDifference && !knownChars.ContainsKey(c2) && !key.ContainsValue(c2))
                        {
                            minDifference = diff;
                            bestMatchChar = c2;
                        }
                    }
                    key[c] = bestMatchChar;
                }
            }
            return key;
        }
        public string Break(string text, CharacterKey knownKey)
        {
            var key = CreateGoodKey(text, knownKey);
            return "";
        }
    }
}
