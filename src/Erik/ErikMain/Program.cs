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

string cipherText = StringUtils.CipherFormat("ENEAO TAQKD UQXNI IVBQZ RAXNI ILOQA XTMNQ AUWOH CPGHI CAQSC OGYHG NTTWU HPAPA RHHKM NNMGP PMLQA GHVQU PILOP SPLAU PWQKG GRFAV BEDRL RAIBA QAIDN RFQDD NUFUM OBAQU VIKEE HHMNQ AENEA QONTO VKGSB IHQPE NXATU MCOPK ZTAOT KPKHP OWHET VBYTW MSLID SBFAD SMDYT BPXTG MSQXN AWFAV BEDRL RASPP BGHFN PFQPX OXTLA MXAQL KNDZP ILNWA QSLGK OHVBM IPPTA QAKPY TVGMX AQQUH HXNQO KHQOP NEKXA KZNTQ VNLHH EMUHY HGNTT WUHPQ UQELS IDSBS GTIIH QPETA KWHNL WMCYV BKPKP WYSLW GDSWU FAWTW HSBVO TLENK ZNYWF PYHPN IIDWH SHNAX NVBIL NHRSS OKHQO QPLAS ZWWQE AMAKZ PAIHH SBOZK ZQFKK LACFX YDTFA SNPHS QOBSQ LAWMN NMOWC XTWGR TNBVB AQAKI QXNSB WBPHW GKKLA GMMLT NRTWY MANAW QKGVM WHXAS QKGXA KERAQ RSFVI MWNHU IIQWZ ENSUW ZENID SPRBQ GCMFA WPLAZ WAQAI HHSQP NAKMC OPHPM DQKFA UHSKX NVMBY FHAIU MOBAQ TGLBS LVBEI WFEAV ONBEM FHSBO ZVBIL NHRSS OKHQZ VBHHK CUWIK MDYTB PAEAD SQPBG HIDSP FAVBI IMXAQ UPTIY NRIXT SZSKS LVBSQ XTIKU QIQII UPVQX NSPRP WZADX OXTVB ILKPZ WRPQS FADSM AXTMB OPVBA IEMWB SHQGU NMILN DSVBS KVBSX CFTII BMRMI NWSLV BAIIK KNNNQ AHNRP QSQGT NNDOW VBAIW HETXT QFDSM BWFQM LAGPK GRTHH VBAII DOPPH EAGPM LQEXA SPFAV BAXRP QSQGU NSLHP XOSSS LKNIL KNSLH HELEN SPNNS OBYFH SCFAM NUGMD NEVII PMRSL GKOHQ ULTRA WFVQT ANSWU KPYTV GOWLA XTRAA KIIRP HYWHN BLSWM ONWXV BAXKG RSSGN DILWB PHGKO HOMWF LTVME MWBUW IKXOF EHNLN QOWHE MCPLA XATUH NIQNB EDWYQ OAQBY OWIKO QEIAK SLWHL ARDRT WHLTV BAQDT OQQNV LSLMA XTLKP SRHLN WGHKO HSIKK LAQFW OYSRK ASRSK PAIWZ OGYHG NTTWU HHXNQ AHHKM OPEIN SEAVB SIWYK YNAPK MLIZY TTZNS DTSBP OOHAX SRVBS KVZOW SLKPS GTIIH QPFAD SETII VBSIW YKYNA OROPF LQAKB QOIIE NSPOP MXMLQ KKZWO OHUMO BAQVZ RHHHK MFAVB AXRPQ SVBII LSMIO NQELT SPOWK PKATT BYHPN BLSWM QPLAS ZWWTT VBAQV BIDFS EAVBA QHPKQ FAWPL AKDUY AQLNU VRPQS ETSBV ANWAQ SLLAF AANNN WOSLN BVBMX MDXLI DMPTL QEWWN BVBAL QHHQI DSBET QEMXS LVBSK VBEIQ PIIWB MDQDV ONBFS EACFT IANSQ QHRMI ZWHET AKVIK DWMVI SKMIZ HDHWY QOAQQ YXOQA AQWOQ HAHCB QOIIW BPHTA QANBL SXTSP LAKDU YAQLN WOPBH PSGQO ISWBR AOZNS QABYP BALMI LNDSA WRPQS NBLSW MLAET WOOQH NMCOP VBILR HLNWZ FAIHQ BENSK FAVBI CSSSH RAWGQ GWMFA VBICS SAKTT OZSLK DXFQH UFWYT GIQWH CEWZW PLAQE AMAKC PPPEL KDVYG HXANE VBMQT LQEWW NBVBA XOPHQ VBSLM LVBYT TAIAK NIITN QKKGU CKZMF ADAIB PMIFE OPKPF BHBSS QGXNO TAKLL SHOGB PIZAI AIWYT GIQCF TIIPW BNDET MDFWS CKDVI IBHPS FSWSK VBMCQ HWHKK LANSS NAQMG WQIZH HKFRA NBRPU TIQTB OPLTW YIQVB ACNHA NUCID SBOFS LFNXN QRXTM DHPSL VBSKG WIKHH XAWYR PWAID LTWML AQIQE EAQYH YUWMI PKIIS PLASF RBKDT TNAQR WZTAQ AVBMC OPLTW UFAAN ELQAI QGBRA SPONS LSQIL TNMFS CYTTA SFWQW HXTQF DSKPB YIIVB ICRPX ALLEI AQIIX NXTMN QAXAS COZVB ALQNY HSQRP TNVAX TADVB SKCFL LMXAQ CHRAH HVBEL IKUWH HKYUW IKWHO PHPKX WHTNL LVBAL QHKIP AIQLA FAIPE LQZWP LAXTI DSPLA XTYTV GQHRI OPXPQ ZWWWH XTNII SSCWP OHBPU QOQHP MLQAH HKPFN OKMIL NKKLA QIQEE AXKHN FIDNW OASQE VZSLV BSKVB SLMLV BYTTA NAIAK NIITN QAWZP AIIQP KZOZF AMNRI AKIIT HZNEL POWHR SQGWT ADAES LEDAK TBWFQ MLAAM RBIIQ EAMAK YHSSE NWFHS RPVMS QLACN WFRIS LVBSC NVIQW BFTWB PHQUL SAKNB SBVAN WAQZW IKMDR SCESK SLEMV HOWKP SBIHQ PXAAI CYXAW HXTDS MDVBM CISWP FAWPL ASFRB YTTAK DUYAQ CPQNP POWRP QSRHI IIDHH DSWOG BSKKH QOFAU HGBKO QERZV BSCQO XMENW MOHMX FNQUO QHHXN TYWYI IMNQA WGLHX TNLXT MNNAQ KAQNA WBDSW OTTXN KUGWR PQSUP CPRPQ AAQQY RAOMW FLTVM MARFS EHFKD UYNWA QQGUT BPUCL TWOHH KMFAV BAIGB KOFAD SETII HHCDN RSLWG RTKGC YQOLA ENSKK ZOQEI AKSLI DQPSQ FAVPE LRTSP QBRFQ EMAXN KZNTQ AKZSB WBQOL ASYQA HHKFK KLASF RBAKT TOZHH FYOPK PWHET SBVAN WAQSL HNAKM CTIQR OQEIA KSLSK TTFHN BMXKN IIEAQ ERZHH GFUMO BAQWO QPLAS FRBXA NDAQV ZRHHH KMFAW PKZUV RPQSM AWOII RPHYV ZSSOW NWAQK ZUOEI WQSKK HQOFA VBAXR PQSLS MIONQ ELTSP PPTNQ ASHBF GKOHV BELRS SOKHN AKKAQ RMIZR LVMTL SBOZI DSBRM WOSSQ YVBHH WBOZV BSKGH GBKOE TKDVT SLWHR QMFHP KOLAM XKNII EAFBL ASBIH QPAEX TAIUM OBAQT AVOII XNSPO WKPKA TTBYH PNBLS TTQAW HNTHH TNHHV BILNH RSSOK HNAWP LANTQ GWYSB IHQPV BHHKC CFTIE NDSUT ILEDA SRSNB XOIZI SVPID SWSQL AXTFN NTKDU YAQSG POQCT TSZWO IDANN SEZNT FHAQE MVHQP ADUQE NXTTT QAWGW HQUQE AMAKC BFADS QDDSS BTNQA MAXTM BOPKP KDWMK ZWMCW MLVMI DSBFA DSVBR PHYVB AKMNS FWQKG CYSGT IENPO UQSCV PLKXP XTQYV OYTVF SLRNV GQPQD DSKPI KKNNN QAIKV BMIGN TTWYI DTTVB AQVBI DVBMI ACMDO WRAWY FASHN GCHRA YTCPR HWFXN SOKPH BMRIQ RLQOV BMIIK VPHWD NAKVO QDYFZ PEINS SZOZM LIZID ENDSW USFRB HHVBI LNHRS SOKHO VKPFA KDUYA QCPLA OPGBH HMDWZ LLEIH HASQH KLEIP PKPOP CBQOL ASZWW CYVBI KNTND ROOTA QNBQU FSCDU QKPAX OPHQP HIEKN ENPOL ANEET KZQAV BAXQH EHIDM IQEOZ HHQUW FOHUV FAXND SUFHP UVAKR AENSZ ENWOQ NOWKP KOLAS FRBWZ PZAQQ EAMAK ZWLAQ ZADKF RAQUQ EAMAK ZWFHO KAISE PZKNE NQZVP SGNDI LWBPH HHTNS OHHQU CYNDH BMRAI SSMLU MIDLT RTQOT ZOPVB ALQHH QWHET LKNDZ PEQQZ XNSBQ OLAEN QIWZW HWUID MNKKA QIKWC TNMFS CQOAQ YSQSM CHHSL SUVBI QTNXP XNNBQ EQYTN WBPHW OONIQ NHSPL AYNXT WHRHX TSZRP WONHP NFLYT YBOPM XAQID MBAKW HNWMD TLMFS QOPSQ UQQON NFSQY QRVBS KSHIQ QGTWM DXLVB AIVBA QSCTA NTXYS QKDWM LANTQ AVBIL NHRSS OOPUV KGCEM COPVB AICYN DSKRS IKVBM RSLAI PHWOT TXNIB OWRMI ZVBSX MAXTK DVMVL FANTH FFBHN IIVNN HRSSO KHQOL AOQPN ELIPV ZRPQS ETXOI MTNQO FNNSQ AHBMR ACFWI IHHWO XMSOK HPOVB SKQFR ABPKG TIANE QXASP RNWOA SQEVZ SKXMW OLKQA ENSBM AXNSP QPLAS LVLSK KHQGF DGNTT WYIDW OMLIZ AQTAQ ASFRB SYQAA QUVIL IDQGV NPHUP NHVBM CWQUQ ALWQD TMANA THMLW OUPCP PPFAR LKP");

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

