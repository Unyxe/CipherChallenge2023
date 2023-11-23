using CiphersMain.Keys;
using ErikCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Ciphers.Transposition
{
    public class TranspositionCipher : ICipher<IntegerKey>
    {
        public string Name => "Transposition Cipher";

        public IntegerKey Key { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Decrypt(string cipherText, IntegerKey key)
        {
            int rows = (int)Math.Ceiling((double)cipherText.Length / key.Count);
            char[,] matrix = new char[rows, key.Count];

            for (int i = 0; i < cipherText.Length; i++)
            {
                int row = i / key.Count;
                int col = key.Integers[i % key.Count];
                matrix[row, col] = cipherText[i];
            }

            return string.Concat(Enumerable.Range(0, rows).Select(i => new string(Enumerable.Range(0, key.Count).Select(j => matrix[i, j]).ToArray())));
        }

        public string Encrypt(string plainText, IntegerKey key)
        {
            StringBuilder sb = new();
            var chunks = StringUtils.SplitStringIntoChunks(plainText, key.Count, key.Count);
            for (int i = 0; i < key.Count; i++)
            {
                foreach (var chunk in chunks)
                {
                    sb.Append(chunk[key.Integers[i]]);
                }
            }
            return sb.ToString();
        }
    }
}
