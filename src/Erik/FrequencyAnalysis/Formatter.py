import json
import os

dict = {}
total = 0
raw=""

def bar(percentage, bar_length=50, filled_char='█', empty_char=' '):
    filled_length = int(round(bar_length * percentage))
    bar = filled_char * filled_length + empty_char * (bar_length - filled_length)
    return f'\r|{bar}| {round(percentage*100,2)}%'

if __name__ == "__main__":
    inPath = """C:\Erik\CMS\CipherChallenge2023\src\Erik\FrequencyAnalysis\Data\words_dictionary.json"""#input("Read> ")
    outPath = """C:\Erik\CMS\CipherChallenge2023\src\Erik\FrequencyAnalysis\Data\EnglishWords"""#input("Write> ")
    length = 16
    with open(inPath,"r") as file:
        data = json.load(file)
        files = []
        for i in range(length):
            files.append(open(os.path.join(outPath, "Eng"+str(i+1)+".csv"),"w"))

        print("Writing to files...")
        count = 0
        for item in data.keys():
            if (len(item) < length):
                files[len(item)-1].write(item + "\n")
            if count % 10000 == 0:
                print(bar(count/len(data)), end="")
            count+=1     
        
        for i in range(len(files)):
            files[i].close()
