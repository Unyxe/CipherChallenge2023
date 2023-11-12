using CiphersMain.Breakers.Substitution;
using CiphersMain.Breakers;
using CiphersMain.Ciphers;
using CiphersMain.Keys;
using ErikCommon;
using FrequencyAnalysis.Data;
using System.Diagnostics;
using CiphersMain.Breakers.Vignere;
using CiphersMain.Ciphers.Enigma;

string outputPath = @"C:\Erik\CMS\CipherChallenge2023\ErikResults\Challenge4A.json";

if (!File.Exists(outputPath))
    outputPath = @"C:\Erik\School\CipherChallenge2023\ErikResults\Challenge4A.json";

// Load example texts
string path = @".\ExampleText.txt";
List<string> texts = new List<string>{ };

if (File.Exists(path))
    texts.Add(StringUtils.CipherFormat(File.ReadAllText(path).Substring(0,1600)));
texts.Add(StringUtils.CipherFormat(@"The Mighty Yeet"));


// start SW
Stopwatch sw = new Stopwatch();
sw.Start();


var wheel = new EnigmaWheel(StringUtils.ALPHABET);
Console.WriteLine(wheel);
wheel.IncrementWheel();
Console.WriteLine(wheel);
wheel.DecrementWheel();
wheel.DecrementWheel();
wheel.DecrementWheel();
Console.WriteLine(wheel);

//FileOutput.JSONWriter.WriteToFile(outputPath, text, key.ToString(), cipher.Decrypt(text, key), cipher.Name);

Console.WriteLine(sw.ElapsedMilliseconds);