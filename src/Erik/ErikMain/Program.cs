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
using CiphersMain.Ciphers.Hill;
using MathNet.Numerics.LinearAlgebra;

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

var cipher = new HillCipher();
var pt = StringUtils.CipherFormat("XOLIM IHAZE AOVEF RPEKS QOBPP EXEWT LEVNZ ELTOG TTWOU HVREA QDAHI UNHBI ZHIUO DSRVN EYIUJ PHODA XEEIA HKYNI QDVNY SRRUG VRZHD DVNLE ZIXEW TLEQO WLGCB IBNNN IFZLZ OEITG LERAE PWIGT QEGTV IRECE RRTBJ FFRXT LEVNK IHEGT MAASM EHAFC LRTTH DBTCC KUZRV NGALA XGRNG MFEFO WRRRE AQDVA FUBBP EHDBT WOFST FMMVR KCNNX EQTTB TOWLK WVNZT LEVNZ ELTOG TTWOF SZYHA GPVRN NPMII AILHV RWEQF FOKEJ SEIAH URAWW RAMAH KGVBV RNAHO ZILLR AGENN ZWFOX EHOAH VRVOH EASLA QDTIS RRRRT HTPLE TLEFT HAAHA WSSEI AHURW WVNZT LETFJ EFOMH ASQOW LGCBI BNLEL IQNHT OIZER REAGO NAQDL IQNHT VEGED VEAVE ALDFF OFTLE MAXFR RSSKC NNXEW LTRUG VRUCB NBIHU HDHOT IZETT AHQMN NAIBN NNGDA SPPTE RRHDW RAMJU MLKCT IJELE QOGTV NYEWT TFHNW TLEBX PAFSW OBOYT LETIS RRRYA QDMAA SMEQO GTVNY EWTQC LRTTM IWDJP BNPIV DEAAH FOKEJ SPEYT LLAOL TPIWE GTZRI ELTTT XTVHA SVIGC RNNNA YWAEN AWVOH OYKJP VEAIH EPCEA MTLEM ABONW BTATL ECAZE TTAHT TMAAS MEWAL TPBEA WLKWH DHOTI ZEEIA HLERA QDHOM AVNTA VNAHP LJBRA PYQMI IAIGC BNBIH UHDHO TIZEV NAHIE SSPWV NUOYT LEVOM SPLCO SITGF FXEKT LETIS RRRSU GTTLZ HTPSS WEDAW AUWLE VIUOM THAYF RRBTV OAGAT MAZBA WAWVR HDBNE AQDAH TTAHA SKOFL JGRDK WVIGT LENNN ADSSS DDEAH EQDHO FEVEN UENHD HOAHE ATCHA SOZOE YWEVT WONAS AWUZI GSBTP RTTLE KTHAN ANLGS HDCAW EVUMT LEVIT OHNDA PEMTV RWRAM AHVRV OHEAS LAQDK IRYTI SRRRR TBNNN AYZHL HDDTF JEVEW TLETI SRRRA CZLPE VTWOG THTLE KIRYT OWLKW VNSMI IAIWS HETTH AQDAH CYAEV ENRBT VNZTH TPLSH VRAHT TTOWL KWVNG ANAKS WSEMR NHOYT LEQOW LGCBI BNAHC YKOFL EBYUN AMLXT OAECT PMTLE SIQDT FJEKT LEVES SBNAH MIRAX DBTZH KWHDA HTTMA LYTFA HVRRR EAQDV AFUBB PEBTQ MOWVR MISFC CYFKK WSBOB NAWSS ZVVRQ OIVKC XELIP CBNRE VTWOJ WBTAT LESRE ASIBO RALYT RUMGC BNREV THDEI AHAHJ FFRKE ZIWSA SBIWL ROGTX NKWDH XTLEI RUGVR CKREP TLEPO YKOWV RJFKK FBNTB TWEQM MUYLS KPLEG DVRNP ICKIE ANWSL TRDBN TTXTL EMAOW OKBOP TLEWR UUZWS SPOHN WTPBI EMPGS HDZYA HIEMP VRLSK OBKVN GAMTL EKIRY TISRR RKMYY FEFOK EJSNN PMIIA IAWVR ZVKCB IESTF WRUUE BZBCO CSPLP EJSVU MTLEP OYKOW VRFBI UNHBI FSMAW LBAVC LESAQ DBTRO WSGTW EQMTI OEJYA HTTAH CYAEV EPOAH VETET THDJY TOZLH DVNNN ACSSQ MIIAI WSBAM KXRIU QDVNP OYKGR WSVRV ABIBN ZHIUO DHAZE MAHEB TDOKS JBPET OYHVR HOHPH TTTPE SSLSA MSOYT LEFAO ELTLE RNNLG SHDPE MTVRW RAMMA ASMEH OFOKE JSROW SGTZH HDGUJ HTINH UBNTH NBITI CAPCR AMKAH VRWSH OMHVR LIRRG IBISA WLPHV VKGHT HOUOB NNFIE WLSKA WEAVE NLGSX TGSZL DITGA HASKY LTVRZ BNTLT TLYNH TKUBT XTLEV EPHVV XTLEF ROGVN LLPEM TVRBN KYHEC KVUYF IUQDN NRNTR NPXEF CDPGI ZMIIA IWSLI RRYAQ DAIPC MIBIJ RTTLE RAVIG TVRWS BITGK IWHVR PHVVE AMTCC LEWTH AOVVR AIBNT OKTLE KRIIR EWSHO KRJLX TQEXN KWNFA HCYRE HDLEA PNNLI EIWLD OLTGO QEAHV NOIGT LEPOK STOLU BPFOB AMLMO ZEKTL EAEOK RNKHR RPY");
var key = Matrix<double>.Build.DenseOfArray(new double[,] { { 1, 1 },{ 0, 1 } });

Console.WriteLine(cipher.Decrypt(pt, key));

JSONWriter.WriteToFile("9A", cipherText, "key", cipher.Decrypt(cipherText, key), "Hill");
