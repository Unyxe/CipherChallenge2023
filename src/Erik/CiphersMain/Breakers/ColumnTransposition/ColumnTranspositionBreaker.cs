using CiphersMain.Breakers.Fitness;
using CiphersMain.Ciphers;
using CiphersMain.Ciphers.Transposition;
using CiphersMain.Keys;
using ErikCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.ColumnTransposition
{
    public class ColumnTranspositionBreaker : IBreaker<IntegerKey>
    {
        IFitnessFunction fitnessFunction = new BigramFitnessFunction();
        TranspositionCipher cipher = new TranspositionCipher();
        private void _permutation(IList<int[]> permutations, int[] current, int currentLength)
        {
            if (currentLength == current.Length)
                permutations.Add(current);
            else
            {
                for (int i = 0; i < current.Length; i++)
                {
                    if (!current.Contains(i))
                    {
                        var newArr = new int[current.Length];
                        current.CopyTo(newArr, 0);
                        newArr[currentLength] = i;
                        _permutation(permutations, newArr, currentLength + 1);
                    }
                }
            }
        }
        private IList<int[]> _generateAllPermutations(int length)
        {
            int[] arr = Enumerable.Range(0, length).Select(x => -1).ToArray();
            var permutations = new List<int[]>();
            _permutation(permutations, arr, 0);
            return permutations;
        }
        public IntegerKey Break(string ciphertext)
        {
            object lockObj = new object();
            var permutations = _generateAllPermutations(6);
            StringUtils.WriteEnumerable(permutations.Select(x => string.Join(", ",x)), "\n");
            Queue<IntegerKey> bestKeys = new Queue<IntegerKey>();
            double bestFitness = -1;
            foreach(var x in permutations)
            {
                var key = new IntegerKey(x);
                string plain = cipher.Decrypt(ciphertext, key);
                double fitness = fitnessFunction.CalculateFitness(plain);
                lock (lockObj)
                {
                    if (plain.StartsWith("JOD"))//if (fitness > bestFitness)
                    {
                        bestKeys.Enqueue(key);
                        while (bestKeys.Count > 5)
                            bestKeys.Dequeue();
                        bestFitness = fitness;
                    }
                }
            }
            StringUtils.WriteEnumerable(bestKeys, "\n");
            return bestKeys.Last();
        }
    }
}
