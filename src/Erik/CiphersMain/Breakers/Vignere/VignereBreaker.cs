using CiphersMain.Breakers.Fitness;
using CiphersMain.Ciphers;
using CiphersMain.Keys;
using FrequencyAnalysis;
using FrequencyAnalysis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Vignere
{
    public class VignereBreaker : IBreaker<StringKey>
    {
        private IFitnessFunction fitnessFunction;
        public VignereBreaker()
        {
            fitnessFunction = new QuadgramFitnessFunction();
        }
        public StringKey Break(string cipherText) => Break(cipherText, 5);
        // TODO: optimise with multithreading.
        public StringKey Break(string cipherText, int keyLength)
        {
            double bestFitness = 0;
            Queue<StringKey> bestKeys = new Queue<StringKey>();
            var cipher = new VignereCipher();
            foreach (var key in DataTables.Instance.FiveLetters)
            {
                var currentKey = new StringKey(key);
                string text = cipher.Decrypt(cipherText, currentKey);
                var fitness = fitnessFunction.CalculateFitness(text);
                if (fitness > bestFitness)
                {
                    bestKeys.Enqueue(currentKey);
                    while (bestKeys.Count > 10)
                        bestKeys.Dequeue();
                    bestFitness = fitness;
                }
            }
            return bestKeys.Last();
        }
    }
}