/*var cipher = new BifidCipher();
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
Console.WriteLine();*/

var cipher = new BifidCipher();

const string ct = "PWECZWWRRXMBQZCPXUEKXIBUOYXLEVEBAVIRRNOCHEEIRWRTXEINMEIFWOYXKSVABEOYEXAVTEZDNQRYBQACGUOEXAKSQBXSZNMXLELCASGETERLRUIQEOGXPCZKSSKVXNEKKPBSXERLRSHNBEWUWLIELEIRSSOXDIPQFHMYYRLUSBQEXOXYINSDGRITSNDSQGFOFUNQDQRUASYOGYIQSVPXTFPROKPQFWESYRNILMGWMOVRDIDWLHMONEQESGQYSWSWAQGGIFWSMERFLFETWEMRFBQLGRZMEDSQPRREXRYNKPQNNEEPTXKQALEGNNSOLUAISYGYXUOAQLLRSTEECPQEOERYSHBAQBUTRTLEQEEGPYRSSNEKDPKOVSVWNQKOQZPSTYLGZDSEEQUYIMSESXFTRTBTEDBXWRUNSEGFETRRQRYIUQCWXNYQBDMSQNBOEXCLGIGHFOQUHGDWEURONWMFEZMWQRVWKPLGNNRECWPSIUVSOXNNRPMQCTSXYTNUEMQZSWXZMGBUHMREXOMMQUBZFUXICRQEACOYREVUBPWNVZUYSICNLFXAFFNBFBISUMZNQGAPZYRRAXQMPGGRYAMSKNOLSGTWETMRWDWXTNONASUEITTNTNZBMQEANTYRMSERRFTRYNAMGNPTXQWSUBMGCONGRZUQHLQYDOEYFLCAERENORKUHDZSXOHAQPLEPPUSPQOELEIVREFXQPIWUUUNOMLEPLQEEVEYGACSLTRPTSGBCIMATRCZUSKMGXNIMRDWITGONAWSNIRPQTXOYTOEGDQVRRYNKNQNBUSXTPPBACNAQPQYQCPCSWSRNOGHHIBRRTUUOABETRFXIKLGBCQEFPFZTAQDKWSYUWIDARACUTONMMLCNTZEGTMDKEVZTDSPPOSIKRWTXESKUIMWWRDTRAUQOWTXOWFEMHQQRXOYELUAMTYGYFBGKSEPANYRGIBPVRAZRPNRNBDSYSABQFKGEYQZAWMQECEWYTRSEGOASLSRSTBBBBLDKQLECVVLSENXHFKCRKPGGOSRQDZUQYTAODCLDREZMSYYIKNAAXUTYWGZAKLSXRDSQECEEYTRSLGNGCZSRQUACPSLRNRWSRAUELQFXNDDQPNQVXSZRXORREBTTEOXTLSMKWETXNGBOEINQVTXIZLCZNAOXATLYBROOMZUEWQCDRODKUIPEKVCAPCZRNDZSWWTANKMCQEWXETRDBPFARUSMFBNICCZTXZRDFALOOVEFRBCQDEZHYRTBKAUDRDQEHMLGCGMSNOQNIIUDZMASSAZBAISNMSXAEIUVROXNNRGNSDTVZNSOHPMOWTYAWLFIQEEDXYRWTECCYDRQUPVUICUNVXNQOCZMXTGARMDQOPWSYWYUMROBXTORXSXUNIXXXOXQNCRKYZFZWIDAGGCUPGRLMLVPEXSZRHIQHACDEMDFAEETRSGSRNKTAFWIWSQDDPCVSHQUABEBSILTXYXYACGFWTHRQEVPVBRVWXMQELCSYTDQFALXAETSWTTIZNIKXVZMDULWSVGEYDPUVDFENOSQRQFVNGYTNTRRWQIRYYFRYBZCCHPAPMCGRKBATOOQFQAICPYTAANLSLELETEHEQCSRNYSSDFLNBUZFTXXATRRFNOTEOZKGVRZNNNTAQCULGOSMSNZDQPAQUZRRMEUZTASSAOMZPNUOANTQSQKZFPZUEMLSMPNETXAFBQINSZQQHDPENIUSOYXXIUUDANQNSFVSIEQNSTRYNCAIZZFSXNBMFFDMARQSBIPLIQQBSAUZBLCNAREEKLPSCIONWSVXIKKNYXPUSTPSSTOYWFBAKIDYEDQTFNNOEWWHWRGVSLFRATSMBUBOEZXQVTIELVLXDDWSECPQANAEYEIQNCTXYZFWABRSPFXTOYVEGAQAGREXSEBTATTZRSLPMCIORXHEGAWCAVFYXDSQMPATPFSFUIQEBSOYTZUMSMNMOTFGLSPQDOEYYURVPEPOIQSYPCKBEVSUTTQGRSUPRYQEFDSRPUTFTNCBCMDHDOYMDNXBSRWYXXLQECBYDOROLVEIQDOTXMMDKIBXOTRRVXIDSNXASIACLEBFRCTZTEEIURRTXNBVXQERNXYSFAQREQEXTWNQPKPYZUUSUDQGNXSYATSVNUSDYZSTIAQGSXDUNSLUEOAYNPDFBALREVUKTYLISIADAOXDVPORAPRWUTCGVQCHRPYAULACPMHRNRQCSMEYUMYXVQDSUPYHMGAGAMQTRDXYCUQYCUKNFEUDVBSMSNMSICPLBUGUERIAGQMMDQZXQPQCMSRYQWIEAEVANFSOEEIKARTXDSUUSSVXMEXPQGLQCMREYSALEIVDSOXPBOIQSMWXKTQGIDZNGNOASIILROXXUTEQBCPWCLSRQDBGTYUNARIUQCMXNYQWABGIAAXKNRGBAGRRRREPACLEITHSOXUBENRNXNDEENNCGGEWPKKMIRFWXETWMGPZBYNRNMLEBPCEEPAHIPKNUCATZSQSAVRQFFNSNUIDQZSXHDDNUPKNYNNKEMQLERTYEDDBPDCRUSOYACBCMEHDOYGZDQUNQUXSQEPAIPSYLGABSBIYPYQNAWGSQUTBDPPIBNRUUUSXKIPRRVQIOECPMSHNROTORLUBIEEXMGBIQDLCNYREASWESEWYYPQKKSUYPUWELPXPLESNEQVSQSBNSXOPPHCGEUOPYRDURKOSYONTNIRLGYXOBQQNIAAZSGYFVQPMRNSSTMNRXLIZUWRDBSSESRTPHDDGBSETZPYRLFBUDEDZXHPUURAQNXTRLENEQEGFRNGIUSEATXORQGQUCNAYNTREGPSEMRNWELRQCSEYYSAEMVEDWWORFLSMSRETXTMCTANYPWSISMSBITFSCNRUIKDYNRGBGNRKSRZYUXVAGICOFTQUPICNISNETNSELEIYREFXQUELCYNSOENPQDASYYUR";

