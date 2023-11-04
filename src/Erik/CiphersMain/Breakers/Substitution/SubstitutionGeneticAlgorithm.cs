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
        public CharacterKey Run(string ciphertext, CharacterKey initialKey, CharacterKey knownKey, int generationCount, int keysPerGeneration)
        {
            CharacterKey bestKey = CharacterKey.Empty;
            IEnumerable<CharacterKey> keys;
            double fitness = double.MinValue;
            CharacterKey newKey;
            for (int i = 0; i < generationCount; i++)
            {
                keys = CreateKeys(initialKey, keysPerGeneration, knownKey, (int)Math.Clamp(300*Math.Pow(2, -20*fitness),2,100));
                newKey = FindBestKey(keys, ciphertext, out double newfitness);
                if (newfitness > fitness)
                {
                    bestKey = newKey;
                    fitness = newfitness;
                }
                Console.WriteLine($"{i}: {fitness} {newfitness}");
            }
            return bestKey;
        }
    }
}
