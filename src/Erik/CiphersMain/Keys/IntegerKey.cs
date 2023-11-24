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
        public IntegerKey(int length) => Integers = new int[length];
        public int Count => Integers.Length;

        public IntegerKey ReverseKey()
        {
            IntegerKey newKey = new IntegerKey(Count);
            for (int i = 0; i < Count; i++)
            {
                newKey.Integers[i] = Array.IndexOf(Integers, i);
            }
            return newKey;
        }
        public int this[int index] => Integers[index];
        public override string ToString()
        {
            return string.Join(", ", Integers);
        }
    }
}
