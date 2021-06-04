using System;
using System.Linq;

namespace _3.MaximalSum
{
    class Program
    {
        private static int[,] matrix;

        static void Main(string[] args)
        {
            byte[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(byte.Parse)
                .ToArray();

            byte rowSize = size[0];
            byte colSize = size[1];

            matrix = new int[rowSize, colSize];
            FillMatrix();

            int maxSum = 0;
            int[,] maxMatrix = new int[3, 3];

            GetResults(ref maxSum, ref maxMatrix);
            PrintResult(maxSum, maxMatrix);
        }

        private static void FillMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }

        private static int GetSum(int row, int col)
        {
            int sum = 0;

            for (int i = row; i < row + 3; i++)
            {
                for (int j = col; j < col + 3; j++)
                {
                    sum += matrix[i, j];
                }
            }

            return sum;
        }
        private static int[,] GetMaxMatrix(int row, int col)
        {
            int[,] arr = new int[3, 3];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = matrix[row, col++];
                }
                row++;
                col -= 3;
            }

            return arr;
        }

        private static void GetResults(ref int maxSum, ref int[,] maxMatrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int sum = GetSum(i, j);

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxMatrix = GetMaxMatrix(i, j);
                    }
                }
            }
        }
        private static void PrintResult(int maxSum, int[,] maxMatrix)
        {
            Console.WriteLine($"Sum = {maxSum}");

            for (int i = 0; i < maxMatrix.GetLength(0); i++)
            {
                int[] currentRow = new int[maxMatrix.GetLength(1)];

                for (int j = 0; j < maxMatrix.GetLength(1); j++)
                {
                    currentRow[j] = maxMatrix[i, j];
                }

                Console.WriteLine(string.Join(" ", currentRow));
            }
        }
    }
}
