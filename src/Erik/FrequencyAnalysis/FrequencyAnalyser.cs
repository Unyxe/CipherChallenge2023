﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyAnalysis
{
    public static class FrequencyAnalyser
    {
        /// <summary>
        /// Counts all the occurances of an N-gram with length specified in <paramref name="param"/>.
        /// </summary>
        /// <param name="text">The text to analyse.</param>
        /// <param name="param">The parameters.</param>
        /// <returns></returns>
        public static FrequencyAnalysisResult AnalyseText(string text, FrequencyAnalysisParamters param)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach(var block in Common.SplitStringIntoChunks(text, param.NGramLength))
            {
                if (counts.ContainsKey(block))
                    counts[block]++;
                else
                    counts[block] = 0;
            }
            return new FrequencyAnalysisResult(param, counts);
        }
    }
}
