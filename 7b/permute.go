package main

import (
	"bytes"
	"fmt"
)

var ct = "AIYNAGKRCTELUOISGAEELLSONOKONSNAAOTOWDSMSEAATOEPNCEDTLVUNTRLIDDTHHEPTEFAIADGOSWREMUIREINMOUSRSGSIEHNYARSRESNORROEDRELEONPESEEHUAEMAIOCRBRMEIISFELTNIRTEYLVAOTTTESROTRNWAOIQIIKNEANTOAETNTTIEOETNTFUNIDFEETMSRTMHEOCDIEEAYECYFIOHESAPECNRLDWDNSIILNTGEIOAADSEEBSEDOUASLITRTESROSOSTALEEIAYAGLNYOESOEAROOAMEOSNISGAIAHALNSTECITTEUCDRSIWLGMNITEMPENNEDWVUFYLLSNVYRDEEELTRTALODPISSDPRSNTYLASEDEPTRPODNCICBNARNAYHSPOAALVYLEOARRDILNSSYIIECOADEUEETEAPADSAPBREPOLSTIFLECCIVERSAEDOOCWRSGOOEUENNOCLQEFEESNRRCARDQOSAACRRPLNIEHSTEBEMTERSDNLYATREOTNMERTNELNLAIUITFEENTGIFLISWDENCMSE"

func main() {
	for n := 2; n < len(ct); n++ {
		if len(ct)%n != 0 {
			continue
		}
		m := len(ct) / n
		buf := make([]byte, 0, len(ct))
		for i := 0; i < n; i++ {
			for j := i; j < len(ct); j += n {
				buf = append(buf, ct[j])
			}
		}
		go crack(fmt.Sprint(n, "x", m), string(buf))
	}
	select {}
}

func crack(id string, tct string) {
	for n := 2; ; n++ {
		fmt.Println(id, n)
		p := make([]int, n)
		for i := range p {
			p[i] = i
		}
		var permute func(i int)
		permute = func(i int) {
			if i == n {
				var pt []byte
				for i := 0; i < len(ct); i += n {
					for j := 0; j < n; j++ {
						c := byte('?')
						if k := i + p[j]; k < len(ct) {
							c = tct[k]
						}
						pt = append(pt, c)
					}
				}
				if bytes.Contains(pt, []byte("STYLES")) {
					fmt.Println(id, n, p, string(pt))
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
