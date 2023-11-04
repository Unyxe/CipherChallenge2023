﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrequencyAnalysis;
using FrequencyAnalysis.Data;

namespace CiphersMain.Breakers.Fitness
{
    public class MonogramFitnessFunction : IFitnessFunction
    {
        private readonly FrequencyAnalysisParamters paramters = new FrequencyAnalysisParamters { NGramLength=1};

        public double CalculateFitness(string text)
        {
            return DataTables.Instance.MonogramAnalysis.Compare(text, 1);
        }
    }
}
