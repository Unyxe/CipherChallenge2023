using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiphersMain.Keys;
using CiphersMain.Utils;

namespace CiphersMain.Ciphers
{
    public class SubstitutionCipher : ICipher<char>
    {
        public static CharacterKey CreateCaesarKey(int shift)
        {
            CharacterKey key = new CharacterKey();
            for (int i = 0; i < StringUtils.ALPHABET_LENGTH; i++)
                key.SetForward(StringUtils.GetCharFromIndex(i), StringUtils.GetCharFromIndex((i + shift) % StringUtils.ALPHABET_LENGTH));
            return key;
        }
        public string Decrypt(string cipherText, IKey<char> key)
        {
            CharacterKey? newKey = key as CharacterKey;
            if (newKey == null)
                throw new ArgumentException("Key in unrecognised format.");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cipherText.Length; i++)
            {
                char newChar = newKey.GetReverse(cipherText[i]);
                sb.Append(newChar);
            }
            return sb.ToString();
        }

        public string Encrypt(string plainText, IKey<char> key)
        {
            CharacterKey? newKey = key as CharacterKey;
            if (newKey == null)
                throw new ArgumentException("Key in unrecognised format.");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < plainText.Length; i++)
            {
                char newChar = newKey.GetForward(plainText[i]);
                sb.Append(newChar);
            }
            return sb.ToString();
        }
    }
}
