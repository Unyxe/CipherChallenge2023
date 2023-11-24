using CiphersMain.Keys;
using ErikCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Ciphers.Transposition
{
    public class TranspositionCipher : ICipher<IntegerKey>
    {
        public string Name => "TRANSPOSITION";

        public IntegerKey Key { get; set; } = new IntegerKey();

        public string Decrypt(string cipherText, IntegerKey key) => Encrypt(cipherText, key.ReverseKey());

        public string Encrypt(string plainText, IntegerKey key)
        {
            var chunks = StringUtils.SplitStringIntoChunksWithPadding(plainText, key.Count, key.Count);
            var sb = new StringBuilder();
            foreach (var chunk in chunks)
            {
                for (int i = 0; i < chunk.Length; i++)
                {
                    sb.Append(chunk[key[i]]);
                }
            }
            return sb.ToString();
        }
    }
}
