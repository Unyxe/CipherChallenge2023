using CiphersMain.Keys;
using ErikCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Ciphers.Enigma
{
    public class EnigmaWheel : CharacterKey
    {
        private int _position;
        public int Position { get => _position; set => _position = (value+StringUtils.ALPHABET_LENGTH)% StringUtils.ALPHABET_LENGTH; }
        /// <summary>
        /// Shift every value to the next A:A becomes A:Z, B:B becomes B:A, so on.
        /// </summary>
        /// <returns>Whether the wheel has "rolled over" and another wheel should be spun.</returns>
        public bool DecrementWheel()
        {
            char temp = GetForward(StringUtils.GetCharFromIndex(StringUtils.ALPHABET_LENGTH - 1));
            for (int i = StringUtils.ALPHABET_LENGTH - 1; i > 0; i--)
            {
                char currentIndex = StringUtils.GetCharFromIndex(i);
                char previousIndex = StringUtils.GetCharFromIndex(i - 1);
                SetForward(currentIndex, GetForward(previousIndex));
            }
            SetForward(StringUtils.GetCharFromIndex(0), temp);

            Position--;
            return Position == StringUtils.ALPHABET_LENGTH - 1;
        }
        /// <summary>
        /// Shift every value to the previous A:A becomes A:B. B:B becomes B:A.
        /// </summary>
        /// <returns>Whether the wheel has "rolled over" and another wheel should be spun.</returns>
        public bool IncrementWheel()
        {
            char temp = GetForward(StringUtils.GetCharFromIndex(0));
            for (int i = 0; i < StringUtils.ALPHABET_LENGTH-1; i++)
            {
                char currentIndex = StringUtils.GetCharFromIndex(i);
                char previousIndex = StringUtils.GetCharFromIndex(i + 1);
                SetForward(currentIndex, GetForward(previousIndex));
            }
            SetForward(StringUtils.GetCharFromIndex(StringUtils.ALPHABET_LENGTH-1), temp);
            Position++;
            return Position == 0;
        }
        public EnigmaWheel() : base() { }
        public EnigmaWheel(string key) : base(key) { }
        public EnigmaWheel(char[] key) : base(key) { }
        public EnigmaWheel(CharacterKey knownKey) : base(knownKey) { }
        public EnigmaWheel(EnigmaWheel knownKey) : base(knownKey) { }
        public EnigmaWheel(int seed) : base(seed) { }
    }
}
