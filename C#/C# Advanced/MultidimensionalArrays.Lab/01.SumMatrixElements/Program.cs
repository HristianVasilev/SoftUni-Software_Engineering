using System;
using System.Linq;

namespace _01.SumMatrixElements
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
            int countOfRows = matrix.GetLength(0);
            int countOfCols = matrix.GetLength(1);

            int sumOfElements = SumMatrixElements(matrix);

            return $"{countOfRows}{Environment.NewLine}{countOfCols}{Environment.NewLine}{sumOfElements}";
        }

        private static int SumMatrixElements(int[,] matrix)
        {
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }
            }

            return sum;
        }

        private static void ReadMatrix(ref int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
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
