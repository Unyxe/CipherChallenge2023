from pathlib import Path

dict = {}
total = 0
raw=""

if __name__ == "__main__":
    inPath = input("Read> ").replace("\"","")
    outPath = input("Write> ").replace("\"","")
    with open(inPath,"r") as file:
        raw = file.read()
    for line in raw.split("\n"):
        if (line != "\n"):
            pair = line.split(" ")
            if (len(pair) != 2):
                continue
            dict[pair[0]] = int(pair[1])
            total += int(pair[1])
    with open(outPath,"w") as file:
        for key in dict.keys():
            file.write(f"{key},{dict[key]/total}\n")