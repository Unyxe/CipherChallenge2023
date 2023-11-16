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
        public string Name => "Transposition Cipher";

        public IntegerKey Key { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Decrypt(string cipherText, IntegerKey key)
        {
            throw new NotImplementedException();
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
