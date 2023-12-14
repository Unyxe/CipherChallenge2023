using CiphersMain.Keys;
using ErikCommon;
using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Ciphers.Bifid
{
    public class BifidCipher
    {
        public string Name => "BIFID";

        public string Decrypt(string cipherText, StringKey key, int n)
        {
            var matrix = _createKeyMatrix(key.Key);
            var blocks = StringUtils.SplitStringIntoChunks(cipherText, n, n);
            var result = new StringBuilder();
            foreach (var block in blocks)
            {
                var indices = new List<int>();
                var coords = new List<(int, int)>();
                foreach (var c in block)
                    coords.Add(_findChar(matrix, c));
                for (int i = 0; i < coords.Count; i++)
                    indices.Add(coords[i].Item1);
                for (int i = 0; i < coords.Count; i++)
                    indices.Add(coords[i].Item2);
                for (int i = 0; i < indices.Count; i += 2)
                    result.Append(matrix[indices[i], indices[i + 1]]);
            }
            return result.ToString();
        }

        public string Encrypt(string plainText, StringKey key, int n)
        {
            var matrix = _createKeyMatrix(key.Key);
            var blocks = StringUtils.SplitStringIntoChunks(plainText, n, n);
            var result = new StringBuilder();
            foreach (var block in blocks)
            {
                var indices = new List<int>();
                var coords = new List<(int, int)>();
                foreach (var c in block)
                    coords.Add(_findChar(matrix, c));
                for (int i = 0; i<coords.Count; i++)
                    indices.Add(coords[i].Item1);
                for (int i = 0; i < coords.Count; i++)
                    indices.Add(coords[i].Item2);
                for (int i = 0; i < indices.Count; i+=2)
                    result.Append(matrix[indices[i], indices[i + 1]]);
            }
            return result.ToString();
        }

        private (int, int) _findChar(char[,] matrix, char c)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] == c)
                    {
                        return (i, j);
                    }
                }
            }
            throw new ArgumentException("Character not found in matrix", nameof(c));
        }
        private char[,] _createKeyMatrix(string key)
        {
            if (key.Length != 25)
            {
                throw new ArgumentException("Key must be 25 characters long", nameof(key));
            }

            char[,] matrix = new char[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = key[i * 5 + j];
                }
            }

            return matrix;
        }
    }
}
