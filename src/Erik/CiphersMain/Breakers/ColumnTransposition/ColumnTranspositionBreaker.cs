using CiphersMain.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.ColumnTransposition
{
    internal class ColumnTranspositionBreaker : IBreaker<IntegerKey>
    {
        private IEnumerable<int> _join(IEnumerable<int> current, int end)
        {
            int count = current.Count();
            int c = 0;
            foreach (int item in current)
            {
                if (c++ == count)
                    yield return end;
                else
                    yield return item;
            }
        }

        private IEnumerable<int> _permutation(IEnumerable<int> current, int desiredLength)
        {
            if (current.Count() == 1)
                yield break;
            for (int i = 0; i < desiredLength; i++)
            {
                if (!current.Contains(i))
                    yield return _permutation(new List<int>(), desiredLength);
            }
        }
        private IEnumerable<int[]> _generateAllPermutations()
        {

        }
        public IntegerKey Break(string ciphertext)
        {
            throw new NotImplementedException();
        }
    }
}
