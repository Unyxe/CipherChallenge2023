using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Keys
{
    /// <summary>
    /// A key in the form of some typical text.
    /// </summary>
    public class StringKey : IKey<char>
    {
        /// <summary>
        /// The string representation of the key.
        /// </summary>
        public string Key { get; set; }
        public ICollection<char> Values { get => Key.ToArray(); }
        public int Count => Values.Count;
        public StringKey(string key)
        {
            Key = key;
        }
        public override string ToString()
        {
            return string.Join("", Values);
        }
    }
}
