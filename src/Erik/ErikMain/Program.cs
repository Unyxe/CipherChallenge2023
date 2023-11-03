using CipherCommon.Ciphers;
using CipherCommon.Utils;
using FrequencyAnalysis;

string path = @"C:\Erik\School\CipherChallenge2023\src\Erik\FrequencyAnalysis\ExampleText.txt";
List<string> texts = new List<string>{ };

if (File.Exists(path))
    texts.Add(StringUtils.CipherFormat(File.ReadAllText(path)));


var cipher = new SubstitutionCipher();
var key = SubstitutionCipher.CreateCaesarKey(1);

StringUtils.WriteEnumerable(key);