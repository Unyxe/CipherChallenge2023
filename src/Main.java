import java.io.File;
import java.io.FileNotFoundException;
import java.util.Arrays;
import java.util.Hashtable;
import java.util.Scanner;
import java.util.concurrent.atomic.AtomicBoolean;

public class Main {
    static final String abc = "abcdefghijklmnopqrstuvwxyz";

    static String[] bigramsstr = new String[676];
    static String[] trigramsstr = new String[17556];
    static String[] quadgramsstr = new String[389373];
    static int[] bigramsnum = new int[676];
    static int[] trigramsnum = new int[17556];
    static int[] quadgramsnum = new int[389373];
    static Hashtable<String, Integer> quadgrams = new Hashtable<String, Integer>();
    static long N2 = 0;
    static long N3 = 0;
    static long N4 = 0;
    static final double[] oneLetterFreq = {
            0.084966,
            0.020720,
            0.045388,
            0.033844,
            0.111607,
            0.018121,
            0.024705,
            0.030034,
            0.075448,
            0.001965,
            0.011016,
            0.054893,
            0.030129,
            0.066544,
            0.071635,
            0.031671,
            0.001962,
            0.075809,
            0.057351,
            0.069509,
            0.036308,
            0.010074,
            0.012899,
            0.002902,
            0.017779,
            0.002722
    };

    static boolean[] ready;
    static String[] previousBatch;
    static boolean clockSwitch;

    static String path = System.getProperty("user.dir");


