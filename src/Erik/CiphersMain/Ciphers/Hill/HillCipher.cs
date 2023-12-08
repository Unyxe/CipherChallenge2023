using CiphersMain.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersMain.Ciphers.Hill
{
    public class HillCipher : ICipher<IntegerMatrixKey>
    {
        public string Name => throw new NotImplementedException();

        public IntegerMatrixKey Key { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Decrypt(string cipherText, IntegerMatrixKey key)
        {
            // Get the dimensions of the key matrix
            int keySize = key.Values.GetLength(0);
            int blockSize = keySize;

            // Split the cipher text into blocks of size blockSize
            List<string> blocks = new List<string>();
            for (int i = 0; i < cipherText.Length; i += blockSize)
            {
                blocks.Add(cipherText.Substring(i, Math.Min(blockSize, cipherText.Length - i)));
            }

            // Decrypt each block using the key matrix
            StringBuilder plainText = new StringBuilder();
            foreach (string block in blocks)
            {
                // Convert the block to a matrix of numbers
                int[,] blockMatrix = new int[blockSize, 1];
                for (int i = 0; i < block.Length; i++)
                {
                    blockMatrix[i, 0] = block[i] - 'A';
                }

                // Calculate the inverse of the key matrix
                int[,] inverseKeyMatrix = CalculateInverseKeyMatrix(key.Values);

                // Multiply the block matrix by the inverse key matrix
                int[,] decryptedMatrix = new int[blockSize, 1];
                for (int i = 0; i < blockSize; i++)
                {
                    for (int j = 0; j < blockSize; j++)
                    {
                        decryptedMatrix[i, 0] += inverseKeyMatrix[i, j] * blockMatrix[j, 0];
                    }
                    decryptedMatrix[i, 0] %= 26;
                }

                // Convert the decrypted matrix back to a string
                StringBuilder decryptedBlock = new StringBuilder();
                for (int i = 0; i < blockSize; i++)
                {
                    decryptedBlock.Append((char)(decryptedMatrix[i, 0] + 'A'));
                }

                plainText.Append(decryptedBlock);
            }

            return plainText.ToString();
        }

        private int[,] CalculateInverseKeyMatrix(int[,] keyMatrix)
        {
            // Calculate the determinant of the key matrix
            int determinant = CalculateDeterminant(keyMatrix);

            // Calculate the modular multiplicative inverse of the determinant
            int inverseDeterminant = CalculateModularMultiplicativeInverse(determinant, 26);

            // Calculate the adjugate matrix
            int[,] adjugateMatrix = CalculateAdjugateMatrix(keyMatrix);

            // Calculate the inverse key matrix
            int[,] inverseKeyMatrix = new int[keyMatrix.GetLength(0), keyMatrix.GetLength(1)];
            for (int i = 0; i < keyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < keyMatrix.GetLength(1); j++)
                {
                    inverseKeyMatrix[i, j] = (adjugateMatrix[i, j] * inverseDeterminant) % 26;
                }
            }

            return inverseKeyMatrix;
        }

        private int CalculateDeterminant(int[,] matrix)
        {
            // Calculate the determinant of a 2x2 matrix
            if (matrix.GetLength(0) == 2 && matrix.GetLength(1) == 2)
            {
                return (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) % 26;
            }

            // Calculate the determinant of a larger matrix using cofactor expansion
            int determinant = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[,] subMatrix = GetSubMatrix(matrix, i, 0);
                determinant += (int)Math.Pow(-1, i) * matrix[i, 0] * CalculateDeterminant(subMatrix);
            }

            return determinant % 26;
        }

        private int[,] CalculateAdjugateMatrix(int[,] matrix)
        {
            int[,] adjugateMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int[,] subMatrix = GetSubMatrix(matrix, i, j);
                    adjugateMatrix[j, i] = (int)Math.Pow(-1, i + j) * CalculateDeterminant(subMatrix);
                }
            }

            return adjugateMatrix;
        }

        private int[,] GetSubMatrix(int[,] matrix, int rowToRemove, int columnToRemove)
        {
            int subMatrixSize = matrix.GetLength(0) - 1;
            int[,] subMatrix = new int[subMatrixSize, subMatrixSize];
            int rowIndex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == rowToRemove)
                {
                    continue;
                }

                int columnIndex = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == columnToRemove)
                    {
                        continue;
                    }

                    subMatrix[rowIndex, columnIndex] = matrix[i, j];
                    columnIndex++;
                }

                rowIndex++;
            }

            return subMatrix;
        }

        private int CalculateModularMultiplicativeInverse(int number, int modulus)
        {
            for (int i = 1; i < modulus; i++)
            {
                if ((number * i) % modulus == 1)
                {
                    return i;
                }
            }

            return -1;
        }

        public string Encrypt(string plainText, IntegerMatrixKey key)
        {
            // Get the dimensions of the key matrix
            int keySize = key.Values.GetLength(0);
            int blockSize = keySize;

            // Pad the plaintext if its length is not a multiple of the block size
            int paddingLength = blockSize - (plainText.Length % blockSize);
            if (paddingLength != blockSize)
            {
                plainText += new string('X', paddingLength);
            }

            // Split the plaintext into blocks of size blockSize
            List<string> blocks = new List<string>();
            for (int i = 0; i < plainText.Length; i += blockSize)
            {
                blocks.Add(plainText.Substring(i, blockSize));
            }

            // Encrypt each block using the key matrix
            StringBuilder cipherText = new StringBuilder();
            foreach (string block in blocks)
            {
                // Convert the block to a matrix of numbers
                int[,] blockMatrix = new int[blockSize, 1];
                for (int i = 0; i < blockSize; i++)
                {
                    blockMatrix[i, 0] = block[i] - 'A';
                }

                // Multiply the block matrix by the key matrix
                int[,] encryptedMatrix = new int[blockSize, 1];
                for (int i = 0; i < blockSize; i++)
                {
                    for (int j = 0; j < blockSize; j++)
                    {
                        encryptedMatrix[i, 0] += key.Values[i, j] * blockMatrix[j, 0];
                    }
                    encryptedMatrix[i, 0] %= 26;
                }

                // Convert the encrypted matrix back to a string
                StringBuilder encryptedBlock = new StringBuilder();
                for (int i = 0; i < blockSize; i++)
                {
                    encryptedBlock.Append((char)(encryptedMatrix[i, 0] + 'A'));
                }

                cipherText.Append(encryptedBlock);
            }

            return cipherText.ToString();
        }
    }
}
