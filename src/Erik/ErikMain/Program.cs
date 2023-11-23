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

string outputPath = @"C:\Erik\CMS\CipherChallenge2023\ErikResults\Challenge7A.json";

if (!File.Exists(outputPath))
    outputPath = @"C:\Erik\School\CipherChallenge2023\ErikResults\Challenge7A.json";

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

var cipher = new TranspositionCipher();
var test = "LWLHLODEOR";
var testKey = new IntegerKey(2,0,1);
Console.WriteLine(cipher.Decrypt(test, testKey));
//FileOutput.JSONWriter.WriteToFile(outputPath, cipherText, "FRENCH", plain, "VIGNERE");


//var breaker = new SubstitutionBreaker();
//Console.WriteLine(breaker.Break(cipherText));


//Console.WriteLine(sw.ElapsedMilliseconds);