    public static void main(String[] args) throws FileNotFoundException {
        ImportNGrams();

        //String cipher = "AREIR JKZVJ JJKPY RJVZL JKEAZ VKKUE KVNEJ LBGCB MVBGR ADPPC LIGYE VZKUE KNRNC LYASV BAEBP KUVBT CSBCK RVBKU RMCYL ZRKUE KPCLJ RBKZR PCLEI RIVTU KKUEK VKUEJ JCZRM EYLRE JEJFR GVEYR AVKVC BCSFC RJNCI XDLKV GCLYA BCKJR REBPK UVBTI RZEIX EDYRE DCLKV KKUEK ZVTUK ROFYE VBKUR FIRJR BGRCI KURAR EKUCS KURPC LBTZE BPCLS CLBAV BKURY VDIEI PVKVJ ESVBR JFRGV ZRBEB AVKNE JNVKU JCZRI RYLGK EBGRK UEKVE KKEGX RAKUR DVBAV BTEJV AVABC KROFR GKKCS VBAEB PKUVB TIRZE IXEDY RKURI RVBPC LGEBV ZETVB RZPJL IFIVJ RKURB KCAVJ GCMRI KUREK KEGUR ABCKR GYREI YPNIV KKRBV BEGVF URIEB AGEIR SLYYP GCBGR EYRAD RKNRR BKURY REKUR IEBAK URRBA DCEIA JRMRB KURBV EJJLZ RAKUV JKCDR EFLDY VJURI JKIVG XKCFI CZCKR KURRA VKVCB TVMRB KURFI CZVBR BGRCS RBGIP FKVCB VBKUR KEYRD LKGCB JLYKV BTNVK UZPSI VRBAJ VBKUR DCCXK IEARB CBRCS KURZU EAURE IACSJ LGUEG CBGRV KEBAV GCLYA BCKSV BAEBP IRGCI ACSEB EAMRI KVJVB TGEZF EVTBI RSRII VBTKC JLGUE GLIVC JVKPE KKUVJ FCVBK VSRYK VJUCL YAEKY REJKE KKRZF KKCAR GVFUR IKURZ RJJET REBAH LVGXY PAVJG CMRIR AKUEK KUREL KUCIU EALJR AKURM RIPZV YAGCB MRBKV CBCSE JUVSK GVFUR IGYRE IYPVB KRBAR AKCDR DICXR BKURS VIJKY VBRIR EAIRG RBKRM RBKJU EMRZE ARVKG YREIR IKUEB RMRIK CZRKU EKVEZ VBZCI KEYAE BTRIE BAKUR IRJKG CBKEV BRAZL GUKCE YEIZZ RRJFR GVEYY PKURI EKURI GYLZJ PIRMR IJREG ICJKV GNUVG UIREA ZLIAR IKUCL TUSCI KURYC BTRJK KVZRV EJJLZ RAVKK CIREA IRAIL ZNUVG UGELJ RAZRZ LGUGC BSLJV CBNUR KURIC IBCKK UVJGC BGREY RAZRJ JETRF CVBKJ KCKUR LBSCI KLBEK RAREK UCSPC LIVBK RIYCF RIVJB CKEFF EIRBK KCZRD LKVKU VBXPC LEIRI VTUKK UEKVK JFIRJ RBGRJ UCLYA DRJLS SVGVR BKKCR BGCLI ETRKU RFCYV GRKCI RCFRB KURGE JRVNV YYSCI NEIAE GCFPC SKUVJ YRKKR IKCTR KURIN VKUZP SVBAV BTJKC ZPSIV RBAKC ZUEIF RIEJG UVRSC SFCYV GRURJ UCLYA UEMRK URFCN RIEBA VBSYL RBGRK CACJC NVKUZ PDRJK NVJUR JZELI VGRAI ZELIV GRNUV KRZA";
        String cipher = "EATI WCEVA, UCN EVE KUA KITVBAAJ SAK CB? V TJJLZA KUAP RITRXAE KUA RVFUAIJ, HLK FAIUTFJ KUAP JKILSSYAE NVKU NUTK KUA YAKKAI KCYE KUAZ. PCL BAAE KC XBCN GLVKA T HVK THCLK KUA LJ KC LBEAIJKTBE NUTK NTJ SCVBS CB. ZP CNB IATEVBS VJ KUTK KUA CNBAI CD KUA YVHITIP NUAIA KUA HCEP NTJ DCLBE NTJ FYTBBVBS CB ZCLBKVBS T RTZFTVSB KC SAK AYARKAE TJ SCMAIBCI CD KUA JKTKA HLK NTJ NCIIVAE KUTK TBP JRTBETY ZVSUK LBEAIZVBA UVJ RUTBRAJ. UA JAAZJ KC UTMA HAAB CB SCCE KAIZJ NVKU KUA YCRTY RUVAD CD FCYVRA, TBE JVBRA KUTK VJ TYJC TB AYARKAE FCJVKVCB, KUAP NVYY UTMA HCKU LBEAIJKCCE NUTK NTJ TK JKTXA. V ELS TICLBE TBE DCLBE KUTK KUA RUVAD, KCZ UTIFAI, UTE T IAFLKTKVCB TJ TB UCBAJK ZTB, HLK UVJ WLESAZABK ZVSUK UTMA HAAB VBDYLABRAE HP UVJ DIVABEJUVF NVKU ICSAIJ, TBE KUA DTRK KUTK KUA FCYVRA NAIA IAYLRKTBK KC VBMAJKVSTKA ZVSUK UTMA UTE ZCIA KC EC NVKU ZTBFCNAI JUCIKTSAJ KUTB TBP LBELA VBDYLABRA. V RUARXAE KUAVI TIRUVMAJ TBE KUAIA VJ JCZA AMVEABRA KUTK UTIFAI RTIIVAE CLK GLVAK ABGLVIVAJ CD UVJ CNB, FAIUTFJ TDKAI UA IARAVMAE KUA YAKKAI DICZ ICSAIJ. V NCBEAIAE VD KUTK NTJ ELA EVYVSABRA, HLK VK ZVSUK TYJC HA HARTLJA UA IARAVMAE T JKITBSA YAKKAI DICZ T YCRTY ECRKCI NUC JAAZAE KC UTMA HAAB TJJVJKVBS KUA YVHITIVTB, ZTVJVA JKPYAJ, NVKU UAI CNB VBMAJKVSTKVCB VBKC KUA RTJA. V TZ JKVYY LBJLIA NUP JUA NTJ VBMCYMAE. JUA NCIXAE VB ICSAIJ’ UCLJAUCYE TBE NTJ KUA CBA NUC DCLBE KUA HCEP, HLK VK ECAJ JAAZ T YVKKYA THCMA UAI FTP SITEA KC HA YTLBRUVBS TB VBMAJKVSTKVCB VBKC KUA RVIRLZJKTBRAJ CD KUA EATKU. KUA RLIIABK CNBAI CD KUA UCLJA IAZAZHAIJ UAI SITBEDTKUAI KTYXVBS THCLK ZVJJ ZTVJVA VB DCBE KCBAJ. JUA NCIXAE UAIA LBKVY JUA NTJ BC YCBSAI THYA KC EC JC TBE NTJ T EVYVSABK YVHITIVTB NUC HLVYK KUA RCYYARKVCB DICZ SCCE KC SIATK. (VK VJ JKVYY AORAYYABK, TBE V UTMA BCK UTE KVZA KC JKTIK T RICJJNCIE CI T JLECXL JVBRA V EVJRCMAIAE VK!) FAIUTFJ JUA NTJ LFJAK KUTK JCZACBA UTE HICXAB KUA JTBRKVKP CD UAI ECZTVB TBE WLJK NTBKAE KC LBEAIJKTBE NUP. JUA ZLJK UTMA HAAB NCIIVAE THCLK KUA JARLIVKP CD KUA RCYYARKVCB TBE VK NCLYE UTMA HAAB DILJKITKVBS KUTK KUA FCYVRA EVE BCK TFFATI MAIP VBKAIAJKAE. JUA JAAZJ KC UTMA TJXAE KUA YCRTY ECRKCI ZTLIVRA NUVKA KC VBMAJKVSTKA KUA MCYLZA DCLBE VB KUA EARATJAE’J SITJF; SVMAB UVJ DVBEVBSJ, KUTK NTJ T SCCE RTYY. V TZ BCK JLIA NUTK UVJ YAKKAI KAYYJ LJ, HLK CBRA PCL UTMA HICXAB KUA ABRIPFKVCB CB VK FAIUTFJ PCL RTB YAK ZA XBCN NUTK PCL KUVBX. V UCFA PCL EVEB’K ZVBE ZA ABRIPFKVBS KUVJ BCKA. V KUCLSUK PCL TBE KUA KITVBAAJ ZVSUK ABWCP HIATXVBS VK. VK VJ SCCE FITRKVRA DCI KUA YAKKAI DICZ EI ZTLIVRA NUVKA ZE! TYY KUA HAJK, UTIIP";
        System.out.println(DecryptSubstitution(cipher, "enofdpqbrstuzwvyxcgahijklm"));
        System.out.println(cipher);
        //String known_key = "d---a---r--------e--------";
        String known_key = "e---d---r----------a------";
        String startKey = GetStarterKey(cipher, known_key);
        System.out.println(startKey);
        //String bestKey = GeneticAlgorithm(cipher, startKey,known_key ,100, 10000);
        String bestKey = GeneticAlgorithmMultithread(cipher, startKey,known_key ,100, 10000, 12);
        //System.out.println(DecryptSubstitution(cipher, bestKey));
    }