var pt = StringUtils.CipherFormat("It was a bright cold day in April, and the clocks were striking thirteen. Winston Smith, his chin nuzzled into his breast in an effort to escape the vile wind, slipped quickly through the glass doors of Victory Mansions, though not quickly enough to prevent a swirl of gritty dust from entering along with him.\r\n\r\nThe hallway smelt of boiled cabbage and old rag mats. At one end of it a coloured poster, too large for indoor display, had been tacked to the wall. It depicted simply an enormous face, more than a metre wide: the face of a man of about forty-five, with a heavy black moustache and ruggedly handsome features. Winston made for the stairs. It was no use trying the lift. Even at the best of times it was seldom working, and at present the electric current was cut off during daylight hours. It was part of the economy drive in preparation for Hate Week. The flat was seven flights up, and Winston, who was thirty-nine and had a varicose ulcer above his right ankle, went slowly, resting several times on the way. On each landing, opposite the lift-shaft, the poster with the enormous face gazed from the wall. It was one of those pictures which are so contrived that the eyes follow you about when you move. BIG BROTHER IS WATCHING YOU, the caption beneath it ran.\r\n\r\nInside the flat a fruity voice was reading out a list of figures which had something to do with the production of pig-iron. The voice came from an oblong metal plaque like a dulled mirror which formed part of the surface of the right-hand wall. Winston turned a switch and the voice sank somewhat, though the words were still distinguishable. The instrument (the telescreen, it was called) could be dimmed, but there was no way of shutting it off completely. He moved over to the window: a smallish, frail figure, the meagreness of his body merely emphasized by the blue overalls which were the uniform of the party. His hair was very fair, his face naturally sanguine, his skin roughened by coarse soap and blunt razor blades and the cold of the winter that had just ended.\r\n\r\nOutside, even through the shut window-pane, the world looked cold. Down in the street little eddies of wind were whirling dust and torn paper into spirals, and though the sun was shining and the sky a harsh blue, there seemed to be no colour in anything, except the posters that were plastered everywhere. The blackmoustachio'd face gazed down from every commanding corner. There was one on the house-front immediately opposite. BIG BROTHER IS WATCHING YOU, the caption said, while the dark eyes looked deep into Winston's own. Down at streetlevel another poster, torn at one corner, flapped fitfully in the wind, alternately covering and uncovering the single word INGSOC. In the far distance a helicopter skimmed down between the roofs, hovered for an instant like a bluebottle, and darted away again with a curving flight. It was the police patrol, snooping into people's windows. The patrols did not matter, however. Only the Thought Police mattered.\r\n\r\nBehind Winston's back the voice from the telescreen was still babbling away about pig-iron and the overfulfilment of the Ninth Three-Year Plan. The telescreen received and transmitted simultaneously. Any sound that Winston made, above the level of a very low whisper, would be picked up by it, moreover, so long as he remained within the field of vision which the metal plaque commanded, he could be seen as well as heard. There was of course no way of knowing whether you were being watched at any given moment. How often, or on what system, the Thought Police plugged in on any individual wire was guesswork. It was even conceivable that they watched everybody all the time. But at any rate they could plug in your wire whenever they wanted to. You had to live -- did live, from habit that became instinct -- in the assumption that every sound you made was overheard, and, except in darkness, every movement scrutinized.\r\n\r\nWinston kept his back turned to the telescreen. It was safer, though, as he well knew, even a back can be revealing. A kilometre away the Ministry of Truth, his place of work, towered vast and white above the grimy landscape. This, he thought with a sort of vague distaste -- this was London, chief city of Airstrip One, itself the third most populous of the provinces of Oceania. He tried to squeeze out some childhood memory that should tell him whether London had always been quite like this. Were there always these vistas of rotting nineteenth-century houses, their sides shored up with baulks of timber, their windows patched with cardboard and their roofs with corrugated iron, their crazy garden walls sagging in all directions? And the bombed sites where the plaster dust swirled in the air and the willow-herb straggled over the heaps of rubble; and the places where the bombs had cleared a larger patch and there had sprung up sordid colonies of wooden dwellings like chicken-houses? But it was no use, he could not remember: nothing remained of his childhood except a series of bright-lit tableaux occurring against no background and mostly unintelligible.\r\n\r\nThe Ministry of Truth -- Minitrue, in Newspeak -- was startlingly different from any other object in sight. It was an enormous pyramidal structure of glittering white concrete, soaring up, terrace after terrace, three-hundred metres into the air. From where Winston stood it was just possible to read, picked out on its white face in elegant lettering, the three slogans of the Party").Replace("J","K");
var key = new StringKey(createAlphabetFromKey("BLAH"));

Console.WriteLine(cipher.Encrypt(pt, key, 10));


//var key = new StringKey("ABCDEFGHIKLMNOPQRSTUVWXYZ");

//var ct = cipher.Encrypt(pt, key, 5);

//Console.WriteLine(ct);

//Console.WriteLine(cipher.Decrypt(ct, key, 5));