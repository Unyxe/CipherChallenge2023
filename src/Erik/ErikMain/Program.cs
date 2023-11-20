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

#region ciphertext
string cipherText = "YZVM NOPYZION,\r\n\r\nRZGXJHZ OJ OCZ OMZVNPMZ CPIO! VGG JA OCZ XGPZN RDGG GZVY TJP OJ YDAAZMZIO KVBZN JI HVOCNPIDQZMNZ.XJH/XDKCZMN. OCDN ADMNO XGPZ DN OJ OCZ KVBZ \"WMZVYWJVMY\" (NJ HVOCNPIDQZMNZ.XJH/XDKCZMN/WMZVYWJVMY), VIY TJP HVT ADIY OCZ RJMY \"XDKCZMN\" PNZAPG RCZI TJP BZO OCZMZ.\r\n\r\nOCZ XDKCZM TJP EPNO YZXMTKOZY PNZY V XVZNVM XDKCZM, RCDXC DN V NDHKGZ NPWNODOPODJI XDKCZM. OCZ IZSO JIZ RDGG VGNJ WZ V NPWNODOPODJI XDKCZM, WPO DO RJI'O WZ V XVZNVM XDKCZM.\r\n\r\nTJP HVT ADIY OCVO NJHZODHZN OCZ HZNNVBZ TJP'MZ GJJFDIB AJM DNI'O RCZMZ TJP VMZ ZSKZXODIB DO, JM OCVO OCZMZ'N V XGPZ CDYYZI NJHZRCZMZ JI OCZ KVBZ. DO'N RZGG RJMOC TJPM RCDGZ OJ FZZK OCZ YZQZGJKZM OJJGN JKZI VIY \"QDZR NJPMXZ\" DI XVNZ OCZMZ VMZ VIT NPKZM NZXMZO HZNNVBZN GPMFDIB VITRCZMZ. D RJI'O OZGG TJP OCDN VBVDI.\r\n\r\nVGG OCZ WZNO VIY CVKKT XJYZ WMZVFDIB!\r\n\r\nFDIY MZBVMYN,\r\n\r\nHM BJMYJI";
#endregion
var breaker = new SubstitutionBreaker();
var key = breaker.Break(StringUtils.CipherFormat(cipherText));

var cipher = new SubstitutionCipher();
Console.WriteLine(cipher.Decrypt(cipherText, key));

Console.WriteLine(sw.ElapsedMilliseconds);