    public static String[] DoOneGen(String enc, String key, int keysPerGen, String known_key){
        String[] gen = GenerateGen(key, keysPerGen, known_key);
        double bFitness = -1000000000;
        String bKey = "";
        for(int j = 0; j < keysPerGen;j++){
            double fitness = FitnessFunction(DecryptSubstitution(enc, gen[j]), false, false, true);
            if(fitness > bFitness){
                bFitness = fitness;
                bKey = gen[j];
            }
        }
        return new String[]{bKey, bFitness+""};
    }
    public static String GeneticAlgorithmMultithread(String enc, String startKey, String known_key, int gens, int keysPerGen, int numberOfThreads){
        enc = RemoveAnyNonAbcChars(enc);
        enc = enc.substring(0, 200);
        previousBatch = GenerateGen(startKey, numberOfThreads, known_key);
        ready = new boolean[numberOfThreads];
        clockSwitch = false;
        for(int i = 0; i < numberOfThreads;i++){
            int finalI = i;
            String finalEnc = enc;
            Thread thread = new Thread(()->{
                int id = finalI;
                boolean lastClockSwitch = clockSwitch;
                System.out.println("Thread " + id + " has started!");
                //ThreadJob(previousBatch, enc, id, keysPerGen, known_key);
                while(true) {
                    //System.out.println("Thread " + id + ": new gen!");
                    String key = previousBatch[id];
                    String bKey = DoOneGen(finalEnc, key, keysPerGen, known_key)[0];
                    previousBatch[id] = bKey;
                    //System.out.println("Gen from thread "+id+":    "+bKey+"     " + DecryptSubstitution(finalEnc,bKey));
                    ready[id] = true;
                    //System.out.println(lastClockSwitch);
                    int it = 0;
                    while (clockSwitch == lastClockSwitch) {
                        it++;
                        if(it % Integer.MAX_VALUE == 0){
                            System.out.print("");
                        }
                    }
                    lastClockSwitch = clockSwitch;
                }
            });
            thread.start();
        }

        for(int i = 0; i < gens;i++){
            int it = 0;
            //waiting for ready
            while(true){
                boolean f = false;
                if(it%1000000000==0){
                    System.out.print("");
                }
                for(int j = 0;j < numberOfThreads;j++){
                    if(!ready[j]) {f = true;break;}
                }
                if(!f){
                    break;
                }
                it++;
            }
            //System.out.println("Gen " + i + " is finished!" );
            ready = new boolean[numberOfThreads];
                 //changing the batch
            String bKey = "";
            {
                String[] gen = previousBatch;
                double bFitness = -1000000000;
                for(int j = 0; j < numberOfThreads;j++){
                    double fitness = FitnessFunction(DecryptSubstitution(enc, gen[j]), false, false, true);
                    if(fitness > bFitness){
                        bFitness = fitness;
                        bKey = gen[j];
                    }
                }
                //previousBatch = GenerateGen(bKey, numberOfThreads, known_key);
            }
            System.out.println("Gen " + i + " is finished! Best key: " + bKey + "    " + DecryptSubstitution(enc, bKey) );

                 //Switching the clock
            clockSwitch = !clockSwitch;
        }
        return "";
    }
    public static String GeneticAlgorithm(String enc, String startKey, String known_key, int gens, int keysPerGen){
        enc = RemoveAnyNonAbcChars(enc);
        enc = enc.substring(0, 200);
        String bestKey = startKey;
        for(int i = 0; i < gens;i++){
            String[] genRes = DoOneGen(enc, bestKey, keysPerGen, known_key);
            bestKey = genRes[0];
            String bFitness = genRes[1];
            System.out.println("Gen " + i + ": " + bFitness + "    " + bestKey + "    " + DecryptSubstitution(enc, bestKey));
        }
        return bestKey;
    }

