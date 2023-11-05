using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOutput
{
    public class CipherFileData
    {
        public string Ciphertext { get; }
        public string Key { get; }
        public string Plaintext { get; }
        public string CipherType { get; }
        public DateTime TimeStamp { get; }
        public CipherFileData(string ciphertext, string key, string plaintext, string cipherType)
        {
            Ciphertext = ciphertext;
            Key = key;
            Plaintext = plaintext;
            CipherType = cipherType;
            TimeStamp = DateTime.Now;
        }
        public CipherFileData() { }
    }
}
