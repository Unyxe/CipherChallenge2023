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
        private Dictionary<char, char> _forward { get; set; } = new Dictionary<char, char>();
        private Dictionary<char, char> _reverse { get; set; } = new Dictionary<char, char>();

        public ICollection<char> Keys => _forward.Keys;

        public ICollection<char> Values => _forward.Values;

        public int Count => _forward.Count;

        public bool IsReadOnly => false;

        public char this[char key] { get => _forward[key]; set => SetForward(key, value); }
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
        /// <summary>
        /// The forward getter for values.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public char GetForward(char key) { return _forward[key]; }
        /// <summary>
        /// The reverse getter for keys.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public char GetReverse(char value) { return _reverse[value]; }
        /// <summary>
        /// The forward setter for setting values.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetForward(char key, char value)
        {
            _forward[key] = value;
            _reverse[value] = key;
        }
        /// <summary>
        /// The reverse setter for setting keys by value.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetReverse(char key, char value) => SetForward(value, key);

        public void Add(char key, char value) => SetForward(key, value);

        public bool ContainsKey(char key) => _forward.ContainsKey(key);
        public bool ContainsValue(char value) => _reverse.ContainsKey(value);

        public bool Remove(char key)
        {
            if (_forward.ContainsKey(key))
            {
                _reverse.Remove(_forward[key]);
                _forward.Remove(key);
                return true;
            }
            return false;
        }

        public bool TryGetValue(char key, [MaybeNullWhen(false)] out char value) => _forward.TryGetValue(key, out value);

        public void Add(KeyValuePair<char, char> item) =>
            SetForward(item.Key, item.Value);

        public void Clear()
        {
            _forward.Clear();
            _reverse.Clear();
        }

        public bool Contains(KeyValuePair<char, char> item) =>
            _forward.Contains(item);

        public void CopyTo(KeyValuePair<char, char>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<char, char> item) => Remove(item.Key);

        IEnumerator<KeyValuePair<char, char>> IEnumerable<KeyValuePair<char, char>>.GetEnumerator() => _forward.GetEnumerator();

        public IEnumerator GetEnumerator() => _forward.GetEnumerator();
    }
}
