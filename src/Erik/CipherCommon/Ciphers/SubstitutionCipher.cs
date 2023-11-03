using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CipherCommon.Keys;
using CipherCommon.Utils;

namespace CipherCommon.Ciphers
{
    public class SubstitutionCipher : ICipher<char>
    {
        public static CharacterKey CreateCaesarKey(int shift)
        {
            char[] letters = new char[StringUtils.ALPHABET_LENGTH];
            for (int i = 0; i < StringUtils.ALPHABET_LENGTH; i++) {
                char c = StringUtils.GetCharFromIndex((i+shift) % StringUtils.ALPHABET_LENGTH);
                letters[i] = c;
            }
            return new CharacterKey(letters);
        }
        public string Decrypt(string cipherText, Key<char> key)
        {
            CharacterKey? newKey = key as CharacterKey;
            if (newKey == null)
                throw new ArgumentException("Key in unrecognised format.");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cipherText.Length; i++)
            {
                char newChar = newKey.Reverse(cipherText[i]);
                sb.Append(newChar);
            }
            return sb.ToString();
        }

        public string Encrypt(string plainText, Key<char> key)
        {
            CharacterKey? newKey = key as CharacterKey;
            if (newKey == null)
                throw new ArgumentException("Key in unrecognised format.");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < plainText.Length; i++)
            {
                char newChar = newKey.Forward(plainText[i]);
                sb.Append(newChar);
            }
            return sb.ToString();
        }
    }
}
