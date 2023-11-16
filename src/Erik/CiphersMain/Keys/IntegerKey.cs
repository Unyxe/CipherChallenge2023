using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Keys
{
    public class IntegerKey : IKey<int>
    {
        public int[] Integers { get; set; } = new int[0];
        public ICollection<int> Values => Integers;
        public IntegerKey(params int[] numbers) => Integers = numbers;
        public int Count => Integers.Length;
    }
}
