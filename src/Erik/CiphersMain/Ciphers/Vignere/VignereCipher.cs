using CiphersMain.Keys;
using ErikCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Ciphers
{
    public class VignereCipher : ICipher<StringKey>
    {
        public StringKey Key { get; set; }

        public string Name => "Vignere";

        public string Decrypt(string cipherText, StringKey key)
        {
            StringBuilder sb = new StringBuilder();
            int keyIndex = 0;
            for (int i = 0; i < cipherText.Length; i++)
            {
                char cipherChar = cipherText[i];
                char keyChar = key.Key[keyIndex % key.Count];

                int keyCharIndex = StringUtils.GetLetterIndex(keyChar);

                char newChar = StringUtils.GetCharFromIndex((StringUtils.GetLetterIndex(cipherChar) - keyCharIndex + StringUtils.ALPHABET_LENGTH) % StringUtils.ALPHABET_LENGTH);
                keyIndex++;
                sb.Append(newChar);
            }
            return sb.ToString();
        }

        public string Encrypt(string plainText, StringKey key)
        {
            StringBuilder sb = new StringBuilder();
            int keyIndex = 0;
            for (int i = 0; i < plainText.Length; i++)
            {
                char plainChar = plainText[i];

                if (StringUtils.ALPHABET.Contains(plainChar))
                {
                    char keyChar = key.Key[keyIndex % key.Count];

                    int keyCharIndex = StringUtils.GetLetterIndex(keyChar);

                    char newChar = StringUtils.GetCharFromIndex((StringUtils.GetLetterIndex(plainChar) + keyCharIndex) % StringUtils.ALPHABET_LENGTH);
                    sb.Append(newChar);

                    keyIndex++;
                }
                else
                    sb.Append(plainChar);
            }
            return sb.ToString();
        }
    }
}
