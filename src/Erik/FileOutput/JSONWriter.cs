using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace FileOutput;
public static class JSONWriter
{
    /// <summary>
    /// Writes the results of a cipher cracking to a file.
    /// </summary>
    /// <param name="path">The .json file path to write to.</param>
    /// <param name="data"></param>
    public static void WriteToFile(string path, CipherFileData data)
    {
        if (!File.Exists(path))
        {
            FileInfo file = new FileInfo(path);
            file.Directory?.Create();
        }
        string jsonString = JsonSerializer.Serialize(data);
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.Write(jsonString);
        }
    }
    /// <summary>
    /// Writes the results of a cipher cracking to a file.
    /// </summary>
    /// <param name="path">The .json file path to write to.</param>
    /// <param name="ciphertext"></param>
    /// <param name="key"></param>
    /// <param name="plaintext"></param>
    /// <param name="cipherName">A string name of the cipher.</param>
    public static void WriteToFile(string path, string ciphertext, string key, string plaintext, string cipherName)
    {
        var data = new CipherFileData(ciphertext, key, plaintext, cipherName);
        WriteToFile(path, data);
    }
}
