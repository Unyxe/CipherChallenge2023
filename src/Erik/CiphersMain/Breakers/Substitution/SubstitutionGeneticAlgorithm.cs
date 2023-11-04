using CiphersMain.Breakers.Fitness;
using CiphersMain.Ciphers;
using CiphersMain.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Substitution
{
    public class SubstitutionGeneticAlgorithm
    {
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
            bestFitness = double.MinValue;
            double fitness;
            string plainText;

            // for each key, decrypt the ciphertext and select the one that matches the English language the closest
            foreach (CharacterKey key in keys)
            {
                plainText = _subCipher.Decrypt(ciphertext, key);
                fitness = _fitnessFunction.CalculateFitness(plainText);
                if (fitness > bestFitness)
                {
                    bestFitness = fitness;
                    bestKey = key;
                }
            }
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
                keys = CreateKeys(initialKey, keysPerGeneration, knownKey, (int)Math.Clamp((1-Math.Pow(fitness,3))*10,1,13));
                newKey = FindBestKey(keys, ciphertext, out double newfitness);
                if (newfitness > fitness)
                {
                    bestKey = newKey;
                    fitness = newfitness;
                }
                Console.WriteLine($"{fitness} {newfitness}");
            }
            return bestKey;
        }
    }
}
