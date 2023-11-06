using FrequencyAnalysis;
using FrequencyAnalysis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Fitness
{
    /// <summary>
    /// Determines how "good" a deciphered text is based on quadgram frequency analysis.
    /// </summary>
    internal class QuadgramFitnessFunction : IFitnessFunction
    {
        /// <inheritdoc/>
        public double CalculateFitness(string text)
        {
            return DataTables.Instance.QuadgramAnalysis.Compare(text);
        }
    }
}
