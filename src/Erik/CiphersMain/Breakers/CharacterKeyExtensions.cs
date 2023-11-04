using CiphersMain.Keys;
using CiphersMain.Utils;
using FrequencyAnalysis;
using FrequencyAnalysis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers
{
    public static class CharacterKeyExtensions
    {
        public static void MutateKey(this CharacterKey key, int iterations) => MutateKey(key, CharacterKey.Empty, iterations);
        public static void MutateKey(this CharacterKey key) => MutateKey(key, CharacterKey.Empty);
        public static void MutateKey(this CharacterKey key, CharacterKey knownKey) => MutateKey(key, knownKey, key.Count);
        public static void MutateKey(this CharacterKey key, CharacterKey knownKey, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                char char1 = '\0';
                char char2 = '\0';

                // create 2 random valid indices to swap
                while (char1 == char2 || knownKey.ContainsKey(char1) || knownKey.ContainsKey(char2)){ //TODO: optimise Timur's method
                    char1 = StringUtils.GetCharFromIndex(key.RandomIndex());
                    char2 = StringUtils.GetCharFromIndex(key.RandomIndex());
                }

                // swap the values
                char tempValue = key[char1];
                key[char1] = key[char2];
                key[char2] = tempValue;
            }
        }
    }
}
