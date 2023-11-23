using CiphersMain.Ciphers.Enigma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Ciphers
{
    public class EnigmaCipher
    {
        public string Name => "ENIGMA";
        public EnigmaWheel[] Wheels { get; private set; }
    }
}
