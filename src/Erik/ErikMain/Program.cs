using CiphersMain.Breakers.Substitution;
using CiphersMain.Breakers;
using CiphersMain.Ciphers;
using CiphersMain.Keys;
using ErikCommon;
using FrequencyAnalysis.Data;
using System.Diagnostics;

string outputPath = @".\Output\test2.json";

// Load example texts
string path = @".\ExampleText.txt";
List<string> texts = new List<string>{ };

if (File.Exists(path))
    texts.Add(Utilities.CipherFormat(File.ReadAllText(path).Substring(0,1600)));
texts.Add(Utilities.CipherFormat(@"The Mighty Yeet"));


// start SW
Stopwatch sw = new Stopwatch();
sw.Start();

// initialise
var cipher = new VignereCipher();
var key = new StringKey("HELOWRD");

// get text to work with
string text = Utilities.CipherFormat("lllllllll");

// encrypt

string ciphertext = cipher.Encrypt(text, key);

Console.WriteLine(ciphertext);
Console.WriteLine(cipher.Decrypt(ciphertext, key));

//FileOutput.JSONWriter.WriteToFile(outputPath, text, key.ToString(), cipher.Decrypt(text, key), "Substitution");

Console.WriteLine(sw.ElapsedMilliseconds);