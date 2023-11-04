using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gma.DataStructures.StringSearch;

namespace FrequencyAnalysis
{
    public class EnglishFrequencyAnalysisResult : IFrequencyAnalysisResult
    {

        private FrequencyAnalysisParamters _internalParameters;
        private UkkonenTrie<double> _internalTrie;

        public double this[string key] => _internalTrie.Retrieve();

        public string Summary => "<Analysis of English Language>";

        public IEnumerable<string> Keys => _internalTrie.Keys;

        public IEnumerable<double> Values => _internalTrie.Values;

        public int Count => _internalTrie.Count;

        public int PolygramLength => _internalParameters.NGramLength;

        public EnglishFrequencyAnalysisResult(FrequencyAnalysisParamters p, Dictionary<string, double> frequencies)
        {
            _internalTrie = frequencies;
            _internalParameters = p;
        }
        public double Compare(IFrequencyAnalysisResult other)
        {
            double deviation = 0;
            foreach(var key in _internalTrie.Keys)
            {
                 deviation += Math.Abs(_internalTrie[key] - other[key]);
            }
            return 1 - deviation/2;
        }

        public bool ContainsKey(string key) => _internalTrie.ContainsKey(key);

        public IEnumerator<KeyValuePair<string, double>> GetEnumerator() => _internalTrie.GetEnumerator();

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out double value) => _internalTrie.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => _internalTrie.GetEnumerator();
    }
}
