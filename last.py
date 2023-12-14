from collections import Counter
ciphertext = "HHIZR KHHXH XCFWL WJHIC YFPAX FHHZD VZLWJ HREXL CGWPP XUWSK EEQTP WDSCA ICHHZ DHVPQ NGAEU CNUAH VQJOV ILWJH VZCEL PLTLD NNNHR RPTQT AHXQE EUCGZ LPRFW QQUGZ WAVOW KGZCQ KKZNY ITMMM ASMQW APRPN IBHKL TRIYY QTTHH UWPLP THWHK GVITG HAWOA WVDGZ HALPJ RQTVI OWZGI CORHH ZDBPB JGKEF JOFWX QLPLT RIFMS KAHWO MYWOB JVXPX TZLEJ UEELE LPHKB UWKBP YRLPU IORVP LQICQ TRVQJ HVLEN APTQI PDBZD KKMZR IMEWA OVZAH NACEW EPRLO REGKA HXQBY BJWAP RPNIB HKVPG THAVI NAUQY WAEHH ZDWAR EFJTH VZVIA HASCC WABUZ GICOR FJAHT IVMJN VOXBL ETHFT LCKBI QRVWO EABOL DYWNA KWFWV MOUAT BPXYN GAERR FXAMX QWOLD BOAHG IXMLP KDBYT TQTSK AELTU WMEWA LTEMW HVZPT SKEEJ NLAFT BQLDH VLPAP AHQCB OAHFG GYXCF WGSBU PXXHM ABIVQ EECTE EBZMG MSWOX BDDUW LPXRP TGUEA TEEXP NHVLE KMDWH AHHUV NGNSA EKOTT LJMGB UBCJH TKNCB JJQVI LDWNA MAHJO SKXBK DRRVI IMSSL ELPAC RRMWB UUGOU ATJDM XASZR AMSGY RVJWA HVVCV QCAIC UITTA HSGPN BCICP LHHPL SKUIV IUIVD HHDDM GHWKM WKYJS KPLIM LMNGP WDGGZ NNTEH KLWEX LPHLT TTESS QTAHV MAWVM WOBJW HFKAW MGGVZ HWAAI GZLPA LIQGZ BYBJK YQTVM VJIUN AMAYR LPVZT KCKLD HHDDC TEEBZ KYBLH KBUIC FRYWF JAHCA EMWHK OBJGZ ICJQH VXBWH MEEAT EAPVW TBZGA HGIXM LPRRQ TOSZA JOFWA WAWRR JDHZS WZDPN BOWOV JFQEF EEMXX QGYIM VJEMP LFWCU ZUREN SAHCA CCGZS JEESA HVGZL PZQKG GZLPQ IVJFQ KRVQI MBPAG ATUAC QOPRK LPRER FYRLP BYVMK SWANA RFHJI CJBMU EMWHJ DMXAS ATLPH LTKNC TTMGM GLWVI AHQCE EGZUG LSVQE EXOEE AHZKL OYWAH CAXKK GVJPI RUWEI XFTTX CNGOG ZLPME AHICN UPWDS CAICT BOSKS ANMYB OYFRU MUDON AJPXQ SSZNH VXPBP OGVCV MWOVJ XFTZT HRRDK BUGIY PASFR SKZNY IVILQ FWWWU XHVWA MUTZM AUUUV PTVXS DCAVI AHWOG XVIPY RUMQ".replace("\n", "").replace(" ","")
# ciphertext = ciphertext.replace("AH", "*")
# ciphertext = ciphertext.replace("LP", "+")
# ciphertext = ciphertext.replace("WA", "-")
# ciphertext = ciphertext.replace("EE", "1")
# ciphertext = ciphertext.replace("HV", "2")
# ciphertext = ciphertext.replace("GZ", "3")
# ciphertext = ciphertext.replace("IC", "4")
# ciphertext = ciphertext.replace("HH", "5")

def remove_duplicates(text):
    return ''.join(ch for i, ch in enumerate(text) if ch != text[i-1] or i == 0)

print(remove_duplicates(ciphertext))

pairs = [ciphertext[i:i+2] for i in range(0, len(ciphertext), 2)]

pair_frequencies = Counter(pairs)
print(len(pair_frequencies))

print("len", len(ciphertext))

mapping = {}
unique_char = 'A'
ciphertext_mapped = ""

#print(pair_frequencies.most_common(26))

c = 0
for pair in pairs:
    if c % 2 != 0 or pair_frequencies[pair]<=5:
        continue
    if pair not in mapping:
        mapping[pair] = unique_char
        unique_char = chr(ord(unique_char) + 1)
    ciphertext_mapped += mapping[pair]

#print(ciphertext)
print(ciphertext_mapped)

total_pairs = sum(pair_frequencies.values())
index_of_coincidence = sum((count * (count - 1)) / (total_pairs * (total_pairs - 1)) for count in pair_frequencies.values())
print(index_of_coincidence)