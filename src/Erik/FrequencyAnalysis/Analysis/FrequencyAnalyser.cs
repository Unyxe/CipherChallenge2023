using FrequencyAnalysis.Analysis;
using ErikCommon;

namespace FrequencyAnalysis
{
    public static class FrequencyAnalyser
    {
        private static FrequencyAnalysisParamters _defaultMono = new FrequencyAnalysisParamters { NGramLength = 1 };
        /// <summary>
        /// Counts all the occurances of an N-gram with length specified in <paramref name="param"/>.
        /// </summary>
        /// <param name="text">The text to analyse.</param>
        /// <param name="param">The parameters.</param>
        /// <returns></returns>
        public static CustomFrequencyAnalysisResult AnalyseText(string text, FrequencyAnalysisParamters param)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (var block in StringUtils.SplitStringIntoChunks(text, param.NGramLength))
            {
                if (counts.ContainsKey(block))
                    counts[block]++;
                else
                    counts[block] = 1;
            }
            return new CustomFrequencyAnalysisResult(param, counts);
        }
        public static CustomFrequencyAnalysisResult AnalyseText(string text) => AnalyseText(text, _defaultMono);
    }
}
