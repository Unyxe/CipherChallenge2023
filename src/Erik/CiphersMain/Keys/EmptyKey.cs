using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Keys
{
    public class EmptyKey : IKey
    {
        public static EmptyKey Empty { get { return new EmptyKey(); } }
    }
}
