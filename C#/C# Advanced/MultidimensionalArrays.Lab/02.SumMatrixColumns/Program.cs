using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];

            ReadMatrix(ref matrix);

            string result = GetOutputResult(ref matrix);
            Console.WriteLine(result);
        }

        private static string GetOutputResult(ref int[,] matrix)
        {
            int[] sumOfColumns = new int[matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int currentColumnSum = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    currentColumnSum += matrix[j, i];
                }

                sumOfColumns[i] = currentColumnSum;
            }

            return string.Join(Environment.NewLine, sumOfColumns);
        }

        private static void ReadMatrix(ref int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRow = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }
        }
    }
}
