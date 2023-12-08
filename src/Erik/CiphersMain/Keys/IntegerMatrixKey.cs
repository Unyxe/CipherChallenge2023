using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Keys
{
    public class IntegerMatrixKey : IKey
    {
        public int[,] Values;
        public IntegerMatrixKey(int[,] values)
        {
            Values = values;
        }
    }
}
