﻿using CiphersMain.Breakers.Substitution;
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

string outputPath = @"C:\Erik\CMS\CipherChallenge2023\ErikResults\Challenge7B.json";

//if (!File.Exists(outputPath))
//    outputPath = @"C:\Erik\School\CipherChallenge2023\ErikResults\Challenge7B.json";

// Load example texts
string path = @".\ExampleOrwell.txt";
List<string> texts = new List<string>{ };

if (File.Exists(path))
    texts.Add(StringUtils.CipherFormat(File.ReadAllText(path)));

#region ciphertext
string cipherText = ".- .. -.-- -. .- / --. -.- .-. -.-. - / . .-.. ..- --- .. / ... --. .- . . / .-.. .-.. ... --- -. / --- -.- --- -. ... / -. .- .- --- - / --- .-- -.. ... -- / ... . .- .- - / --- . .--. -. -.-. / . -.. - .-.. ...- / ..- -. - .-. .-.. / .. -.. -.. - .... / .... . .--. - . / ..-. .- .. .- -.. / --. --- ... .-- .-. / . -- ..- .. .-. / . .. -. -- --- / ..- ... .-. ... --. / ... .. . .... -. / -.-- .- .-. ... .-. / . ... -. --- .-. / .-. --- . -.. .-. / . .-.. . --- -. / .--. . ... . . / .... ..- .- . -- / .- .. --- -.-. .-. / -... .-. -- . .. / .. ... ..-. . .-.. / - -. .. .-. - / . -.-- .-.. ...- .- / --- - - - . / ... .-. --- - .-. / -. .-- .- --- .. / --.- .. .. -.- -. / . .- -. - --- / .- . - -. - / - .. . --- . / - -. - ..-. ..- / -. .. -.. ..-. . / . - -- ... .-. / - -- .... . --- / -.-. -.. .. . . / .- -.-- . -.-. -.-- / ..-. .. --- .... . / ... .- .--. . -.-. / -. .-. .-.. -.. .-- / -.. -. ... .. .. / .-.. -. - --. . / .. --- .- .- -.. / ... . . -... ... / . -.. --- ..- .- / ... .-.. .. - .-. / - . ... .-. --- / ... --- ... - .- / .-.. . . .. .- / -.-- .- --. .-.. -. / -.-- --- . ... --- / . .- .-. --- --- / .- -- . --- ... / -. .. ... --. .- / .. .- .... .- .-.. / -. ... - . -.-. / .. - - . ..- / -.-. -.. .-. ... .. / .-- .-.. --. -- -. / .. - . -- .--. / . -. -. . -.. / .-- ...- ..- ..-. -.-- / .-.. .-.. ... -. ...- / -.-- .-. -.. . . / . .-.. - .-. - / .- .-.. --- -.. .--. / .. ... ... -.. .--. / .-. ... -. - -.-- / .-.. .- ... . -.. / . .--. - .-. .--. / --- -.. -. -.-. .. / -.-. -... -. .- .-. / -. .- -.-- .... ... / .--. --- .- .- .-.. / ...- -.-- .-.. . --- / .- .-. .-. -.. .. / .-.. -. ... ... -.-- / .. .. . -.-. --- / .- -.. . ..- . / . - . .- .--. / .- -.. ... .- .--. / -... .-. . .--. --- / .-.. ... - .. ..-. / .-.. . -.-. -.-. .. / ...- . .-. ... .- / . -.. --- --- -.-. / .-- .-. ... --. --- / --- . ..- . -. / -. --- -.-. .-.. --.- / . ..-. . . ... / -. .-. .-. -.-. .- / .-. -.. --.- --- ... / .- .- -.-. .-. .-. / .--. .-.. -. .. . / .... ... - . -... / . -- - . .-. / ... -.. -. .-.. -.-- / .- - .-. . --- / - -. -- . .-. / - -. . .-.. -. / .-.. .- .. ..- .. / - ..-. . . -. / - --. .. ..-. .-.. / .. ... .-- -.. . / -. -.-. -- ... . /";
#endregion

var morse = new MorseCipher();
string cipherText2 = morse.Decrypt(cipherText);

Console.WriteLine(cipherText2);

var breaker = new ColumnTranspositionBreaker();

var cipher = new TranspositionCipher();
var result4 = breaker.Break(cipherText2, 7);

Console.WriteLine(7);
Console.WriteLine(cipher.Decrypt(cipherText2, result4));

var key = new IntegerKey(3, 2, 1, 5, 0, 4);
var plain = cipher.Decrypt(cipherText2, result4);

FileOutput.JSONWriter.WriteToFile(outputPath, cipherText2, string.Join("", key.Values), plain, "COLUMN-TRANSPOSITION");


//var breaker = new SubstitutionBreaker();
//Console.WriteLine(breaker.Break(cipherText));


//Console.WriteLine(sw.ElapsedMilliseconds);