    public static String[] GenerateGen(String key, int keyPerGen, String known_key){
        String[] gen = new String[keyPerGen];
        gen[0] = key;
        for(int i = 1; i < keyPerGen;i++){
            gen[i] = MutateKey(key, Math.random()<0.3?2:1, known_key);
        }
        return gen;
    }
    public static String MutateKey(String key, int mutC, String known_key){
        String resKey = "";
        for(int i = 0; i < mutC;i++){
            int ind1 = (int) (Math.random()*26);
            int ind2 = (int) (Math.random()*26);
            while(ind1 == ind2 || known_key.charAt(ind1)!='-' || known_key.charAt(ind2)!='-'){
                ind1 = (int) (Math.random()*26);
                ind2 = (int) (Math.random()*26);
            }
            if(ind1 > ind2) {
                int b = ind1;
                ind1 = ind2;
                ind2 = b;
            }
            resKey += key.substring(0, ind1) + key.charAt(ind2) + key.substring(ind1 +1, ind2) + key.charAt(ind1) + key.substring(ind2+1);
            key = resKey;
            resKey = "";
        }
        return key;
    }
    public static double FitnessFunction(String str, boolean do2, boolean do3, boolean do4){
        str = RemoveAnyNonAbcChars(str).toUpperCase();
        double totalFitness = 0;
        if(do2){
            for(int i = 0; i < str.length()-2;i++){
                String subs = str.substring(i, i+2);
                int occ = 0;
                for(int j = 0; j < bigramsstr.length;j++){
                    if(subs.equals(bigramsstr[j])){
                        occ = bigramsnum[j];
                        break;
                    }
                }
                occ++;

                totalFitness += Math.log((double) occ /N2);
            }
        }
        if(do3){
            for(int i = 0; i < str.length()-3;i++){
                String subs = str.substring(i, i+3);
                int occ = 0;
                for(int j = 0; j < trigramsstr.length;j++){
                    if(subs.equals(trigramsstr[j])){
                        occ = trigramsnum[j];
                        break;
                    }
                }
                occ++;
                totalFitness += Math.log((double) occ /N3);
            }
        }
        if(do4){

            for(int i = 0; i < str.length()-4;i++){
                String subs = str.substring(i, i+4);
                int occ = 0;
                Integer res = quadgrams.get(subs);
                if(res != null){
                    occ = res;
                }
//                for(int j = 0; j < quadgramsstr.length;j++){
//                    if(subs.equals(quadgramsstr[j])){
//                        occ = quadgramsnum[j];
//                        break;
//                    }
//                }
                occ++;
                totalFitness += Math.log((double) occ /N4);
            }
        }
        return totalFitness;
    }

