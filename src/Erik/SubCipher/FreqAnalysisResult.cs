using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SubCipher
{
    internal class FreqAnalysis : IEnumerable<int>
    {
        private Dictionary<int, int> _internalDictionary;
        public int Total { get; private set; }
        public bool Finalised {  get; private set; }
        public FreqAnalysis()
        {
            _internalDictionary = new Dictionary<int, int>();
        }
        /// <summary>
        /// The count of the alphabet letter.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Count of the letter.</returns>
        /// <exception cref="InvalidOperationException">If trying to assign value when analysis is finalised.</exception>
        public int this[char index]
        {
            get { return _internalDictionary[index]; }
            set
            {
                if (Finalised) throw new InvalidOperationException("Cannot add elements once result has been finalised");
                else _internalDictionary[index] = value;
            }
        }
        /// <summary>
        /// Finalise the analysis and calculate a total of all the frequencies.
        /// </summary>
        public void Finalise()
        {
            Finalised = true;
            Total = _internalDictionary.Values.Sum();
        }

        public void PerformAnalysis(string s, bool finalise = true)
        {
            foreach (char c in s)
            {
                int index = c.AlphabetIndex();

                if (_internalDictionary.ContainsKey(index))
                    _internalDictionary[index]++;
                else
                    _internalDictionary[index] = 0;
            }
            if (finalise) Finalise();
        }
        /// <summary>
        /// Get the relative frequency of the letter by its alphabet index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>The index of the element.</returns>
        /// <exception cref="InvalidOperationException">If analysis has not been finalised.</exception>
        public double GetRelativeFrequency(int index)
        {
            if (!Finalised) throw new InvalidOperationException("Analysis must be finalised");
            return _internalDictionary.ContainsKey(index)?(double)_internalDictionary[index] / Total:0;
        }
        /// <summary>
        /// Get the relative frequency of the letter by its alphabet index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>The index of the element.</returns>
        /// <exception cref="InvalidOperationException">If analysis has not been finalised.</exception>
        public double GetRelativeFrequency(char c) => GetRelativeFrequency(c.AlphabetIndex());

        public IEnumerator<int> GetEnumerator() => _internalDictionary.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _internalDictionary.Values.GetEnumerator();
    }
}
