using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace FrequencyAnalysis
{
    public class EnglishFrequencyAnalysisResult : IFrequencyAnalysisResult
    {

        private FrequencyAnalysisParamters _internalParameters;
        private Dictionary<string, double> _internalDictionary;

        public double this[string key] => _internalDictionary[key];

        public string Summary => "<Analysis of English Language>";

        public IEnumerable<string> Keys => _internalDictionary.Keys;

        public IEnumerable<double> Values => _internalDictionary.Values;

        public int Count => _internalDictionary.Count;

        public int PolygramLength => _internalParameters.NGramLength;

        public EnglishFrequencyAnalysisResult(FrequencyAnalysisParamters p, Dictionary<string, double> frequencies)
        {
            _internalDictionary = frequencies;
            _internalParameters = p;
        }
        /// <inheritdoc/>
        public double Compare(IFrequencyAnalysisResult other)
        {
            double deviation = 0;
            foreach(var key in _internalDictionary.Keys)
            {
                 deviation += Math.Abs(_internalDictionary[key] - other[key]);
            }
            return 1 - deviation/2;
        }
        /// <inheritdoc/>
        public double Compare(string text)
        {
            double sum = 0;
            for (int i = 0; i < text.Length - PolygramLength; i++)
            {
                string slice = text.Substring(i, PolygramLength);
                if (slice.Contains(' '))
                    continue;
                _internalDictionary.TryGetValue(slice, out double value);
                sum += Math.Log(value + 1);
            }
            return sum;
        }

        public bool ContainsKey(string key) => _internalDictionary.ContainsKey(key);

        public IEnumerator<KeyValuePair<string, double>> GetEnumerator() => _internalDictionary.GetEnumerator();

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out double value) => _internalDictionary.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => _internalDictionary.GetEnumerator();
    }
}
