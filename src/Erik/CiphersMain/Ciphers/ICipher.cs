using CiphersMain.Keys;

namespace CiphersMain.Ciphers;

/// <summary>
/// A generic Cipher algorithm.
/// </summary>
/// <typeparam name="T">The type the key deals with. Usually <see cref="char"/>.</typeparam>
public interface ICipher<T>
{
    /// <summary>
    /// Encrypts the text.
    /// </summary>
    /// <param name="plainText"></param>
    /// <param name="key"></param>
    /// <returns>The encrypted text.</returns>
    public string Encrypt(string plainText, IKey<T> key);
    /// <summary>
    /// Decrypts the text.
    /// </summary>
    /// <param name="cipherText"></param>
    /// <param name="key"></param>
    /// <returns>The decrypted text.</returns>
    public string Decrypt(string cipherText, IKey<T> key);
}
