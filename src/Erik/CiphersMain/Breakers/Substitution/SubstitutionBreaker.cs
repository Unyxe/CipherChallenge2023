using CiphersMain.Keys;
using ErikCommon;
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
        private const int _genCount = 20000;
        private const int _keyCount = 10;

        public CharacterKey Break(string cipherText, double acceptance) => Break(cipherText, CharacterKey.Empty, acceptance);
        public CharacterKey Break(string ciphertext, CharacterKey knownKey, double acceptance, int threads = 16)
        {
            Task<CharacterKey>[] workers = new Task<CharacterKey>[threads];
            for (int i = 0; i < threads; i++)
            {
                workers[i] = Task.Run(() => Decrypt(ciphertext, knownKey, acceptance, i));
            }
            int index = Task.WaitAny(workers);
            return workers[index].Result;
        }
        private CharacterKey Decrypt(string ciphertext, CharacterKey knownKey, double acceptance, int threadID)
        {
            CharacterKey startKey = CharacterKey.CreateGoodKey(ciphertext, knownKey);
            SubstitutionGeneticAlgorithm geneticAlgorithm = new SubstitutionGeneticAlgorithm();
            var foundKey = geneticAlgorithm.Run(new BreakerParameters(ciphertext, startKey, knownKey, _genCount, _keyCount, acceptance > 0 ? acceptance : 1), threadID);
            return foundKey;
        }
    }
}
