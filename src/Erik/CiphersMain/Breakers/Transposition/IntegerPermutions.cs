using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Transposition
{
    internal class IntegerPermutions
    {
        public IReadOnlyList<int[]> Permutations { get; }
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
        public IntegerPermutions(int length)
        {
            Permutations = new List<int[]>(_generateAllPermutations(length));
        }
    }
}
