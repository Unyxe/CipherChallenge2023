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
using System.ComponentModel.DataAnnotations;
using CiphersMain.Ciphers.Hill;
using MathNet.Numerics.LinearAlgebra;
using StorageManagement;
using CiphersMain.Ciphers.Bifid;
using FrequencyAnalysis.Analysis;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

string path = @".\ExampleOrwell.txt";
List<string> texts = new List<string>{ };

string cipherText = StringUtils.CipherFormat("HHIZR KHHXH XCFWL WJHIC YFPAX FHHZD VZLWJ HREXL CGWPP XUWSK EEQTP WDSCA ICHHZ DHVPQ NGAEU CNUAH VQJOV ILWJH VZCEL PLTLD NNNHR RPTQT AHXQE EUCGZ LPRFW QQUGZ WAVOW KGZCQ KKZNY ITMMM ASMQW APRPN IBHKL TRIYY QTTHH UWPLP THWHK GVITG HAWOA WVDGZ HALPJ RQTVI OWZGI CORHH ZDBPB JGKEF JOFWX QLPLT RIFMS KAHWO MYWOB JVXPX TZLEJ UEELE LPHKB UWKBP YRLPU IORVP LQICQ TRVQJ HVLEN APTQI PDBZD KKMZR IMEWA OVZAH NACEW EPRLO REGKA HXQBY BJWAP RPNIB HKVPG THAVI NAUQY WAEHH ZDWAR EFJTH VZVIA HASCC WABUZ GICOR FJAHT IVMJN VOXBL ETHFT LCKBI QRVWO EABOL DYWNA KWFWV MOUAT BPXYN GAERR FXAMX QWOLD BOAHG IXMLP KDBYT TQTSK AELTU WMEWA LTEMW HVZPT SKEEJ NLAFT BQLDH VLPAP AHQCB OAHFG GYXCF WGSBU PXXHM ABIVQ EECTE EBZMG MSWOX BDDUW LPXRP TGUEA TEEXP NHVLE KMDWH AHHUV NGNSA EKOTT LJMGB UBCJH TKNCB JJQVI LDWNA MAHJO SKXBK DRRVI IMSSL ELPAC RRMWB UUGOU ATJDM XASZR AMSGY RVJWA HVVCV QCAIC UITTA HSGPN BCICP LHHPL SKUIV IUIVD HHDDM GHWKM WKYJS KPLIM LMNGP WDGGZ NNTEH KLWEX LPHLT TTESS QTAHV MAWVM WOBJW HFKAW MGGVZ HWAAI GZLPA LIQGZ BYBJK YQTVM VJIUN AMAYR LPVZT KCKLD HHDDC TEEBZ KYBLH KBUIC FRYWF JAHCA EMWHK OBJGZ ICJQH VXBWH MEEAT EAPVW TBZGA HGIXM LPRRQ TOSZA JOFWA WAWRR JDHZS WZDPN BOWOV JFQEF EEMXX QGYIM VJEMP LFWCU ZUREN SAHCA CCGZS JEESA HVGZL PZQKG GZLPQ IVJFQ KRVQI MBPAG ATUAC QOPRK LPRER FYRLP BYVMK SWANA RFHJI CJBMU EMWHJ DMXAS ATLPH LTKNC TTMGM GLWVI AHQCE EGZUG LSVQE EXOEE AHZKL OYWAH CAXKK GVJPI RUWEI XFTTX CNGOG ZLPME AHICN UPWDS CAICT BOSKS ANMYB OYFRU MUDON AJPXQ SSZNH VXPBP OGVCV MWOVJ XFTZT HRRDK BUGIY PASFR SKZNY IVILQ FWWWU XHVWA MUTZM AUUUV PTVXS DCAVI AHWOG XVIPY RUMQ");

string createAlphabetFromKey(string key)
{
    var alphabet = new StringBuilder(key);
    int final = key.Last();
    int c = 1;
    while (alphabet.Length < 25)
    {
        char newChar = (char)(((final - 'A' + c) % 26) + 65);
        if (newChar != 'J' && !alphabet.ToString().Contains(newChar))
        {
            alphabet.Append(newChar);
        }
        c++;
    }
    return alphabet.ToString();
}

var cipher = new BifidCipher();
var pt = "THEQUICKBROWNFOXIUMPSOVERTHELAZYDOG";

List<string> testedKeys = new List<string>();



void work(string text)
{
    if (text.Contains('J'))
        return;
    var anagram = new string(text.Distinct().ToArray());
    if (testedKeys.Count % 1000 == 0)
        Console.WriteLine(testedKeys.Count);
    if (testedKeys.Contains(anagram))
        return;
    testedKeys.Add(anagram);
    for (int i = 1; i <= 10; i++)
    {
        string dec = cipher.Decrypt(cipherText, new StringKey(createAlphabetFromKey(anagram)), i);
        double ioc = IndexOfCoincidence.Calculate(dec);
        if (ioc > 0.052)
        {
            Console.WriteLine($"Key: {anagram}, IoC: {ioc}");
            Console.WriteLine(dec);
            Console.ReadKey();
        }
    }
}

//Console.WriteLine(createAlphabetFromKey("HI"));

foreach (string text in DataTables.Instance.FiveLetters)
    work(text);
foreach (string text in DataTables.Instance.SixLetters)
    work(text);
foreach (string text in DataTables.Instance.SevenLetters)
    work(text);

var c2 = new BifidCipher();
Console.WriteLine();

/*
var cipher = new VignereCipher();

foreach(string t in DataTables.Instance.FourLetters)
{
    var key = new StringKey(t);
    var pt = cipher.Decrypt(cipherText, key);
    double ioc = IndexOfCoincidence.Calculate(pt);
    if (ioc > 0.052)
    {
        Console.WriteLine($"Key: {t}, IoC: {ioc}");
        Console.WriteLine(pt);
        Console.ReadKey();
    }
}*/


//var key = new StringKey("ABCDEFGHIKLMNOPQRSTUVWXYZ");

//var ct = cipher.Encrypt(pt, key, 5);

//Console.WriteLine(ct);

//Console.WriteLine(cipher.Decrypt(ct, key, 5));