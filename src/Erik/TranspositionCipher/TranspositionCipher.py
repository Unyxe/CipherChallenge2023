alphabet = list("abcdefghijklmnopqrstuvwxyz")
key = [int(i) for i in "10342"]

def split_and_pad(input_string, n, padding_char=' '):
    padding_needed = n - (len(input_string) % n)
    
    padded_string = input_string + padding_char * padding_needed
    return [padded_string[i:i+n] for i in range(0, len(padded_string), n)]

def transpositionCiper(plainText, key):
    blockLength = len(key)
    blocks = split_and_pad(plainText, blockLength)
    encBlocks = []
    for block in blocks:
        encBlock = [' ' for i in range(blockLength)]
        for (i, char) in enumerate(block):
            index = key[i]
            encBlock[index] = char
        encBlocks += encBlock
    return "".join(encBlocks)

'''Converts a encryption key into a decruption key'''
def convertKey(key):
    newKey = [' ' for i in range(len(key))]
    for (k,v) in enumerate(key):
        newKey[v] = k
    return newKey


if __name__ == "__main__":
    cipherText = transpositionCiper("Hello World!", key)
    decryptKey = convertKey(key)
    print(cipherText)
    print(transpositionCiper(cipherText, decryptKey))