from pathlib import Path

dict = {}
total = 0
raw=""

if __name__ == "__main__":
    inPath = """C:\Erik\CMS\CipherChallenge2023\\4.txt"""#input("Read> ").replace("\"","")
    outPath = """C:\Erik\CMS\CipherChallenge2023\src\Erik\FrequencyAnalysis\Data\Quadgram.csv"""#input("Write> ").replace("\"","")
    with open(inPath,"r") as file:
        raw = file.read()
    for line in raw.split("\n"):
        if (line != "\n"):
            pair = line.split(" ")
            if (len(pair) != 2):
                continue
            if (int(pair[1])>10):
                dict[pair[0]] = int(pair[1])
                total += int(pair[1])
    with open(outPath,"w") as file:
        for key in dict.keys():
            file.write(f"{key},{dict[key]/total}\n")