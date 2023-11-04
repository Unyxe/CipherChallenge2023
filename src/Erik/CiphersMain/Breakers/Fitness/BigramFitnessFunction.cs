using FrequencyAnalysis;
using FrequencyAnalysis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Fitness
{
    internal class BigramFitnessFunction : IFitnessFunction
    {
        private readonly FrequencyAnalysisParamters paramters = new FrequencyAnalysisParamters { NGramLength = 2 };

        public double CalculateFitness(string text)
        {
            return DataTables.Instance.BigramAnalysis.Compare(text, 2);
        }
    }
}
