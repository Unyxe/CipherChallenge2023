using FrequencyAnalysis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Fitness
{
    internal class TrigramFitnessFunction : IFitnessFunction
    {
        public double CalculateFitness(string text)
        {
            return DataTables.Instance.QuadgramAnalysis.Compare(text, 3);
        }
    }
}
