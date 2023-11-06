using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyAnalysis
{

    public interface IFrequencyAnalysisResult : IReadOnlyDictionary<string, double>
    {

        /// <summary>
        /// The length of the Polygram.
        /// </summary>
        public int PolygramLength { get; }
        
        /// <summary>
        /// Compare some <paramref name="text"/> to this frequency analysis.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public double Compare(string text);

        /// <summary>
        /// A user-friendly string representing some data such as the Total, Count and most common occurance in the frequency analysis.
        /// </summary>
        public string Summary { get; }
    }
}
