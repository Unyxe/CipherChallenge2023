using CiphersMain.Keys;
using FrequencyAnalysis.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Ciphers.Morse
{
    /// <summary>
    /// Morse Code - English.
    /// </summary>
    public class MorseCipher : ICipher<EmptyKey>
    {
        public string Name => "MORSE";


        public string Decrypt(string cipherText, ICipher<EmptyKey> _) => Decrypt(cipherText);

        public string Decrypt(string cipherText)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string word in cipherText.Split('/'))
            {
                foreach (string phrase in word.Trim().Split(' ')) {
                    if (DataTables.Instance.MorseToChar.ContainsKey(phrase))
                        sb.Append(DataTables.Instance.MorseToChar[phrase]);
                    //else
                    //    sb.Append($"[{phrase}]");
                }
            }
            return sb.ToString();
        }

        public string Decrypt(string cipherText, EmptyKey key)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string plainText, ICipher<EmptyKey> _)=> Encrypt(plainText);
        public string Encrypt(string plainText)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var c in plainText)
            {
                if (DataTables.Instance.CharToMorse.ContainsKey(c))
                    sb.Append(DataTables.Instance.CharToMorse[c]);
            }
            return sb.ToString();
        }

        public string Encrypt(string plainText, EmptyKey key)
        {
            throw new NotImplementedException();
        }
    }
}
