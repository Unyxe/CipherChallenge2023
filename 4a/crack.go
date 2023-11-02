package main

import (
	"bufio"
	"fmt"
	"io"
	"os"
	"slices"
	"sort"
	"strings"
)

var words = make(map[int][]string)

func init() {
	f, err := os.Open("words")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	seen := make(map[string]bool)

	br := bufio.NewReader(f)
	for {
		ln, err := br.ReadString('\n')
		if err != nil {
			if err == io.EOF {
				break
			}
			panic(err)
		}
		iterWords(strings.ToUpper(ln), func(word string) {
			if seen[word] {
				return
			}
			seen[word] = true
			words[len(word)] = append(words[len(word)], word)
		})
		words[0] = []string{""}
	}

	for n := range words {
		sort.Strings(words[n])
	}
}

func main() {
	ct := `DEUQJVE IJU UVTSOGE DJUAPXETB, ISTQET UEENU VP ISXE ISD XETB MJVVME JOFMWEOAE PO VIE QPMJAE JOXEUVJGSVJPO SV VISV UVSGE, SOD NB JOXEUVJGSVJPO PF MPASM FJMEU UIPYU VISV VIE POMB SAVJXJVB JO VIE VYP NPOVIU FPMMPYJOG VIE DESVI YETE MEVVETU EZAISOGED HEVYEEO NSJUJE, TPGETU, ISTQET SOD YIJVE. TPGETU APOVJOWED VP VTB VP RWJEVEO VIE FWUU YIJME NSJUJE, JOATESUJOGMB SOZJPWU SHPWV IET QTEAJPWU MJHTSTB, YPTLED ISTD VP GEV VIEN SMM VP VSLE IET APOAETOU UETJPWUMB. JO VIE EOD NSJUJE UEENU VP ISXE MPUV QSVJEOAE SOD VP ISXE APNNJUUJPOED IET PYO JOXEUVJGSVJPO, MED HB VIE FSNPWU QJOLETVPO DEVEAVJXE SGEOAB. J SN OPV UWTE YIB UIE AIPUE VIEN, EUQEAJSMMB GJXEO VIE APUV, HWV JV NSB ISXE TEMSVED VP VIEJT TPGWEU GSMMETB, S OSVJPOSM DSVSHSUE YIJAI APOVSJOED QIPVPU SOD DEUATJQVJPOU PF S MSTGE OWNHET PF LOPYO SOD UWUQEAVED ATJNJOSMU. JV YSU VIE FJTUV PF JVU LJOD, SOD NSJUJE NSB ISXE IPQED VISV JV YPWMD TEXESM VIE JDEOVJVB PF IET JOVETMPQET. VIE AWTTEOV MJHTSTJSO SV VIE NSOUJPO LJODMB GSXE NE SAAEUU VP NSJUJE’U QTJXSVE TEAPTDU, S UETJEU PF DJSTJEU SOD MEVVETU, NSOB PF VIEN EOATBQVED, VISV YETE UVPTED JO VIE PFFJAE HEIJOD VIE FJTEQMSAE JO VIE MJHTSTB. J SN GTSDWSMMB YPTLJOG VITPWGI VIEN SMM, PT SV MESUV VIE POEU VISV UEEN VP HE TEMSVED VP VIJU ASUE, SOD YJMM QPUV SOBVIJOG TEMEXSOV. FPT UVSTVETU, IETE JU VIE TEQPTV FTPN VIE QJOLETVPOU SGEOV SUUJGOED VP VIE PTJGJOSM EORWJTB. J ISXEO’V ISD S AISOAE VP ATSAL VIE AJQIET BEV UP J DPO’V LOPY JF VIE TPGWEU GSMMETB QMSBED S TPME JO VIEJT JOXEUVJGSVJPOU, HWV QETISQU BPW ASO AIEAL VISV FPT NE. S RWJAL JOUQEAVJPO UIPYU VISV VIE MEVVET FTERWEOAJEU NSVAI VIE WUWSM DJUVTJHWVJPO QTEVVB AMPUEMB, UWGGEUVJOG VISV VIJU YSU OPV EOATBQVED WUJOG S UWHUVJVWVJPO AJQIET, UP BPW YJMM OEED VP WUE S DJFFETEOV SQQTPSAI VP ATSAL JV. GPPD MWAL, ISTTB`

	var w []string
	iterWords(ct, func(word string) {
		w = append(w, word)
	})
	slices.SortStableFunc(w, func(a, b string) int { return len(b) - len(a) })
	fmt.Println(w)
retry:
	if i := crack(w, nil); i < len(w) {
		fmt.Println("stuck on", w[i])
		w[i] = ""
		goto retry
	}
}

func crack(w []string, oldSub map[byte]byte) int {
	if len(w) == 0 {
		printKey(oldSub)
		return 1
	}
	cw := w[0]
	stuck := 0
wordLoop:
	for _, pw := range words[len(cw)] {
		sub := make(map[byte]byte)
		used := make(map[byte]bool)
		for p, c := range oldSub {
			sub[p] = c
			used[c] = true
		}
		for i := 0; i < len(cw); i++ {
			if c, ok := sub[pw[i]]; ok {
				if cw[i] != c {
					continue wordLoop
				}
				continue
			}
			if used[cw[i]] {
				continue wordLoop
			}
			sub[pw[i]] = cw[i]
			used[cw[i]] = true
		}
		fmt.Println(pw, len(w))
		printKey(sub)
		stuck = max(stuck, 1+crack(w[1:], sub))
	}
	return stuck
}

func isAlpha(c byte) bool {
	return 'A' <= c && c <= 'Z'
}

func iterWords(s string, f func(string)) {
	for i := 0; i < len(s); {
		for i < len(s) && !isAlpha(s[i]) {
			i++
		}
		j := i
		for j < len(s) && isAlpha(s[j]) {
			j++
		}
		if i < j {
			f(s[i:j])
			i = j
		}
	}
}

func printKey(sub map[byte]byte) {
	var pabc, cabc [26]byte
	for i := range pabc {
		p := 'A' + byte(i)
		pabc[i] = p
		c, ok := sub[p]
		if !ok {
			c = ' '
		}
		cabc[i] = c
	}
	fmt.Printf("key:\n\t%s\n\t%s\n", pabc, cabc)
}
