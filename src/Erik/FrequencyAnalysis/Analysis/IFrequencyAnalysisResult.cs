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
        
        public double Compare(string text, int length);

        /// <summary>
        /// A user-friendly string representing some data such as the Total, Count and most common occurance in the frequency analysis.
        /// </summary>
        public string Summary { get; }
    }
}
