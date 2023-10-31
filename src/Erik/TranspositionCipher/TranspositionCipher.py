alphabet = list("abcdefghijklmnopqrstuvwxyz")
key = list("10234")

def split_and_pad(input_string, n, padding_char=' '):
    padding_needed = n - (len(input_string) % n)
    
    padded_string = input_string + padding_char * padding_needed
    return [padded_string[i:i+n] for i in range(0, len(padded_string), n)]

def encrypt(plainText, key):
    blockLength = len(key)
    blocks = split_and_pad(plainText, blockLength)
    encBlocks = []
    for block in blocks:
        encBlock = [' ' for i in range(blockLength)]
        for (i, char) in enumerate(block):
            index = int(key[i])
            encBlock[index] = char
        encBlocks += encBlock
    return "".join(encBlocks)

if __name__ == "__main__":
    print(encrypt("Hello World!", key))