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
        /// Returns how closely this analysis result matches with another.
        /// Only compares letters existing in the current table. To compare all letters, use the static method (TBI).
        /// </summary>
        /// <param name="other">The other result to compare with.</param>
        /// <exception cref="KeyNotFoundException">If current table has a key that <paramref name="other"/> does not.</exception>
        /// <returns>A value between 0 and 1. 1 represents full match and 0 no match.</returns>
        public double Compare(IFrequencyAnalysisResult other);

        /// <summary>
        /// A user-friendly string representing some data such as the Total, Count and most common occurance in the frequency analysis.
        /// </summary>
        public string Summary { get; }
    }
}
