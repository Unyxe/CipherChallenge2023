using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SubCipher
{
    internal class CipherKey : IEnumerable<int>
    {
        private int[] _internalKeys = new int[26];
        public HashSet<int> LockedLetters = new HashSet<int>();

        public int Count => _internalKeys.Length;

        public bool IsReadOnly => _internalKeys.IsReadOnly;
        int this[int index]
        {
            get => _internalKeys[index];
            set => _internalKeys[index] = value;
        }
        public CipherKey()
        {
            string key = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < key.Length; i++)
            {
                int index = key[i].AlphabetIndex();
                if (index >= 0 && index < 26)
                    LockedLetters.Add(index);
            }
        }
        /// <summary>
        /// Create a key from an array of known letters.
        /// </summary>
        /// <param name="knownLetters"></param>
        public CipherKey(int[] knownLetters)
        {
            for (int i = 0; i < knownLetters.Length; i++)
            {
                if (knownLetters[i] > 0 && knownLetters[i]<26)
                    LockedLetters.Add(knownLetters[i]);
            }
        }
        /// <summary>
        /// Create a key from a string of known characters
        /// </summary>
        /// <param name="key"></param>
        public CipherKey(string key)
        {
            for (int i = 0; i < key.Length; i++)
            {
                int index = key[i].AlphabetIndex();
                if (index >= 0 && index < 26)
                    LockedLetters.Add(index);
            }
        }

        /// <summary>
        /// Returns a new Key that only contains the locked letters from this key.
        /// </summary>
        /// <returns>A new CipherKey</returns>
        public CipherKey GetKeyFromLocked()
        {
            var newKey = new CipherKey();
            newKey.LockedLetters = LockedLetters;
            foreach (int i in LockedLetters)
            {
                newKey[i] = _internalKeys[i];
            }
            return newKey;
        }

        public override string ToString()
        {
            return string.Join("", _internalKeys.Select(x => Convert.ToChar(x+65)));
        }

        public static CipherKey CreateGoodKey(string cipherText, CipherKey partialKey)
        {
            FreqAnalysis analysisResult = new FreqAnalysis();
            analysisResult.PerformAnalysis(cipherText);
            CipherKey newKey = partialKey.GetKeyFromLocked();
            for (int i = 0; i < 26; i++)
            {
                if (newKey.LockedLetters.Contains(i))
                    continue;
                else
                {
                    int matchIndex = -1;
                    double minDiff = 2;
                    for (int j = 0; j < 26; j++)
                    {
                        double diff = Math.Abs(DataTables.SingleLetterFrequencies[j] - analysisResult.GetRelativeFrequency(i)); // Get the difference in character frequency from our text and the character we are looking at in the alphabet
                        // TODO randmise difference
                        if (diff < minDiff && !newKey.Contains(i))
                        {
                            minDiff = diff;
                            matchIndex = j;
                        }
                    }
                    newKey[i] = matchIndex;
                }
            }
            return newKey;
        }

        public IEnumerator<int> GetEnumerator() => _internalKeys.Cast<int>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _internalKeys.GetEnumerator();
    }
}
