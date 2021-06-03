using System;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        private static int coals;
        private static int countOfCoals;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[size, size];

            ReadMatrix(ref matrix);

            int[] startCoordinates = FindStart(matrix);
            int currentRow = startCoordinates[0];
            int currentCol = startCoordinates[1];

            coals = 0;
            countOfCoals = CountTheCoals(matrix);

            foreach (var command in commands)
            {
                switch (command)
                {
                    case "left":
                        Move(currentRow, currentCol - 1, ref currentRow, ref currentCol, ref matrix);

                        break;
                    case "right":
                        Move(currentRow, currentCol + 1, ref currentRow, ref currentCol, ref matrix);

                        break;
                    case "up":
                        Move(currentRow - 1, currentCol, ref currentRow, ref currentCol, ref matrix);

                        break;
                    case "down":
                        Move(currentRow + 1, currentCol, ref currentRow, ref currentCol, ref matrix);

                        break;

                    default:
                        throw new InvalidOperationException("Invalid command!");
                }
            }

            Console.WriteLine($"{countOfCoals - coals} coals left. ({currentRow}, {currentCol})");
        }

        private static int CountTheCoals(char[,] matrix)
        {
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'c')
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static void Move(int row, int col, ref int currentRow, ref int currentCol, ref char[,] matrix)
        {
            if (!ValidCoordinates(row, col, matrix))
            {
                return;
            }


            if (matrix[row, col] == 'e')
            {
                Console.WriteLine($"Game over! ({row}, {col})");
                Environment.Exit(0);
            }
            else if (matrix[row, col] == 'c')
            {
                coals++;

                if (coals == countOfCoals)
                {
                    Console.WriteLine($"You collected all coals! ({row}, {col})");
                    Environment.Exit(0);
                }

                matrix[row, col] = '*';
            }

            currentRow = row;
            currentCol = col;
        }

        private static bool ValidCoordinates(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static int[] FindStart(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 's')
                    {
                        return new int[] { i, j };
                    }
                }
            }

            throw new ArgumentException("Symbol \"s\" is missing from the matrix!");
        }

        private static void ReadMatrix(ref char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] tempRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = tempRow[j];
                }
            }
        }
    }
}
