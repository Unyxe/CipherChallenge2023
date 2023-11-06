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
    /// <summary>
    /// Breaks a substitution cipher.
    /// </summary>
    // TODO: implement an interface IBreaker.
    public class SubstitutionBreaker
    {
        // TODO: accept this as parameters
        private const int _genCount = 10000;
        private const int _keyCount = 100;

        public CharacterKey Break(string cipherText, double acceptance) => Break(cipherText, CharacterKey.Empty, acceptance);
        /// <summary>
        /// Attempts to find the key used to encrypt the text.
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="knownKey"></param>
        /// <param name="acceptance">The target fitness to achieve.</param>
        /// <param name="threads"></param>
        /// <returns></returns>
        public CharacterKey Break(string ciphertext, CharacterKey knownKey, double acceptance, int threads = 16)
        {
            // create workers, run them...
            Task<CharacterKey>[] workers = new Task<CharacterKey>[threads];
            for (int i = 0; i < threads; i++)
            {
                workers[i] = Task.Run(() => _decrypt(ciphertext, knownKey, acceptance, i));
            }
            // ... and wait for the first to finish
            int index = Task.WaitAny(workers);
            return workers[index].Result;
        }
        private CharacterKey _decrypt(string ciphertext, CharacterKey knownKey, double acceptance, int threadID)
        {
            CharacterKey startKey = CharacterKey.CreateGoodKey(ciphertext, knownKey);
            SubstitutionGeneticAlgorithm geneticAlgorithm = new SubstitutionGeneticAlgorithm();
            var foundKey = geneticAlgorithm.Run(new SubstitutionBreakerParameters(ciphertext, startKey, knownKey, _genCount, _keyCount, acceptance > 0 ? acceptance : 1), threadID, true);
            return foundKey;
        }
    }
}
