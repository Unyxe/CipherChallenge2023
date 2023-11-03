using System.Collections;
using System.Runtime.CompilerServices;

namespace CiphersMain.Keys
{
    /// <summary>
    /// A generic key object for use in ciphers.
    /// </summary>
    /// <typeparam name="T">The type the key deals with, usually <see cref="char"/>.</typeparam>
    public interface IKey<T>
    {
        public ICollection<T> Values { get; }
    }
}