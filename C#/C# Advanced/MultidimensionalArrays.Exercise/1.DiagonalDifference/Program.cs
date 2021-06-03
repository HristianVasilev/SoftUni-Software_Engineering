using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            byte matrixSize = byte.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];
            FillMatrix(matrix);

            int D1 = 0;
            int D2 = 0;
            int counter = matrix.GetLength(1) - 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                D1 += matrix[i, i];
                D2 += matrix[i, counter--];
            }

            int difference = Math.Abs(D1 - D2);
            Console.WriteLine(difference);
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(input[j].ToString());
                }
            }
        }
    }
}
