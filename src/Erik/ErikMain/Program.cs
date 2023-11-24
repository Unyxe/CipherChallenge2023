using CiphersMain.Breakers.Substitution;
using CiphersMain.Breakers;
using CiphersMain.Ciphers;
using CiphersMain.Keys;
using ErikCommon;
using FrequencyAnalysis.Data;
using System.Diagnostics;
using CiphersMain.Breakers.Vignere;
using CiphersMain.Ciphers.Enigma;
using CiphersMain.Ciphers.Morse;
using CiphersMain.Ciphers.Transposition;
using FileOutput;
using System.ComponentModel.DataAnnotations;
using CiphersMain.Breakers.ColumnTransposition;
using StorageManagement;

string outputPath = @"C:\Erik\CMS\CipherChallenge2023\ErikResults\test.json";

//if (!File.Exists(outputPath))
//    outputPath = @"C:\Erik\School\CipherChallenge2023\ErikResults\Challenge7B.json";

// Load example texts
string path = @".\ExampleOrwell.txt";
List<string> texts = new List<string>{ };

if (File.Exists(path))
    texts.Add(StringUtils.CipherFormat(File.ReadAllText(path)));

#region ciphertext

#endregion

var cipher = new TranspositionCipher();
var plainText = "Hello World!!!!!";
var key = new IntegerKey(0, 3, 2, 1);
var cipherText = cipher.Encrypt(plainText, key);
Console.WriteLine(cipherText);
Console.WriteLine();
var deciphered = cipher.Decrypt(cipherText, key);
Console.WriteLine(deciphered);
//writer.WriteToFile("test", "foo", "bar", "dum", "YEET");


//var breaker = new SubstitutionBreaker();
//Console.WriteLine(breaker.Break(cipherText));


//Console.WriteLine(sw.ElapsedMilliseconds);