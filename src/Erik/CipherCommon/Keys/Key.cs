using System.Collections;
using System.Runtime.CompilerServices;

namespace CipherCommon.Keys
{
    public abstract class Key<T> : IEnumerable<T>
    {
        protected List<T> Values { get; }

        protected T this[int index]
        { get { return Values[index]; } set { Values[index] = value; } }
        protected Key(T[] values)
        {
            Values = values.ToList();
        }

        public IEnumerator<T> GetEnumerator() => Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Values.GetEnumerator();
    }
}