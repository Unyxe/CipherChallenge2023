using CiphersMain.Breakers.Substitution;
using CiphersMain.Breakers;
using CiphersMain.Ciphers;
using CiphersMain.Keys;
using CiphersMain.Utils;
using FrequencyAnalysis;
using FrequencyAnalysis.Data;
using System.Diagnostics;

string path = @".\ExampleText.txt";
List<string> texts = new List<string>{ };

if (File.Exists(path))
    texts.Add(StringUtils.CipherFormat(File.ReadAllText(path)));
texts.Add(StringUtils.CipherFormat(@"The Mighty Yeet"));

Stopwatch sw = new Stopwatch();
sw.Start();



var cipher = new SubstitutionCipher();
var key = new CharacterKey(StringUtils.ALPHABET);

key.MutateKey();

string text = texts[0].PadRight((int)Math.Ceiling((double)texts[0].Length / 4) * 4, ' ');

string cipherT = cipher.Encrypt(text, key);
string decipherT = cipher.Decrypt(cipherT, key);

Console.WriteLine(DataTables.Instance.QuadgramAnalysis.Compare(text, 4));

//Console.WriteLine(decipherT);

var breaker = new SubstitutionBreaker();
var result = breaker.Break(cipherT);

StringUtils.WriteEnumerable(result);
StringUtils.WriteEnumerable(key);

Console.WriteLine(sw.ElapsedMilliseconds);