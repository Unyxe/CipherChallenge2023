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

        public string Decrypt(string ciphertext, IntegerKey key)
        {
            int keyLength = key.Count;
            int numRows = (ciphertext.Length + keyLength - 1) / keyLength;
            int padding = ciphertext.Length % keyLength;

            char[,] matrix = new char[numRows, keyLength];
            int index = 0;

            for (int j = 0; j < keyLength; j++)
                for (int i = 0; i < numRows; i++)
                {
                    if (i == numRows - 1 && Array.IndexOf(key.Integers,j) > keyLength - padding)
                        matrix[i, j] = ' ';
                    else
                        matrix[i, j] = index < ciphertext.Length ? ciphertext[index++] : ' ';

                }

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < keyLength; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }

            int[] order = key.Integers;

            return new string(Enumerable.Range(0, numRows)
                .SelectMany(i => order.Select(j => matrix[i, j]))
                .Where(c => c != ' ')
                .ToArray());
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
