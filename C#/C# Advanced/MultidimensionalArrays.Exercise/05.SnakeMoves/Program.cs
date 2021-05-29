using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(byte.Parse)
                .ToArray();

            byte rows = matrixSize[0];
            byte cols = matrixSize[1];

            string snake = Console.ReadLine();

            char[,] matrix = new char[rows, cols];

            FillMatrix(ref matrix, snake);
            PrintMatrix(matrix);
        }

        private static void FillMatrix(ref char[,] matrix, string snake)
        {
            byte counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = snake[counter];
                        IncreaseCounter(ref counter, snake);
                    }
                }
                else
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i, j] = snake[counter];
                        IncreaseCounter(ref counter, snake);
                    }
                }
            }
        }

        private static void IncreaseCounter(ref byte counter, string snake)
        {
            if (counter + 1 < snake.Length)
            {
                counter++;
                return;
            }

            counter = 0;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
