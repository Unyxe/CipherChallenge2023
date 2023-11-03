using CiphersMain.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Keys
{
    public class CharacterKey : IKey<char>, IDictionary<char, char>
    {
        public Dictionary<char, char> Forward = new Dictionary<char, char>();
        public Dictionary<char, char> Reverse = new Dictionary<char, char>();

        public ICollection<char> Keys => Forward.Keys;

        public ICollection<char> Values => Forward.Values;

        public int Count => Forward.Count;

        public bool IsReadOnly => false;

        public char this[char key] { get => Forward[key]; set => SetForward(key, value); }
        /// <summary>
        /// Creates an empty<see cref="CharacterKey"/>.
        /// </summary>
        public CharacterKey(){ }
        /// <summary>
        /// Creates an <see cref="CharacterKey"/> from string representation.
        /// </summary>
        public CharacterKey(string key)
        {
            for (int i = 0; i < key.Length; i++)
                SetForward(StringUtils.GetCharFromIndex(i), key[i]);
        }
        public char GetForward(char key) { return Forward[key]; }
        public char GetReverse(char key) { return Reverse[key]; }
        public void SetForward(char key, char value)
        {
            Forward[key] = value;
            Reverse[value] = key;
        }
        public void SetReverse(char key, char value) => SetForward(value, key);

        public void Add(char key, char value) => SetForward(key, value);

        public bool ContainsKey(char key) => Forward.ContainsKey(key);

        public bool Remove(char key)
        {
            if (Forward.ContainsKey(key))
            {
                Reverse.Remove(Forward[key]);
                Forward.Remove(key);
                return true;
            }
            return false;
        }

        public bool TryGetValue(char key, [MaybeNullWhen(false)] out char value) => Forward.TryGetValue(key, out value);

        public void Add(KeyValuePair<char, char> item) =>
            SetForward(item.Key, item.Value);

        public void Clear()
        {
            Forward.Clear();
            Reverse.Clear();
        }

        public bool Contains(KeyValuePair<char, char> item) =>
            Forward.Contains(item);

        public void CopyTo(KeyValuePair<char, char>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<char, char> item) => Remove(item.Key);

        IEnumerator<KeyValuePair<char, char>> IEnumerable<KeyValuePair<char, char>>.GetEnumerator() => Forward.GetEnumerator();

        public IEnumerator GetEnumerator() => Forward.GetEnumerator();
    }
}
