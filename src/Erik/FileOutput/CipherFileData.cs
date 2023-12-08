using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement
{
    public class CipherFileData
    {
        public string Ciphertext { get; }
        public string Key { get; }
        public string Plaintext { get; }
        public string CipherType { get; }
        public DateTime TimeStamp { get; }
        /// <summary>
        /// Data regarding the decryption.
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="key"></param>
        /// <param name="plaintext"></param>
        /// <param name="cipherType">A string name of the cipher algorithm.</param>
        public CipherFileData(string ciphertext, string key, string plaintext, string cipherType)
        {
            Ciphertext = ciphertext;
            Key = key;
            Plaintext = plaintext;
            CipherType = cipherType;
            TimeStamp = DateTime.Now;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CipherFileData() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
