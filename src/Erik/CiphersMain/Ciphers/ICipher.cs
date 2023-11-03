using CiphersMain.Keys;

namespace CiphersMain.Ciphers;

public interface ICipher<T>
{
    public string Encrypt(string plainText, IKey<T> key);
    public string Decrypt(string cipherText, IKey<T> key);
}
