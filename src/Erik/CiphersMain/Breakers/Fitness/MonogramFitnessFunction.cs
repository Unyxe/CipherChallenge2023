using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrequencyAnalysis;
using FrequencyAnalysis.Data;

namespace CiphersMain.Breakers.Fitness
{
    /// <summary>
    /// Determines how "good" a deciphered text is based on single-letter frequency analysis.
    /// </summary>
    internal class MonogramFitnessFunction : IFitnessFunction
    {
        /// <inheritdoc/>
        public double CalculateFitness(string text)
        {
            return DataTables.Instance.MonogramAnalysis.Compare(text);
        }
    }
}
