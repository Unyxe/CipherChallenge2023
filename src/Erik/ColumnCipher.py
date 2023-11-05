import re
from termcolor import colored

def split_and_pad(input_string, n, padding_char=' '):
    padding_needed = 0 if len(input_string) % n == 0 else n - (len(input_string) % n)    
    padded_string = input_string + padding_char * padding_needed
    return [padded_string[i:i+n] for i in range(0, len(padded_string), n)]

text = "ROREP MRTFO AMISS SEISI SETYL ILTHE YRBRA GAOUR HSENT OCAVE TEMPL EHEDT QNIRE EIUIR ADSAN WOREN OPINA OISIT ERNTO TTPOR FRHEI NIIND EHGST SEYAR RAUMM BDISE WWELO LUEWO AHDBE OTPPY FETAK EHURT TSRIN ITRUC FIONS RPYOU TREFE MROTE ETINA NITHE ITVES OIGAT TWNNO EWHEN DLWOU ARBEG LUTEF CETOR NEEIV IFOTI OICAT HTNSO CEATW TEANS OYTLE CCURA ATOUN OBTHE SADYW OTTHA UOFAY NANGM ORAPP TAXIM WTELY TYENT YEHRE OSEAR TILDW NOHBL RIDHA DAAND NIIST EVCTI ORSCA LSNHI HCEFT ONEEK EBMEM TFRSO UOHEH LOSEH OPDRE KDRTE NINOW AHGOR AGVIN CENYR CEOLL ONTIO TEFME IWING MITHH ACBHE DERRI PANOP OSERS SAITW OPNOT LBSSI SEETO ILTAB SISHH TNIDE TAITY STTHA OETAG EEFTH RINQU HTYWI ECANY NIRTA TLTYA HGHOU TSTHE FOYLE HSHIS NAOES MEDTH EUARQ SIOFH EKPOC CTTWA ERHWE POEUR USEAN TSGGE HTING WEATH LEASW VALTR DEELL UQCEN SEIRI EHATT LALOC IRCAR OCAGE YNMPA DLYIE EHEDT ROINF OIMAT TANTH DAHEH VIARR ANEDO HCCOA NMFRO ROEWY DEKTH FEAYB IHORE YDSBO IDWAS EVSCO HDRED AMISI SAGEW NINOT OROUR GSGUE REALL WTYBU EDEAD DEDTH IRESC NOPTI ICAND ALRCU TITED RUTOO OYNEW FFRKO AEICE BDIDE DEYTH NIIST EVCTI RUNAT HTEOF NUEYO SNGMA AEAPP ECRAN GAOUR WSENT BAERE FOLET WOOLL RTHIS ABAIL EOCKT ISLLI DNSLA ERWHE DAHEH VIARR TNEDO PSHES ASARI CPSHI IYARR AENGN WTRLY DNOHU APRED GNSSE RFERS UOOMS PMTHA NETON DNGLA CEFTH SNABI RFTAF LLECA APOUR GNSSE RSERA REATH ULREC SESIV REUFF RFING CIOMS SSKNE UMFOR TFCHO YOHEV RGAGE DRECO MOSFR HSTHE NIIPP PMGCO HSANY AHOWT RTTHE LLAVE DNEDU EHERT SENAM ELTAN ELYIS TDSAN IHHAT SSSPA AHAGE NEDBE FDPAI AYORB SKBOO NIHOP MSTHE AHALL IHMPS LIREV OELAG ERFAL DRSFO ELHIS NSSWA ONOTK TOWNT COHEL NOALC UBSTA BYLAR EHUTT SKBOO AWHOP IMSOF NINOR SETER EBTAS SESID LAASM PTLBU TIROF TEABL IERAD UCNIN LUNAB AWAIT OSSAL EPSUS ODCTE DAFTR NIING SMITE AHWIT DEMOR UOUBI VOSPR CNENA WEEIW NUERE TEABL EVOIN AGSTI RUTEO EJSUB RUCTF WRTHE UOITH RETAL TGTIN OOHEB LLKSE OOERT TNURI TSERE ROSOF EWNOW PEHAV DEAUS NETHE YRQUI OYJIF EVUHA ERANY TNASO ILOBE HTEVE EHATT FKBOO NDOUN OTEXT OBTHE DADYH ITPAR RACUL EUVAL AHORT RUTYO ELCOL NOCTI ULINC TIDES HWEMS IMICH AHGHT TTVEA ETRAC AEDTH TNTTE FOION REINT OINAT OBNAL UMOKS REGGL NESTH GIITM WEHTB EHORT DNXTE HTING EVEIN AGSTI TNTIO EVOCO BERTH ESOOK SRLLE HTBUT DIEEV WEENC EVEHA EHGAT OSRED SIFAR CYONL MUIRC TNSTA NAIAL CEDTH OSOST TRFFU NEHER IRQUI UOESC SELDB ATUBS LANTI".replace(" ","")


#knownKey = list("-------")
#           R O R E P M R T F O A  M
knownKey = [4,3,0,1,2,9,7,5,6,8,10,11,-1,-1,12,-1,-1]

max = 40

print(len(text))
nums = range(30,50)
for num in nums:
    chunk_length = int(len(text)/num)
    key = [-1 for i in range(chunk_length)]
    tempIndex = 0
    for i in range(len(key)):
        if i < len(knownKey) and knownKey[i] >=0:
            key[i] = int(knownKey[i])
        else:
            while tempIndex in key or tempIndex in knownKey:
                tempIndex+=1
            key[i] = tempIndex
    letterCount = 1
    chunks = split_and_pad(text,chunk_length , " ")
    plain = ""
    for chunk in chunks:
        for c_index in range(len(chunk)):
            index = key.index(c_index)
            letter = chunk[index]
            col = "white"
            if letter == "M":
                col = "red"
            elif letter == "A":
                col = "green"
            elif letter == "S":
                col = "blue"
            elif letter == "I":
                col = "yellow"
            elif letter == "E":
                col = "cyan"
            plain += colored(letter, col)
            if letterCount % num == 0:
                plain += colored(",\n","black")
            letterCount +=1
            if letterCount > max:
                break
        if letterCount > max:
                break
    print(num)
    print(plain)
    input()