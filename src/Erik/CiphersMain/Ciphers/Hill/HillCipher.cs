using ErikCommon;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Ciphers.Hill
{
    public class HillCipher
    {
        {
            var chunks = StringUtils.SplitStringIntoChunks(plainText, key.ColumnCount, key.ColumnCount);
            var sb = new StringBuilder();
            foreach (var c in chunks)
            {
                var vector = Vector<double>.Build.DenseOfArray(c.Select(x => (double)StringUtils.GetLetterIndex(x)).ToArray());
                var result = key *vector;
                foreach(var i in result.Select(x => StringUtils.GetCharFromIndex((int)x % 26)))
                {
                    sb.Append(i);
                }

            // Split the plaintext into blocks of size blockSize
            List<string> blocks = new List<string>();
            for (int i = 0; i < plainText.Length; i += blockSize)
            {
                blocks.Add(plainText.Substring(i, blockSize));
            }
            return sb.ToString();
        }

        public string Decrypt(string cipherText, Matrix<double> key)
        {
            var chunks = StringUtils.SplitStringIntoChunks(cipherText, key.ColumnCount, key.ColumnCount);
            var sb = new StringBuilder();
            foreach (var c in chunks)
            {
                var vector = Vector<double>.Build.DenseOfArray(c.Select(x => (double)StringUtils.GetLetterIndex(x)).ToArray());
                var result = key.Inverse() * vector;
                foreach (var i in result.Select(x => StringUtils.GetCharFromIndex((int)(x+26) % 26)))
                {
                    sb.Append(i);
                }

                cipherText.Append(encryptedBlock);
            }
            return sb.ToString();
        }
    }
}
