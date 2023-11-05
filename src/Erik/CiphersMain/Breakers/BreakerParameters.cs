using CiphersMain.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers
{
    public record BreakerParameters
    {
        public string Ciphertext { get; }
        public CharacterKey InitialKey { get; }
        public CharacterKey KnownKey { get; }
        public int MaxGenerations { get; }
        public int KeysPerGeneration { get; }
        public double Acceptance { get; }
        public BreakerParameters(string ciphertext, CharacterKey initialKey, CharacterKey knownKey, int maxGenerations, int keysPerGenerations, double acceptance )
        {
            Ciphertext = ciphertext;
            InitialKey = initialKey;
            KnownKey = knownKey;
            MaxGenerations = maxGenerations;
            KeysPerGeneration = keysPerGenerations;
            Acceptance = acceptance;
        }
    }
}
