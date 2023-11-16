package main

import (
	"bytes"
	"fmt"
	"strings"
)

var ct = strings.ReplaceAll("JDEFO IOLWI LONUO NGPYU LAORS MSSTE AETHG IOGTI UHSOL DHUSN YOEDU HATTE TCEDA HIIAL TSETR FTERM AIOMS EOTIT HPOVE RIECE DNBAC HRNOP NKFIE TNSRO SNVIE TAIEL WRESN RSIEL TOPYA EORRP THCHW IIAEB HVENN AEUBE OLLTO AERCT EDNGA IBTEE EWNHL ITENS THEII KECNW AASUN SMTAT EHMII EASHD OMACM SIOIS NDURE FTEIN HRVSI GETAI NSTOF LOWOL IGECN REPOF ITTEE PHROT NIROS EANLS DHTST AHWSC EAOTN UNIIG OFNTU DHENT EQIRN UYHUG TOHAN OIMTU EHSRO SEMWH AAEDN GTAON HTAIR ALBRA SSINA AYPLR IKRTN EOSUS NMTAE BHVEI VELED HTSTA HWSGE AODOR OFHRE BEDTS HEATR IAFES IEULL FLFNC OERPE DYTCM UNOMI AIOCT NBTWS EENHE ETMOH FBTOL WILON UONGP TILEH STEAN TRDTI NIHKE ILWWL EUSBB YRAKB EIGHO NTSCP HEIES VEROR HNETE XFWWT EEKTH ESEOS EMRSO EDLWM DWNEO BTEVU IETAL NULMN AYAGD OCETR CTHAK EIHEC PRNER UDNAH TETHC DEEOA DCANI NRMIP OSTAT EHYUI LOWLI DTFNH CNTEO ETINN STRST EEIGA INMSE PEISL EOULD THTSW AHTOU EHGTI GHMHH VETAB EGOEN IGNBN OUION TWDRF SEIHW SMEAI SNGSI SMTHO EIGMP NIOTN TRASE INHHT DTIEA TNHEI TPRSE HAIAS HWSOK DTCEO ERAHA BUTHO TEIUA STTOO FINME PLYMO ETHYR OGSHU HEOSN DEOEP ATXNO THDNA NRDTO OSHEE SFLOW OLTAT HHTOG TTUHO TNAIS TRLCU AOCUS NLINA VOHIG ARNCR EOUID TYWNM OEQIR NUISI TEWHO TECNM OARPR YAKRB NEODS CRIIC LTSER HAATT HSITE TAIOU TNHRE SEFRE DERTI THOSE IANFN CADII LFIUL FCTTA TYHRG RSOEM NIOET NDNOE IUERL RAIRI LEFEH SASIM IIOBT NAMUW SCLRG HAETA NRHHS UDIBG TNDEA IOCUT CRTME SOTAP EHTRA STHPH RASEE OFRTN OHVLU EAAIN ATONT ENDHE PLIWO CWSTY AOLOW ALHMO SITTG ATAEH FIFET HWSIE ANEGU LAEIH IWTSE THLSE HMANE YAEPH VLNED ANTSL LOESM OFOET EORHM EAUAV LBETE LIMFO MSRTE IBHLR RATAY ANCKK ODWPR ONIEO TCTHA REELS ODDFR ELRSA EADOC NTLIO NAMTE NSHIU ACERN TIWOH SUDLL LAOHM TWIOA OFPYF IDEHS BSNDT ATFND OUHSA MICPI NYAGO MGHUI TBECO JTHTH TAEOL DCUHV ACAEH EEDIV MRORO ELSTH ESEAE OSMUC METOB SLLYE IGHEN TBOSA OKTAE VFCAU BULET AINHV GOSTB AEFRS DOOEI MMTEB UTAOT EREHT AUESS RMIIE ASHDC QAAUR DFIEO HMIRI TOLDW UHVBE AEEIT ENNNE YESLM ARABR SIGTS NOITO GFNYH ELTLW RVOEA UDPLE ATOFR STEOL HCLCI OETNO HETTC TTHIY EEASR WASTH LOEIK TRSHT UYABE SOURW LHVED ABEAL ENETD TREOI NEHSE TSEDO LADTL NHTHE ATRSL TEUIG RINPC WULEO DAEBH VENOW ELETA NRHTE NSHIU ACERN VLATA UINTW OIOLC EUDRA NLTIY AEBHV ENDAE ANEOU GRSTA TSREY UTGBP RAPEH SHRIT ESWSW KAOTT ARHKN THIGE HDERO ILNDS AEETO LCRTW EAERN TMEOU HIVCG ETVON OTNFO IGRAK RBNUT ESPSP CALEI LTOSY HEHSE WODBS WETEE CCRAU UATML EATHD TEADT CRALO FBECU SEORI RGEFO RWSBS AEIDA HNSHM ECETD FROEA DHEUT ISREN URTEN SHIIS TTSRN ETAGH TEWAH ATDTN EHRBB EOEYN VRIET GASIT OENIN DDUTE BRMMB EEETA TRHNB OKOOS EEAWR CULLT AYTLE SONOO SSNIN FIGIC NCLAT AMOUI CLAIS DREIH NWTOO SIPSB EAILG NTAKI MESNS SEEHT HTAEO LDWUW NTHAT EHLEW OSRYA ORFAR FFIOG TTROE FRTNU HRNVE IETGA SITOM IINGT ASHEI YAVLH ERUGB OHHSR TIOEN TLIHT EFEHT OIGTL HPRMT EAETL NNYPI LSOIG ISNHE ETILC OCANN HCSND EAPRA PEHSV NLEEE DNGAI TAPEO SLOIN LFCRE RACAI NITOL OFOOK RADTW ROERI HANYU RGOTO GHHUT TESSH EDESI LPCLA EUTOS IINAE JOMNY NMYIG HLDAO IYETW BSIHS HSEAR RY??????????????", " ", "")

func main() {
	for n := 2; ; n++ {
		fmt.Println(n)
		p := make([]int, n)
		for i := range p {
			p[i] = i
		}
		var permute func(i int)
		permute = func(i int) {
			if i == n {
				var pt []byte
				for i := 0; i+n <= len(ct); i += n {
					c := ct[i : i+n]
					for j := range c {
						pt = append(pt, c[p[j]])
					}
				}
				if bytes.Contains(pt, []byte("MAISIE")) && bytes.Contains(pt, []byte("ROGERS")) {
					fmt.Println(p)
					fmt.Println(string(pt))
					fmt.Println()
				}
				return
			}

			for j := i; j < n; j++ {
				p[i], p[j] = p[j], p[i]
				permute(i + 1)
				p[j], p[i] = p[i], p[j]
			}
		}
		permute(0)
	}
}
