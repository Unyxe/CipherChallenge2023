using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace StorageManagement;
public class JSONWriter
{
    private bool promptYesNo(string message)
    {
        Console.Write(message);
        bool resp = Console.ReadLine()?.ToLower() == "y";
        return resp;
    }
    /// <summary>
    /// Writes the results of a cipher cracking to a file.
    /// </summary>
    /// <param name="path">The .json file path to write to.</param>
    /// <param name="data"></param>
    public void WriteToFile(string path, CipherFileData data, bool silent)
    {
        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            FileInfo file = new FileInfo(path);
            // confirm create directory
            if (!(silent || promptYesNo($"Create directory: {file.DirectoryName}? [Y/N] ")))
                return;
            file.Directory?.Create();
        }

        // confirm overwrite file
        if (File.Exists(path))
            if (!(silent || promptYesNo($"Overwrite file: {path}? [Y/N] ")))
                return;

        string jsonString = JsonSerializer.Serialize(data);
        using (StreamWriter sw = new StreamWriter(path))
            sw.Write(jsonString);

        if (!silent)
            Console.WriteLine($"Output to file: {path}");
    }
}
