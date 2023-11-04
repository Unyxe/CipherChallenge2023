using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiphersMain.Keys;
using CiphersMain.Utils;

namespace CiphersMain.Ciphers
{
    public class SubstitutionCipher : ICipher<CharacterKey>
    {
        /// <summary>
        /// Creates a substitution key for a Caeser (shift) cipher.
        /// </summary>
        /// <param name="shift">The alphabet shift.</param>
        /// <returns>The Caeser cipher key.</returns>
        public static CharacterKey CreateCaesarKey(int shift)
        {
            CharacterKey key = new CharacterKey();
            for (int i = 0; i < StringUtils.ALPHABET_LENGTH; i++)
                key.SetForward(StringUtils.GetCharFromIndex(i), StringUtils.GetCharFromIndex((i + shift) % StringUtils.ALPHABET_LENGTH));
            return key;
        }
        /// <inheritdoc/>
        public string Decrypt(string cipherText, CharacterKey key)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cipherText.Length; i++)
            {
                sb.Append(key.GetReverse(cipherText[i]));
            }
            return sb.ToString();
        }
        /// <inheritdoc/>
        public string Encrypt(string plainText, CharacterKey key)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < plainText.Length; i++)
            {
                sb.Append(key.GetForward(plainText[i]));
            }
            return sb.ToString();
        }
    }
}
