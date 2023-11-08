using ErikCommon;
using FrequencyAnalysis;
using FrequencyAnalysis.Analysis;
using FrequencyAnalysis.Data;
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
        protected Random _randomSource = new Random();
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
        /// Creates a <see cref="CharacterKey"/> from string representation.
        /// </summary>
        public CharacterKey(string key)
        {
            for (int i = 0; i < key.Length; i++)
                SetForward(Utilities.GetCharFromIndex(i), key[i]);
            _randomSource = new Random(0);
        }
        /// <summary>
        /// Creates a <see cref="CharacterKey"/> from an array.
        /// </summary>
        public CharacterKey(char[] key)
        {
            for (int i = 0; i < key.Length; i++)
                SetForward(Utilities.GetCharFromIndex(i), key[i]);
            _randomSource = new Random(0);
        }
        /// <summary>
        /// Creates a <see cref="CharacterKey"/> from a known key (copies it).
        /// </summary>
        public CharacterKey(CharacterKey knownKey)
        {
            foreach (var key in knownKey.Keys)
            {
                SetForward(key, knownKey[key]);
            }
        }
        public CharacterKey(int seed)
        {
            _randomSource = new Random(seed);
        }
        /// <summary>
        /// Returns a random value between 0 and 26 (exclusive).
        /// </summary>
        /// <returns></returns>
        public int RandomIndex() => _randomSource.Next(Utilities.ALPHABET_LENGTH);
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
        public override int GetHashCode() => _forward.GetHashCode();
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
        public void CopyTo(KeyValuePair<char, char>[] array, int arrayIndex)=>
            throw new NotImplementedException();
        public bool Remove(KeyValuePair<char, char> item) => Remove(item.Key);
        IEnumerator<KeyValuePair<char, char>> IEnumerable<KeyValuePair<char, char>>.GetEnumerator() => _forward.GetEnumerator();
        public IEnumerator GetEnumerator() => _forward.GetEnumerator();

        public override string ToString() => string.Join(", ", Values);
        public static CharacterKey Empty { get; } = new CharacterKey();

        /// <summary>
        /// Creates a <see cref="CharacterKey"/> based on frequency analysis.
        /// </summary>
        /// <param name="text">The text to analyse.</param>
        /// <param name="knownChars">The known character map.</param>
        /// <returns></returns>
        public static CharacterKey CreateGoodKey(string text, IDictionary<char, char> knownChars) => CreateGoodKey(FrequencyAnalyser.AnalyseText(text), knownChars);
        /// <summary>
        /// Creates a <see cref="CharacterKey"/> based on frequency analysis.
        /// </summary>
        /// <param name="text">The text to analyse.</param>
        /// <returns></returns>
        public static CharacterKey CreateGoodKey(string text) => CreateGoodKey(FrequencyAnalyser.AnalyseText(text), new Dictionary<char, char>());
        /// <summary>
        /// Creates a <see cref="CharacterKey"/> based on frequency analysis.
        /// </summary>
        /// <param name="result">The frequency analysis table.</param>
        /// <param name="knownChars">The known character map.</param>
        /// <returns></returns>
        public static CharacterKey CreateGoodKey(CustomFrequencyAnalysisResult result, IDictionary<char, char> knownChars)
        {
            var random = new Random();
            CharacterKey key = new CharacterKey();
            int c = 0;
            var dict = result.ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in Utilities.ALPHABET_BY_FREQUENCY)
            {
                if (!dict.ContainsKey(item.ToString()))
                    dict[item.ToString()] = 0;
            }
            foreach (var item in dict.OrderByDescending(x => x.Value))
            {
                key[item.Key[0]] = Utilities.ALPHABET_BY_FREQUENCY[c++];
            }
            //foreach (char c in Utilities.ALPHABET)
            //{
            //    if (knownChars.ContainsKey(c))
            //    {
            //        key.SetForward(c, knownChars[c]);
            //        continue;
            //    }
            //    else
            //    {
            //        char bestMatchChar = '\0';
            //        double minDifference = double.MaxValue;
            //        double diff;
            //        foreach (char c2 in Utilities.ALPHABET)
            //        {
            //            string charS = c2.ToString();
            //            diff = Math.Abs((DataTables.Instance.MonogramAnalysis[charS] - result[charS]) / DataTables.Instance.MonogramAnalysis[charS]);
            //            if (diff < minDifference && !knownChars.ContainsKey(c2) && !key.ContainsValue(c2))
            //            {
            //                minDifference = diff;
            //                bestMatchChar = c2;
            //            }
            //        }
            //        key[c] = bestMatchChar;
            //    }
            //}
            return key;
        }
    }
}
