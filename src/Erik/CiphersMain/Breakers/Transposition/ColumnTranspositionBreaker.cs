using CiphersMain.Breakers.Fitness;
using CiphersMain.Breakers.Transposition;
using CiphersMain.Ciphers;
using CiphersMain.Ciphers.Transposition;
using CiphersMain.Keys;
using ErikCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Transposition
{
    public class ColumnTranspositionBreaker : IBreaker<IntegerKey>
    {
        IFitnessFunction fitnessFunction = new BigramFitnessFunction();
        ColumnTranspositionCipher cipher = new ColumnTranspositionCipher();
        
        public BreakerResult<IntegerKey> Break(string ciphertext, int length)
        {
            var permutations = new IntegerPermutions(length).Permutations;
            var container = new BreakerResultContainer<IntegerKey>(5);
            Queue<IntegerKey> bestKeys = new Queue<IntegerKey>();
            double bestFitness = -1;
            foreach (var x in permutations)
            {
                var key = new IntegerKey(x);
                string plain = cipher.Decrypt(ciphertext, key);
                double fitness = fitnessFunction.CalculateFitness(plain);

                container.TryPush(key, fitness, plain);
            }
            StringUtils.WriteEnumerable(bestKeys, "\n");
            Console.WriteLine(bestFitness);
            return container.ToResult();
        }
        public BreakerResult<IntegerKey> Break(string ciphertext) => Break(ciphertext, 5);
        
    }
}
