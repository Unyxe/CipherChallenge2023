using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers
{
    /// <summary>
    /// A breaker for a cipher.
    /// </summary>
    /// <typeparam name="T">They key that the algorithm uses, and returns.</typeparam>
    public interface IBreaker<T>
    {
        public T Break(string ciphertext);
    }
}
