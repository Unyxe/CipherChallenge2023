package main

import (
	"fmt"
	"strings"
	_ "embed"
)

var ct = strings.ReplaceAll("ENEAO TAQKD UQXNI IVBQZ RAXNI ILOQA XTMNQ AUWOH CPGHI CAQSC OGYHG NTTWU HPAPA RHHKM NNMGP PMLQA GHVQU PILOP SPLAU PWQKG GRFAV BEDRL RAIBA QAIDN RFQDD NUFUM OBAQU VIKEE HHMNQ AENEA QONTO VKGSB IHQPE NXATU MCOPK ZTAOT KPKHP OWHET VBYTW MSLID SBFAD SMDYT BPXTG MSQXN AWFAV BEDRL RASPP BGHFN PFQPX OXTLA MXAQL KNDZP ILNWA QSLGK OHVBM IPPTA QAKPY TVGMX AQQUH HXNQO KHQOP NEKXA KZNTQ VNLHH EMUHY HGNTT WUHPQ UQELS IDSBS GTIIH QPETA KWHNL WMCYV BKPKP WYSLW GDSWU FAWTW HSBVO TLENK ZNYWF PYHPN IIDWH SHNAX NVBIL NHRSS OKHQO QPLAS ZWWQE AMAKZ PAIHH SBOZK ZQFKK LACFX YDTFA SNPHS QOBSQ LAWMN NMOWC XTWGR TNBVB AQAKI QXNSB WBPHW GKKLA GMMLT NRTWY MANAW QKGVM WHXAS QKGXA KERAQ RSFVI MWNHU IIQWZ ENSUW ZENID SPRBQ GCMFA WPLAZ WAQAI HHSQP NAKMC OPHPM DQKFA UHSKX NVMBY FHAIU MOBAQ TGLBS LVBEI WFEAV ONBEM FHSBO ZVBIL NHRSS OKHQZ VBHHK CUWIK MDYTB PAEAD SQPBG HIDSP FAVBI IMXAQ UPTIY NRIXT SZSKS LVBSQ XTIKU QIQII UPVQX NSPRP WZADX OXTVB ILKPZ WRPQS FADSM AXTMB OPVBA IEMWB SHQGU NMILN DSVBS KVBSX CFTII BMRMI NWSLV BAIIK KNNNQ AHNRP QSQGT NNDOW VBAIW HETXT QFDSM BWFQM LAGPK GRTHH VBAII DOPPH EAGPM LQEXA SPFAV BAXRP QSQGU NSLHP XOSSS LKNIL KNSLH HELEN SPNNS OBYFH SCFAM NUGMD NEVII PMRSL GKOHQ ULTRA WFVQT ANSWU KPYTV GOWLA XTRAA KIIRP HYWHN BLSWM ONWXV BAXKG RSSGN DILWB PHGKO HOMWF LTVME MWBUW IKXOF EHNLN QOWHE MCPLA XATUH NIQNB EDWYQ OAQBY OWIKO QEIAK SLWHL ARDRT WHLTV BAQDT OQQNV LSLMA XTLKP SRHLN WGHKO HSIKK LAQFW OYSRK ASRSK PAIWZ OGYHG NTTWU HHXNQ AHHKM OPEIN SEAVB SIWYK YNAPK MLIZY TTZNS DTSBP OOHAX SRVBS KVZOW SLKPS GTIIH QPFAD SETII VBSIW YKYNA OROPF LQAKB QOIIE NSPOP MXMLQ KKZWO OHUMO BAQVZ RHHHK MFAVB AXRPQ SVBII LSMIO NQELT SPOWK PKATT BYHPN BLSWM QPLAS ZWWTT VBAQV BIDFS EAVBA QHPKQ FAWPL AKDUY AQLNU VRPQS ETSBV ANWAQ SLLAF AANNN WOSLN BVBMX MDXLI DMPTL QEWWN BVBAL QHHQI DSBET QEMXS LVBSK VBEIQ PIIWB MDQDV ONBFS EACFT IANSQ QHRMI ZWHET AKVIK DWMVI SKMIZ HDHWY QOAQQ YXOQA AQWOQ HAHCB QOIIW BPHTA QANBL SXTSP LAKDU YAQLN WOPBH PSGQO ISWBR AOZNS QABYP BALMI LNDSA WRPQS NBLSW MLAET WOOQH NMCOP VBILR HLNWZ FAIHQ BENSK FAVBI CSSSH RAWGQ GWMFA VBICS SAKTT OZSLK DXFQH UFWYT GIQWH CEWZW PLAQE AMAKC PPPEL KDVYG HXANE VBMQT LQEWW NBVBA XOPHQ VBSLM LVBYT TAIAK NIITN QKKGU CKZMF ADAIB PMIFE OPKPF BHBSS QGXNO TAKLL SHOGB PIZAI AIWYT GIQCF TIIPW BNDET MDFWS CKDVI IBHPS FSWSK VBMCQ HWHKK LANSS NAQMG WQIZH HKFRA NBRPU TIQTB OPLTW YIQVB ACNHA NUCID SBOFS LFNXN QRXTM DHPSL VBSKG WIKHH XAWYR PWAID LTWML AQIQE EAQYH YUWMI PKIIS PLASF RBKDT TNAQR WZTAQ AVBMC OPLTW UFAAN ELQAI QGBRA SPONS LSQIL TNMFS CYTTA SFWQW HXTQF DSKPB YIIVB ICRPX ALLEI AQIIX NXTMN QAXAS COZVB ALQNY HSQRP TNVAX TADVB SKCFL LMXAQ CHRAH HVBEL IKUWH HKYUW IKWHO PHPKX WHTNL LVBAL QHKIP AIQLA FAIPE LQZWP LAXTI DSPLA XTYTV GQHRI OPXPQ ZWWWH XTNII SSCWP OHBPU QOQHP MLQAH HKPFN OKMIL NKKLA QIQEE AXKHN FIDNW OASQE VZSLV BSKVB SLMLV BYTTA NAIAK NIITN QAWZP AIIQP KZOZF AMNRI AKIIT HZNEL POWHR SQGWT ADAES LEDAK TBWFQ MLAAM RBIIQ EAMAK YHSSE NWFHS RPVMS QLACN WFRIS LVBSC NVIQW BFTWB PHQUL SAKNB SBVAN WAQZW IKMDR SCESK SLEMV HOWKP SBIHQ PXAAI CYXAW HXTDS MDVBM CISWP FAWPL ASFRB YTTAK DUYAQ CPQNP POWRP QSRHI IIDHH DSWOG BSKKH QOFAU HGBKO QERZV BSCQO XMENW MOHMX FNQUO QHHXN TYWYI IMNQA WGLHX TNLXT MNNAQ KAQNA WBDSW OTTXN KUGWR PQSUP CPRPQ AAQQY RAOMW FLTVM MARFS EHFKD UYNWA QQGUT BPUCL TWOHH KMFAV BAIGB KOFAD SETII HHCDN RSLWG RTKGC YQOLA ENSKK ZOQEI AKSLI DQPSQ FAVPE LRTSP QBRFQ EMAXN KZNTQ AKZSB WBQOL ASYQA HHKFK KLASF RBAKT TOZHH FYOPK PWHET SBVAN WAQSL HNAKM CTIQR OQEIA KSLSK TTFHN BMXKN IIEAQ ERZHH GFUMO BAQWO QPLAS FRBXA NDAQV ZRHHH KMFAW PKZUV RPQSM AWOII RPHYV ZSSOW NWAQK ZUOEI WQSKK HQOFA VBAXR PQSLS MIONQ ELTSP PPTNQ ASHBF GKOHV BELRS SOKHN AKKAQ RMIZR LVMTL SBOZI DSBRM WOSSQ YVBHH WBOZV BSKGH GBKOE TKDVT SLWHR QMFHP KOLAM XKNII EAFBL ASBIH QPAEX TAIUM OBAQT AVOII XNSPO WKPKA TTBYH PNBLS TTQAW HNTHH TNHHV BILNH RSSOK HNAWP LANTQ GWYSB IHQPV BHHKC CFTIE NDSUT ILEDA SRSNB XOIZI SVPID SWSQL AXTFN NTKDU YAQSG POQCT TSZWO IDANN SEZNT FHAQE MVHQP ADUQE NXTTT QAWGW HQUQE AMAKC BFADS QDDSS BTNQA MAXTM BOPKP KDWMK ZWMCW MLVMI DSBFA DSVBR PHYVB AKMNS FWQKG CYSGT IENPO UQSCV PLKXP XTQYV OYTVF SLRNV GQPQD DSK", " ", "")

func main() {
	for n := 1; n < 100; n++ {
		fmt.Println(n, avg(mapp(ioc, slice(ct, n))))
	}
}

func slice(s string, n int) [][]byte {
	a := make([][]byte, n)
	for i := 0; i < len(s); i++ {
		a[i%n] = append(a[i%n], s[i])
	}
	return a
}

func ioc(s []byte) float64 {
	freq := make(map[byte]int)
	for _, c := range s {
		freq[c]++
	}
	total := 0
	sum := 0
	for _, n := range freq {
		total += n
		sum += n * (n - 1)
	}
	return float64(len(freq)) * float64(sum) / float64(total*(total-1))
}

func mapp[S, T any](f func(S) T, a []S) []T {
	b := make([]T, len(a))
	for i := range b {
		b[i] = f(a[i])
	}
	return b
}

func avg(a []float64) float64 {
	sum := float64(0)
	for _, x := range a {
		sum += x
	}
	return sum/float64(len(a))
}
