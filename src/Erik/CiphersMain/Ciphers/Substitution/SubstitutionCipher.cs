using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiphersMain.Keys;
using ErikCommon;

namespace CiphersMain.Ciphers
{
    public class SubstitutionCipher : ICipher<CharacterKey>
    {
        public CharacterKey Key { get; set; }

        public string Name => "Substitution";

        public SubstitutionCipher(CharacterKey key)
        {
            Key = key;
        }
        public SubstitutionCipher()
        {
            Key = new CharacterKey(StringUtils.ALPHABET);
        }

        /// <summary>
        /// Creates a substitution key for a Caeser (shift) cipher.
        /// </summary>
        /// <param name="shift">The alphabet shift.</param>
        /// <returns>The Caeser cipher key.</returns>
        public static CharacterKey CreateCaesarKey(int shift)
        {
            CharacterKey newKey = new CharacterKey();
            for (int i = 0; i < StringUtils.ALPHABET_LENGTH; i++)
                newKey.SetForward(StringUtils.GetCharFromIndex(i), StringUtils.GetCharFromIndex((i + shift) % StringUtils.ALPHABET_LENGTH));
            return newKey;
        }
        public string Decrypt(string cipherText)=> Decrypt(cipherText, Key);
        /// <inheritdoc/>
        public string Decrypt(string cipherText, CharacterKey key)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cipherText.Length; i++)
            {
                if (Key.ContainsKey(cipherText[i]))
                    sb.Append(key.GetReverse(cipherText[i]));
                else
                    sb.Append(cipherText[i]);
            }
            return sb.ToString();
        }
        public string Encrypt(string plainText) => Decrypt(plainText, Key);
        /// <inheritdoc/>
        public string Encrypt(string plainText, CharacterKey key)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < plainText.Length; i++)
            {
                if (Key.ContainsKey(plainText[i]))
                    sb.Append(Key.GetForward(plainText[i]));
                else
                    sb.Append(plainText[i]);
            }
            return sb.ToString();
        }
    }
}
