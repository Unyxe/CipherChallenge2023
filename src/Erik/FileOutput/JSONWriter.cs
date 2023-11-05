using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace FileOutput;
public static class JSONWriter
{
    public static void WriteToFile(string path, CipherFileData data)
    {
        if (!File.Exists(path))
        {
            FileInfo file = new FileInfo(path);
            file.Directory.Create();
        }
        string jsonString = JsonSerializer.Serialize(data);
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.Write(jsonString);
        }
    }
    public static void WriteToFile(string path, string ciphertext, string key, string plaintext, string cipherType)
    {
        var data = new CipherFileData(ciphertext, key, plaintext, cipherType);
        WriteToFile(path, data);
    }
}
