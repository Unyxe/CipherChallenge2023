using CiphersMain.Breakers.Fitness;
using CiphersMain.Ciphers;
using CiphersMain.Keys;
using ErikCommon;
using FrequencyAnalysis;
using FrequencyAnalysis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Vignere
{
    public class VignereBreaker : IBreaker<StringKey>
    {
        private IFitnessFunction fitnessFunction;
        public VignereBreaker()
        {
            fitnessFunction = new QuadgramFitnessFunction();
        }
        public BreakerResult<StringKey> Break(string cipherText)
        {
            var container = new BreakerResultContainer<StringKey>(5);
            var cipher = new VignereCipher();
            Parallel.ForEach(DataTables.Instance.SixLetters, key => {
                var currentKey = new StringKey(key);
                string text = cipher.Decrypt(cipherText, currentKey);
                var fitness = fitnessFunction.CalculateFitness(text);
                container.TryPush(currentKey, fitness, text);
            });
            return container.ToResult();
        }
    }
}
