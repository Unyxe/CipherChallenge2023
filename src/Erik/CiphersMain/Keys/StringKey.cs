using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Keys
{
    public class StringKey : IKey<char>
    {
        public string Key { get; set; }
        public ICollection<char> Values { get => Key.ToArray(); }
        public int Count => Values.Count;
        public StringKey(string key)
        {
            Key = key;
        }
    }
}
