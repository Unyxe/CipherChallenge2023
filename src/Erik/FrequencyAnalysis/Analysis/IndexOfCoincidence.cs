using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyAnalysis.Analysis
{
    public static class IndexOfCoincidence
    {
        public static double Calculate(string text)
        {
            var counts = new Dictionary<char, int>();
            foreach (var c in text)
            {
                if (counts.ContainsKey(c))
                {
                    counts[c]++;
                }
                else
                {
                    counts[c] = 1;
                }
            }

            // Calculate the total number of letters
            double N = text.Length;

            // Calculate the IoC
            double ioc = 0;
            foreach (var count in counts.Values)
            {
                ioc += count * (count - 1);
            }
            ioc /= N * (N - 1);

            return ioc;
        }
    }
}
