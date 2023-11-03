using System.Collections;
using System.Runtime.CompilerServices;

namespace CiphersMain.Keys
{
    public interface IKey<T>
    {
        public ICollection<T> Values { get; }
    }
}