using CiphersMain.Breakers.Substitution;
using CiphersMain.Breakers;
using CiphersMain.Ciphers;
using CiphersMain.Keys;
using ErikCommon;
using FrequencyAnalysis.Data;
using System.Diagnostics;

string outputPath = @".\Output\test.json";

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
var cipher = new SubstitutionCipher();
var key = new CharacterKey(Utilities.ALPHABET);
var breaker = new SubstitutionBreaker();
key.MutateKey();

// get text to work with
string text = texts[0].PadRight((int)Math.Ceiling((double)texts[0].Length / 4) * 4, ' ');

// encrypt

// Get match of the text, this would usually be a value of the english language
double textMatch = 1;

// break the cipher
var result = breaker.Break(text, textMatch);

Console.WriteLine("\nFound key");
Utilities.WriteEnumerable(result);
Utilities.WriteEnumerable(key);

FileOutput.JSONWriter.WriteToFile(outputPath, text, key.ToString(), cipher.Decrypt(text, key), "Substitution");

Console.WriteLine(sw.ElapsedMilliseconds);