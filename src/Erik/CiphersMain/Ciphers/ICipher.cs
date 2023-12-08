using CiphersMain.Keys;

namespace CiphersMain.Ciphers;

/// <summary>
/// A generic Cipher algorithm.
/// </summary>
/// <typeparam name="T">The key type, such as <see cref="StringKey"/>.</typeparam>
public interface ICipher<T>
{
    /// <summary>
    /// The name of the cipher;
    /// </summary>
    public string Name { get; }
    public T Key { get; set;  }
    /// <summary>
    /// Encrypts the text.
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns>The encrypted text.</returns>
    public string Encrypt(string plainText, T key);
    /// <summary>
    /// Decrypts the text.
    /// </summary>
    /// <param name="cipherText"></param>
    /// <returns>The decrypted text.</returns>
    public string Decrypt(string cipherText, T key);
}
