using CiphersMain.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Substitution
{
    internal struct CharacterKeyResult
    {
        public CharacterKey Key { get; set; }
        public double Fitness { get; set; }
    }
}
