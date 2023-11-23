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
    public class SubstitutionBreaker : IBreaker<CharacterKey>
    {

        /// <summary>
        /// Attempts to find the key used to encrypt the <paramref name="ciphertext"/>.
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        public CharacterKey Break(string ciphertext) => Break(new SubstitutionBreakerParameters(StringUtils.CipherFormat(ciphertext), CharacterKey.CreateGoodKey(ciphertext), CharacterKey.Empty, 1000, 10000, 0.126), 16);
        /// <summary>
        /// Attempts to find the key used to encrypt the <paramref name="ciphertext"/>.
        /// </summary>
        /// <param name="acceptance">The minimum fitness until the ciphertext is deemed fully deciphered.</param>
        public CharacterKey Break(string ciphertext, double acceptance) => Break(new SubstitutionBreakerParameters(StringUtils.CipherFormat(ciphertext), CharacterKey.CreateGoodKey(ciphertext), CharacterKey.Empty, 1000, 1000, acceptance));
        /// <summary>
        /// Attempts to find the key used to encrypt the <paramref name="ciphertext"/>.
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="knownKey"></param>
        /// <param name="acceptance">The minimum fitness until the ciphertext is deemed fully deciphered.</param>
        /// <param name="threads"></param>
        /// <returns></returns>
        // TODO: optimise.
        public CharacterKey Break(SubstitutionBreakerParameters parameters, int threads = 16)
        {
            // create workers, run them...
            Task<CharacterKeyResult>[] workers = new Task<CharacterKeyResult>[threads];
            for (int i = 0; i < threads; i++)
            {
                workers[i] = Task.Run(() => _decrypt(parameters, i));
            }
            // ... and wait for them all to finish
            Task.WaitAll(workers);
            // take the one with the best key.
            return workers.Select(x => x.Result).OrderByDescending(x => x.Fitness).First().Key;
        }
        private CharacterKeyResult _decrypt(SubstitutionBreakerParameters parameters, int threadID)
        {
            CharacterKey startKey = CharacterKey.CreateGoodKey(StringUtils.CipherFormat(parameters.Ciphertext), parameters.KnownKey);
            SubstitutionGeneticAlgorithm geneticAlgorithm = new SubstitutionGeneticAlgorithm();
            var foundKey = geneticAlgorithm.Run(parameters, threadID, true);
            return foundKey;
        }
    }
}
