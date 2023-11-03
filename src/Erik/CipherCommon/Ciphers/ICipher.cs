using CipherCommon.Keys;

namespace CipherCommon.Ciphers;

public interface ICipher<T>
{
    public string Encrypt(string plainText, Key<T> key);
    public string Decrypt(string cipherText, Key<T> key);
}
