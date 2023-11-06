using FrequencyAnalysis.Data;

namespace CiphersMain.Breakers.Fitness
{
    /// <summary>
    /// Determines how "good" a deciphered text is based on bigram frequency analysis.
    /// </summary>
    internal class BigramFitnessFunction : IFitnessFunction
    {
        ///<inheritdoc/>
        public double CalculateFitness(string text)
        {
            return DataTables.Instance.BigramAnalysis.Compare(text);
        }
    }
}
