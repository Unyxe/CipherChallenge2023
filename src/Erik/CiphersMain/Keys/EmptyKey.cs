using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Keys
{
    public class EmptyKey : IKey<byte>
    {
#pragma warning disable CS8603 // Possible null reference return.
        public ICollection<byte> Values => null;
#pragma warning restore CS8603 // Possible null reference return.
        public static EmptyKey Empty { get { return new EmptyKey(); } }
    }
}
