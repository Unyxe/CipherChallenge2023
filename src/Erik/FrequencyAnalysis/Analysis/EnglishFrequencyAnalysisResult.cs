﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double Compare(IFrequencyAnalysisResult other)
        {
            double deviation = 0;
            Parallel.ForEach(_internalDictionary, pair =>
             {
                 if (!other.ContainsKey(pair.Key))
                     deviation += pair.Value;
                 else
                     deviation += Math.Pow(pair.Value - other[pair.Key], 2);
             });
            return 1 - deviation;
        }

        public bool ContainsKey(string key) => _internalDictionary.ContainsKey(key);

        public IEnumerator<KeyValuePair<string, double>> GetEnumerator() => _internalDictionary.GetEnumerator();

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out double value) => _internalDictionary.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => _internalDictionary.GetEnumerator();
    }
}
