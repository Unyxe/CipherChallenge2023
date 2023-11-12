using CiphersMain.Keys;
using ErikCommon;
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
                int index1 = 0;
                int index2 = 0;

                // create 2 random valid indices to swap
                while (index1 == index2){ //TODO: optimise Timur's method
                    index1 = key.RandomIndex();
                    index2 = key.RandomIndex();
                }

                // swap the values
                char char1 = StringUtils.GetCharFromIndex(index1);
                char char2 = StringUtils.GetCharFromIndex(index2);
                char tempValue = key[char1];
                key[char1] = key[char2];
                key[char2] = tempValue;
            }
        }
    }
}
