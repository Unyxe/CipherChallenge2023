using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Keys
{
    public class IntegerMatrixKey : IKey<int>
    {
        public int[,] Values;
        public IntegerMatrixKey(int[,] values)
        {
            Values = values;
        }

        ICollection<int> IKey<int>.Values => throw new NotImplementedException();
    }
}
