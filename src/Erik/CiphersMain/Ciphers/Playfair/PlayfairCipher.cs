using CiphersMain.Keys;
using ErikCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Ciphers.Playfair
{
    public class PlayfairCipher : ICipher<StringKey>
    {
        public string Name => "PLAYFAIR";

        public string Decrypt(string cipherText, StringKey key)
        {
            var sb = new StringBuilder();
            var chunks = StringUtils.SplitStringIntoChunks(cipherText, 2, 2);
            foreach (var chunk in chunks)
            {
                var digit1 = int.Parse(chunk[0].ToString());
                var digit2 = int.Parse(chunk[1].ToString());
                int index = digit1 + (digit2-1)*5 - 1;
                sb.Append(key.Key[index]);
            }
            return sb.ToString();
        }

        public string Encrypt(string plainText, StringKey key)
        {
            throw new NotImplementedException();
        }
    }
}
