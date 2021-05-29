using System;
using System.Linq;

namespace _02._2X2SquaresInMatrix
{
    class Program
    {
        private static char[,] matrix;

        static void Main(string[] args)
        {
            byte[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(byte.Parse)
                .ToArray();

            byte rows = size[0];
            byte cols = size[1];

            matrix = new char[rows, cols];
            FillMatrix();

            int equals = FindEquals();
            Console.WriteLine(equals);
        }

        private static int FindEquals()
        {
            int equals = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (SquareEqual(i, j))
                    {
                        equals++;
                    }
                }
            }

            return equals;
        }

        private static bool SquareEqual(int i, int j)
        {
            bool first = ValidCoordinates(i + 1, j) && matrix[i, j] == matrix[i + 1, j];
            bool second = ValidCoordinates(i + 1, j + 1) && matrix[i, j] == matrix[i + 1, j + 1];
            bool third = ValidCoordinates(i, j + 1) && matrix[i, j] == matrix[i, j + 1];

            return first && second && third;
        }

        private static bool ValidCoordinates(int i, int j)
        {
            return i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1);
        }

        private static void FillMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
        }
    }
}