    public static boolean IsBiggerString(String str1, String str2){
        int val1 = ((int)str1.charAt(0)-65)*26*26*26 + ((int)str1.charAt(1)-65)*26*26 + ((int)str1.charAt(2)-65)*26 + ((int)str1.charAt(3)-65);
        int val2 = ((int)str2.charAt(0)-65)*26*26*26 + ((int)str2.charAt(1)-65)*26*26 + ((int)str2.charAt(2)-65)*26 + ((int)str2.charAt(3)-65);
        return val1 > val2;
    }
    public static void ImportNGrams() throws FileNotFoundException {
        {
            File myObj = new File(path+"/2.txt");
            Scanner myReader = new Scanner(myObj);
            for (int i = 0; i < bigramsstr.length; i++) {
                String l = myReader.nextLine();
                String str = l.split(" ")[0];
                int occ = Integer.parseInt(l.split(" ")[1]);
                bigramsstr[i] = str;
                bigramsnum[i] = occ;
                N2 += occ;
            }
            myReader.close();
        }
        {
            File myObj = new File(path+"/3.txt");
            Scanner myReader = new Scanner(myObj);
            for (int i = 0; i < trigramsstr.length; i++) {
                String l = myReader.nextLine();
                String str = l.split(" ")[0];
                int occ = Integer.parseInt(l.split(" ")[1]);
                trigramsstr[i] = str;
                trigramsnum[i] = occ;
                N3 += occ;
            }
            myReader.close();
        }
        {
            File myObj = new File(path+"/4.txt");
            Scanner myReader = new Scanner(myObj);
            for (int i = 0; i < quadgramsstr.length; i++) {
                String l = myReader.nextLine();
                String str = l.split(" ")[0];
                int occ = Integer.parseInt(l.split(" ")[1]);
                quadgramsstr[i] = str;
                quadgramsnum[i] = occ;
                quadgrams.put(quadgramsstr[i], quadgramsnum[i]);
                N4 += occ;
            }
            myReader.close();
        }
    }

    public static String DecryptSubstitution(String enc, String key){
        enc = enc.toLowerCase();
        key = key.toLowerCase();
        String dec = "";
        for(int i = 0; i < enc.length();i++){
            int ind = abc.indexOf(enc.charAt(i));
            if(ind == -1){
                dec += enc.charAt(i);
            }else{
                dec += key.charAt(ind);
            }
        }
        return dec.toUpperCase();
    }

    public static void SolveFreqAnalysis(String enc, String known_cipher){
        String key = GetStarterKey(enc, known_cipher);
        System.out.println(key);
        System.out.println(DecryptSubstitution(enc, key));
    }
    public static String GetStarterKey(String enc, String known_cipher){
        double[] results = FreqAnalysis(enc);
        String key = "";
        for(int i = 0; i < results.length;i++){
            if(known_cipher.charAt(i) != '-'){
                key += known_cipher.charAt(i);
                continue;
            }
            int bestMatchInd = -1;
            double minDiff = 2;
            for(int j = 0; j < oneLetterFreq.length;j++){
                double diff = Math.abs(oneLetterFreq[j] - results[i]);
                diff += Math.random()/200;
                if(diff < minDiff && known_cipher.indexOf(abc.charAt(j))==-1 && key.indexOf(abc.charAt(j))==-1){
                    minDiff = diff;
                    bestMatchInd = j;
                }
            }
            key += abc.charAt(bestMatchInd);
        }
        return key;
    }
    public static double[] FreqAnalysis(String enc){
        enc = enc.toLowerCase();
        String cipher = RemoveAnyNonAbcChars(enc);
        double[] results = new double[26];
        for(int i = 0; i < cipher.length();i++){
            results[abc.indexOf(cipher.charAt(i))]+= (1.0);
        }
        for(int i = 0; i < results.length;i++){
            results[i]/=enc.length();
            //System.out.println(abc.charAt(i)+ ": " + results[i]);
        }
        return results;
    }
    //public static

    public static String RemoveAnyNonAbcChars(String str){
        str = str.toLowerCase();
        String res = "";
        for(int i = 0; i < str.length();i++){
            if(abc.indexOf(str.charAt(i)) != -1){
                res += str.charAt(i);
            }
        }
        return res;
    }
}