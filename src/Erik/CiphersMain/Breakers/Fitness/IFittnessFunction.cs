﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Fitness
{
    public interface IFittnessFunction
    {
        public double CalculateFitness(string text);
    }
}
