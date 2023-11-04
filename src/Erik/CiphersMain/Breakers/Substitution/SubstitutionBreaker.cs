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
        private const int _genCount = 100;
        private const int _keyCount = 10000;

        public CharacterKey Break(string cipherText) => Break(cipherText, CharacterKey.Empty);
        public CharacterKey Break(string ciphertext, CharacterKey knownKey)
        {
            CharacterKey startKey = CharacterKey.CreateGoodKey(ciphertext, knownKey);
            SubstitutionGeneticAlgorithm geneticAlgorithm = new SubstitutionGeneticAlgorithm();
            var foundKey = geneticAlgorithm.Run(ciphertext, startKey, knownKey, _genCount, _keyCount);
            return foundKey;
        }
    }
}
