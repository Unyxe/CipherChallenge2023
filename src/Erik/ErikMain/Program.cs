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

string outputPath = @"C:\Erik\CMS\CipherChallenge2023\ErikResults\Challenge4A.json";

if (!File.Exists(outputPath))
    outputPath = @"C:\Erik\School\CipherChallenge2023\ErikResults\Challenge4A.json";

// Load example texts
string path = @".\ExampleOrwell.txt";
List<string> texts = new List<string>{ };

if (File.Exists(path))
    texts.Add(StringUtils.CipherFormat(File.ReadAllText(path)));

string plaintext = texts[0];

var tc = new TranspositionCipher();
var key = new IntegerKey(0, 1, 2, 3, 4, 5);

#region ciphertext
string cipherText = "YZVM NOPYZION,\r\n\r\nRZGXJHZ OJ OCZ OMZVNPMZ CPIO! VGG JA OCZ XGPZN RDGG GZVY TJP OJ YDAAZMZIO KVBZN JI HVOCNPIDQZMNZ.XJH/XDKCZMN. OCDN ADMNO XGPZ DN OJ OCZ KVBZ \"WMZVYWJVMY\" (NJ HVOCNPIDQZMNZ.XJH/XDKCZMN/WMZVYWJVMY), VIY TJP HVT ADIY OCZ RJMY \"XDKCZMN\" PNZAPG RCZI TJP BZO OCZMZ.\r\n\r\nOCZ XDKCZM TJP EPNO YZXMTKOZY PNZY V XVZNVM XDKCZM, RCDXC DN V NDHKGZ NPWNODOPODJI XDKCZM. OCZ IZSO JIZ RDGG VGNJ WZ V NPWNODOPODJI XDKCZM, WPO DO RJI'O WZ V XVZNVM XDKCZM.\r\n\r\nTJP HVT ADIY OCVO NJHZODHZN OCZ HZNNVBZ TJP'MZ GJJFDIB AJM DNI'O RCZMZ TJP VMZ ZSKZXODIB DO, JM OCVO OCZMZ'N V XGPZ CDYYZI NJHZRCZMZ JI OCZ KVBZ. DO'N RZGG RJMOC TJPM RCDGZ OJ FZZK OCZ YZQZGJKZM OJJGN JKZI VIY \"QDZR NJPMXZ\" DI XVNZ OCZMZ VMZ VIT NPKZM NZXMZO HZNNVBZN GPMFDIB VITRCZMZ. D RJI'O OZGG TJP OCDN VBVDI.\r\n\r\nVGG OCZ WZNO VIY CVKKT XJYZ WMZVFDIB!\r\n\r\nFDIY MZBVMYN,\r\n\r\nHM BJMYJI";
#endregion
var breaker = new SubstitutionBreaker();
var key = breaker.Break(StringUtils.CipherFormat(cipherText));

var cipher = new MorseCipher();
string plain = cipher.Decrypt(cipherText);
Console.WriteLine(plain);
//FileOutput.JSONWriter.WriteToFile(outputPath, text, key.ToString(), cipher.Decrypt(text, key), cipher.Name);

var subBreaker = new SubstitutionBreaker();
var cipher2 = new SubstitutionCipher();
var key = subBreaker.Break(plain);
Console.WriteLine(cipher2.Decrypt(plain, key));

//var breaker = new SubstitutionBreaker();
//Console.WriteLine(breaker.Break(cipherText));


Console.WriteLine(sw.ElapsedMilliseconds);