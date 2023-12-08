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
        public BreakerResult<CharacterKey> Break(string ciphertext) => Break(new SubstitutionBreakerParameters(StringUtils.CipherFormat(ciphertext), CharacterKey.CreateGoodKey(ciphertext), CharacterKey.Empty, 2000, 10, 1));
        /// <summary>
        /// Attempts to find the key used to encrypt the <paramref name="ciphertext"/>.
        /// </summary>
        /// <param name="acceptance">The minimum fitness until the ciphertext is deemed fully deciphered.</param>
        public BreakerResult<CharacterKey> Break(string ciphertext, double acceptance) => Break(new SubstitutionBreakerParameters(StringUtils.CipherFormat(ciphertext), CharacterKey.CreateGoodKey(ciphertext), CharacterKey.Empty, 2000, 10, acceptance));
        /// <summary>
        /// Attempts to find the key used to encrypt the <paramref name="ciphertext"/>.
        /// </summary>
        /// <returns></returns>
        // TODO: optimise.
        public BreakerResult<CharacterKey> Break(SubstitutionBreakerParameters parameters, int threads = 16)
        {
            // create workers, run them...
            Task<BreakerResult<CharacterKey>>[] workers = new Task<BreakerResult<CharacterKey>>[threads];
            for (int i = 0; i < threads; i++)
            {
                workers[i] = Task.Run(() => _decrypt(parameters, i));
            }
            // ... and wait for them all to finish
            Task.WaitAll(workers);
            // take the one with the best key.
            return workers.Select(x => x.Result).OrderByDescending(x => x.BestFitness).First();
        }
        private BreakerResult<CharacterKey> _decrypt(SubstitutionBreakerParameters parameters, int threadID)
        {
            CharacterKey startKey = CharacterKey.CreateGoodKey(StringUtils.CipherFormat(parameters.Ciphertext), parameters.KnownKey);
            parameters.InitialKey = startKey;
            SubstitutionGeneticAlgorithm geneticAlgorithm = new SubstitutionGeneticAlgorithm();
            var foundCollection = geneticAlgorithm.Run(parameters, threadID, true);
            return foundCollection;
        }
    }
}
