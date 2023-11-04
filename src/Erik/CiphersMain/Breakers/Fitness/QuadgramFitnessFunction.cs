using FrequencyAnalysis;
using FrequencyAnalysis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Fitness
{
    internal class QuadgramFitnessFunction : IFitnessFunction
    {
        private readonly FrequencyAnalysisParamters paramters = new FrequencyAnalysisParamters { NGramLength = 4 };

        public double CalculateFitness(string text)
        {
            IFrequencyAnalysisResult textResult = FrequencyAnalyser.AnalyseText(text, paramters);
            return DataTables.Instance.QuadgramAnalysis.Compare(textResult);
        }
    }
}
