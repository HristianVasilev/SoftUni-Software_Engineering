using System;
using System.Linq;
using System.Text;

namespace _05.SquareWithMaximumSum
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

            int[,] maxSubmatrix = new int[2, 2];
            int maxSubmatrixSum = int.MinValue;

            FindBiggest2x2Submatrix(matrix, ref maxSubmatrix, ref maxSubmatrixSum);

            string result = GetResult(maxSubmatrix, maxSubmatrixSum);
            Console.WriteLine(result);
        }

        private static string GetResult(int[,] maxSubmatrix, int maxSubmatrixSum)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < maxSubmatrix.GetLength(0); i++)
            {
                for (int j = 0; j < maxSubmatrix.GetLength(1); j++)
                {
                    sb.Append($"{maxSubmatrix[i, j]} ");
                }
                sb.AppendLine();
            }

            sb.AppendLine($"{maxSubmatrixSum}");
            return sb.ToString().TrimEnd();
        }

        private static void FindBiggest2x2Submatrix(int[,] matrix, ref int[,] maxSubmatrix, ref int maxSubmatrixSum)
        {
            int[,] submatrix = new int[2, 2];

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    int submatrixSum = 0;
                    submatrix = CheckSubmatrix(i, j, ref matrix, ref submatrixSum);

                    if (submatrixSum > maxSubmatrixSum)
                    {
                        maxSubmatrixSum = submatrixSum;
                        maxSubmatrix = submatrix;
                    }
                }
            }
        }

        private static int[,] CheckSubmatrix(int row, int col, ref int[,] matrix, ref int submatrixSum)
        {
            int r = 0;
            int c = 0;

            int[,] submatrix = new int[2, 2];

            for (int i = row; i < row + 2; i++)
            {
                for (int j = col; j < col + 2; j++)
                {
                    submatrix[r, c++] = matrix[i, j];
                    submatrixSum += matrix[i, j];
                }
                r++;
                c = 0;
            }

            return submatrix;
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
