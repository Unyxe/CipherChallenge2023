using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers
{
    /// <summary>
    /// The result of a cipher breaking.
    /// </summary>
    /// <typeparam name="IKey">The key used.</typeparam>
    public struct BreakerResult<IKey>
    {
        /// <summary>
        /// The key with the highest fitness score.
        /// </summary>
        public IKey BestKey { get => Keys[Keys.Count - 1]; }
        /// <summary>
        /// The top keys with the highest fitness scores, in ascending order.
        /// </summary>
        public IReadOnlyList<IKey> Keys { get; }
        /// <summary>
        /// The text with the highest fitness score.
        /// </summary>
        public string BestText { get => PlainTexts[PlainTexts.Count - 1]; }
        /// <summary>
        /// The top texts with the highest fitness scores, in ascending order.
        /// </summary>
        public IReadOnlyList<string> PlainTexts { get; }
        /// <summary>
        /// The highest fitness score.
        /// </summary>
        public double BestFitness { get => Fitnesses[Fitnesses.Count - 1]; }
        /// <summary>
        /// The top fitness scores, in ascending order.
        /// </summary>
        public IReadOnlyList<double> Fitnesses { get; }
        public BreakerResult(IReadOnlyList<IKey> bestKeys, IReadOnlyList<string> bestTexts, IReadOnlyList<double> fitnesses)
        {
            Keys = bestKeys;
            PlainTexts = bestTexts;
            Fitnesses = fitnesses;
        }
    }
}
