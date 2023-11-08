﻿using CiphersMain.Keys;

namespace CiphersMain.Ciphers;

/// <summary>
/// A generic Cipher algorithm.
/// </summary>
/// <typeparam name="T">The key type. Usually <see cref="char"/>.</typeparam>
public interface ICipher<T>
{
    public T Key { get; set;  }
    /// <summary>
    /// Encrypts the text.
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns>The encrypted text.</returns>
    public string Encrypt(string plainText);
    /// <summary>
    /// Decrypts the text.
    /// </summary>
    /// <param name="cipherText"></param>
    /// <returns>The decrypted text.</returns>
    public string Decrypt(string cipherText);
}
