using FrequencyAnalysis.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Ciphers.Morse
{
    public class MorseCipher
    {
        public string Name => "Morse";

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
    }
}
