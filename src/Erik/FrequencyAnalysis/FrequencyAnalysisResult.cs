﻿using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FrequencyAnalysis;
public class FrequencyAnalysisResult : IReadOnlyDictionary<string, int>
{
    private Dictionary<string, int> _internalDictionary;
    private FrequencyAnalysisParamters _internalParameters;
    /// <summary>
    /// A total frequency of entries.
    /// </summary>
    public int Total { get; private set; }
    /// <summary>
    /// A count of how many entries exist in the table.
    /// </summary>
    public int Count { get => _internalDictionary.Count; }
    /// <summary>
    /// The length of the N-Gram.
    /// </summary>
    public int NGramLength { get => _internalParameters.NGramLength; }
    public IEnumerable<string> Keys => _internalDictionary.Keys;
    public IEnumerable<int> Values => _internalDictionary.Values;
    public int this[string key] => _internalDictionary[key];
    /// <summary>
    /// A read-only result of a frequency analysis.
    /// </summary>
    /// <param name="parameters">The Frequency Analysis parameters.</param>
    /// <param name="dict">The results of the analysis</param>
    internal FrequencyAnalysisResult(FrequencyAnalysisParamters parameters, IDictionary<string, int> dict)
    {
        _internalParameters = parameters;
        _internalDictionary = new Dictionary<string, int>(dict);
        foreach (var pair in dict)
            Total += pair.Value;
    }
    /// <summary>
    /// A user-friendly string representing some data such as the Total, Count and most common occurance in the fequency analysis.
    /// </summary>
    public string Summary => $"Total:{Total}, Count:{Count}, MostCommon: \"{_internalDictionary.OrderByDescending(x => x.Value).First().Key}\"";
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(Summary);
        sb.AppendLine("Contents: [");
        foreach (var pair in _internalDictionary.OrderByDescending(x => x.Value))
        {
            sb.AppendLine($"\"{pair.Key}\":{Math.Round((double)pair.Value/Total,3)}, ");
        }
        sb.Append("]");
        return sb.ToString();
    }

    public bool ContainsKey(string key) => _internalDictionary.ContainsKey(key);
    public bool TryGetValue(string key, [MaybeNullWhen(false)] out int value) => _internalDictionary.TryGetValue(key, out value);
    public IEnumerator<KeyValuePair<string, int>> GetEnumerator() => _internalDictionary.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
