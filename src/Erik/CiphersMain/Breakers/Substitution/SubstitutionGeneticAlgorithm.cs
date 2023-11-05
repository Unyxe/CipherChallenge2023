using CiphersMain.Breakers.Fitness;
using CiphersMain.Ciphers;
using CiphersMain.Keys;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Substitution
{
    public class SubstitutionGeneticAlgorithm
    {
        private object _lockObj = new object();
        private Random _random = new Random();
        private readonly IFitnessFunction _fitnessFunction = new QuadgramFitnessFunction();
        private readonly ICipher<CharacterKey> _subCipher = new SubstitutionCipher();
        private IEnumerable<CharacterKey> CreateKeys(CharacterKey initialKey, int count, CharacterKey knownKey, int randomness)
        {
            for (int i = 0; i < count; i++)
            {
                var newKey = new CharacterKey(initialKey);
                newKey.MutateKey(knownKey, randomness);
                yield return newKey;
            }
        }
        private CharacterKey FindBestKey(IEnumerable<CharacterKey> keys, string ciphertext, out double bestFitness)
        {
            CharacterKey bestKey = CharacterKey.Empty;
            double tempBestFitness = double.MinValue;

            //Stopwatch sw = new Stopwatch();
            // for each key, decrypt the ciphertext and select the one that matches the English language the closest
            //sw.Restart();

            //foreach (var key in keys)
            Parallel.ForEach(keys, key =>
            {
                string decrypted = _subCipher.Decrypt(ciphertext, key);
                //sw.Restart();
                double fitness = _fitnessFunction.CalculateFitness(decrypted);
                //Console.WriteLine(sw.ElapsedTicks);
                //Console.WriteLine(sw.ElapsedTicks);
                lock (_lockObj)
                {
                    if (fitness > tempBestFitness)
                    {
                        tempBestFitness = fitness;
                        bestKey = key;
                    }
                }
            });
            //Console.WriteLine(sw.ElapsedTicks);
            bestFitness = tempBestFitness;
            return bestKey;
        }
        public CharacterKey Run(BreakerParameters parameters, int threadID)
        {
            CharacterKey bestKey = new(parameters.InitialKey);
            IEnumerable<CharacterKey> keys;
            double fitness = double.MinValue;
            CharacterKey newKey;
            double timeOnKey = 0;
            int randomness = 3;
            for (int i = 0; i < parameters.MaxGenerations && fitness< parameters.Acceptance; i++)
            {
                // reset key if we're at a local min
                if (timeOnKey > 5000)
                {
                    timeOnKey = 0;
                    bestKey = new(parameters.InitialKey);
                    continue;
                }


                keys = CreateKeys(bestKey, parameters.KeysPerGeneration, parameters.KnownKey, randomness);
                newKey = FindBestKey(keys, parameters.Ciphertext, out double newfitness);
                if (newfitness > fitness)
                {
                    timeOnKey = 0;
                    bestKey = newKey;
                    fitness = newfitness;
                }
                else
                {
                    timeOnKey++;
                }
                if (i%200==0 && fitness/ parameters .Acceptance> 0.75)
                    Console.WriteLine($"Thread: {threadID} Gen:{i} Fitness: {fitness} {newfitness} {timeOnKey}");
            }
            return bestKey;
        }
    }
}
