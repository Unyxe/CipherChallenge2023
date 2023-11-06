using CiphersMain.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Breakers.Substitution
{
    public record SubstitutionBreakerParameters
    {
        public string Ciphertext { get; }
        public CharacterKey InitialKey { get; }
        public CharacterKey KnownKey { get; }
        public int MaxGenerations { get; }
        public int KeysPerGeneration { get; }
        public double Acceptance { get; }
        /// <summary>
        /// Parameters used when breaking a cipher.
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="initialKey">A starting key.</param>
        /// <param name="knownKey">A known key who's keys should be preserved.</param>
        /// <param name="maxGenerations">How many iterations of the genetic algorithm to perform.</param>
        /// <param name="keysPerGenerations"></param>
        /// <param name="acceptance">The target fitness for the genetic algorithm.</param>
        public SubstitutionBreakerParameters(string ciphertext, CharacterKey initialKey, CharacterKey knownKey, int maxGenerations, int keysPerGenerations, double acceptance)
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
