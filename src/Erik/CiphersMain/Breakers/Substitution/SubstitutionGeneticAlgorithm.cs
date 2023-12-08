using CiphersMain.Breakers.Fitness;
using CiphersMain.Ciphers;
using CiphersMain.Keys;
using ErikCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Substitution
{
    /// <summary>
    /// A genetic algorithm for finding the best substitution key.
    /// </summary>
    internal class SubstitutionGeneticAlgorithm
    {

        private object _lockObj = new object();
        private readonly IFitnessFunction _fitnessFunction = new QuadgramFitnessFunction();
        private readonly ICipher<CharacterKey> _subCipher = new SubstitutionCipher();
        /// <summary>
        /// A generator for creating <paramref name="count"/> keys by randomising an <paramref name="initialKey"/>.
        /// </summary>
        /// <param name="initialKey">The parent key.</param>
        /// <param name="count"></param>
        /// <param name="knownKey">A known key. Preserves the letters in this key.</param>
        /// <param name="randomness">How many iterations of swaps to perform during mutation.</param>
        /// <returns></returns>
        private IEnumerable<CharacterKey> _createKeys(CharacterKey initialKey, int count, CharacterKey knownKey, int randomness)
        {
            for (int i = 0; i < count; i++)
            {
                var newKey = new CharacterKey(initialKey);
                newKey.MutateKey(knownKey, randomness);
                yield return newKey;
            }
        }
        /// <summary>
        /// Find the best key from <paramref name="keys"/>.
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="ciphertext"></param>
        /// <param name="bestFitness">The fitness of the best key.</param>
        /// <returns></returns>
        private CharacterKey FindBestKey(IEnumerable<CharacterKey> keys, string ciphertext, out double bestFitness, out string text)
        {
            CharacterKey bestKey = CharacterKey.Empty;
            double tempBestFitness = double.MinValue;
            string bestText = "";

            //foreach (var key in keys)
            Parallel.ForEach(keys, key =>
            {
                string decrypted = _subCipher.Decrypt(ciphertext, key);
                double fitness = _fitnessFunction.CalculateFitness(decrypted);

                lock (_lockObj)
                {
                    if (fitness > tempBestFitness)
                    {
                        tempBestFitness = fitness;
                        bestKey = key;
                        bestText = decrypted;
                    }
                }
            });
            bestFitness = tempBestFitness;
            text = bestText;
            return bestKey;
        }
        /// <summary>
        /// Perform the simulation to find the correct key.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="ID">The ID of the simulation. Used in console logging.</param>
        /// <param name="writeToConsole"></param>
        /// <returns></returns>
        public BreakerResult<CharacterKey> Run(SubstitutionBreakerParameters parameters, int ID, bool writeToConsole = true)
        {
            // initialise vars in simulation. It's more efficient to initialise them once here.
            var container = new BreakerResultContainer<CharacterKey>(5);
            IEnumerable<CharacterKey> keys;
            CharacterKey newKey;
            double timeOnKey = 0;
            int randomness = 2;

            container.TryPush(parameters.InitialKey, -1, string.Empty);

            for (int i = 0; i < parameters.MaxGenerations && (container .BestFitness< parameters.Acceptance || parameters.Acceptance == 1); i++)
            {
                keys = _createKeys(container.BestKey, parameters.KeysPerGeneration, parameters.KnownKey, 2);
                newKey = FindBestKey(keys, parameters.Ciphertext, out double newfitness, out string text);

                // compare it with the parent
                if (!container.TryPush(newKey, newfitness, text))                
                    timeOnKey++;

                // log
                if (writeToConsole && i % 2000==0)
                {
                    Console.WriteLine($"Thread: {ID} Gen:{i} Fitness: {container.BestFitness} {container.BestKey} {newfitness} {timeOnKey} {container.BestText}");
                    Console.WriteLine();
                }
            }
            return container.ToResult();
        }
    }
}
