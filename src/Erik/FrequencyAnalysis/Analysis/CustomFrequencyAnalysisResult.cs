using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FrequencyAnalysis.Analysis;
public class CustomFrequencyAnalysisResult : IFrequencyAnalysisResult
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
    /// <inheritdoc/>
    public int NGramLength { get => _internalParameters.NGramLength; }
    public IEnumerable<string> Keys => _internalDictionary.Keys;
    public IEnumerable<double> Values => _internalDictionary.Values.Cast<double>().Select(x => (double)x / Total);
    public double this[string key]
    {
        get => (double)_internalDictionary[key] / Total;
    }
    /// <summary>
    /// A read-only result of a frequency analysis.
    /// </summary>
    /// <param name="parameters">The Frequency Analysis parameters.</param>
    /// <param name="dict">The results of the analysis</param>
    internal CustomFrequencyAnalysisResult(FrequencyAnalysisParamters parameters, IDictionary<string, int> dict)
    {
        _internalParameters = parameters;
        _internalDictionary = new Dictionary<string, int>(dict);
        foreach (var pair in dict)
            Total += pair.Value;
    }
    /// <inheritdoc/>
    public string Summary => $"Total:{Total}, Count:{Count}, MostCommon: \"{_internalDictionary.OrderByDescending(x => x.Value).First().Key}\"";
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(Summary);
        sb.AppendLine("Contents: [");
        foreach (var pair in _internalDictionary.OrderByDescending(x => x.Value))
        {
            sb.AppendLine($"\"{pair.Key}\":{Math.Round((double)pair.Value / Total, 3)}, ");
        }
        sb.Append("]");
        return sb.ToString();
    }
    /// <inheritdoc/>
    public double Compare(IFrequencyAnalysisResult other)
    {
        double deviation = 0;
        foreach (var pair in _internalDictionary)
        {
            deviation += Math.Pow(pair.Value / Total - other[pair.Key], 2);
        }
        return 1 - deviation;
    }

    public bool ContainsKey(string key) => _internalDictionary.ContainsKey(key);
    public bool TryGetValue(string key, [MaybeNullWhen(false)] out double value)
    {
        bool x = _internalDictionary.TryGetValue(key, out int v);
        value = (double)v / Total;
        return x;
    }
    public IEnumerator<KeyValuePair<string, double>> GetEnumerator() => _internalDictionary.Select(x => new KeyValuePair<string, double>(x.Key, (double)x.Value / Total)).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
