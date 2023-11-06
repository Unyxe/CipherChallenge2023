using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Fitness
{
    /// <summary>
    ///  A function that determines how "good" a deciphered text is.
    /// </summary>
    internal interface IFitnessFunction
    {
        /// <summary>
        /// Calculate the fitness of a text.
        /// </summary>
        /// <param name="text">The deciphered text to evaluate.</param>
        /// <returns>An arbirtrary value where higher is better.</returns>
        public double CalculateFitness(string text);
    }
}
