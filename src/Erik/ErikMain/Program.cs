using CiphersMain.Breakers.Substitution;
using CiphersMain.Ciphers;
using CiphersMain.Keys;
using CiphersMain.Utils;
using FrequencyAnalysis;
using System.Diagnostics;

string path = @".\ExampleText.txt";
List<string> texts = new List<string>{ };

if (File.Exists(path))
    texts.Add(StringUtils.CipherFormat(File.ReadAllText(path)));
texts.Add(StringUtils.CipherFormat(@"The Mighty Yeet"));

Stopwatch sw = new Stopwatch();
sw.Start();

var breaker = new SubstitutionBreaker();
StringUtils.WriteEnumerable(breaker.CreateGoodKey(texts[0], new CharacterKey("ABCDEF")).Values);
StringUtils.WriteEnumerable(StringUtils.ALPHABET);