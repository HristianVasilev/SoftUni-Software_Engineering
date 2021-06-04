using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];

            char[,] matrix = new char[rows, cols];

            int playerRow = -1;
            int playerCol = -1;

            ReadMatrix(ref matrix, ref playerRow, ref playerCol);

            char[] movement = Console.ReadLine().ToCharArray();

            foreach (var move in movement)
            {
                Bunnies(ref matrix);

                switch (move)
                {
                    case 'L':
                        MovePlayer(playerRow - 1, playerCol, ref playerRow, ref playerCol, ref matrix);
                        break;
                    case 'R':
                        MovePlayer(playerRow + 1, playerCol, ref playerRow, ref playerCol, ref matrix);

                        break;
                    case 'U':
                        MovePlayer(playerRow, playerCol - 1, ref playerRow, ref playerCol, ref matrix);

                        break;
                    case 'D':
                        MovePlayer(playerRow, playerCol + 1, ref playerRow, ref playerCol, ref matrix);

                        break;

                        throw new InvalidOperationException("Invalid step command!");
                }
            }
        }

        private static void MovePlayer(int row, int col, ref int playerRow, ref int playerCol, ref char[,] matrix)
        {
            matrix[playerRow, playerCol] = '.';

            if (!ValidCoordinates(row, col, matrix))
            {
                string outputMatrix = PrintMatrix(matrix);
                Console.WriteLine(outputMatrix);
                Console.WriteLine($"won: {playerRow} {playerCol}");
                Environment.Exit(0);
            }

            if (matrix[row, col] == 'B')
            {
                string outputMatrix = PrintMatrix(matrix);
                Console.WriteLine(outputMatrix);
                Console.WriteLine($"dead: {row} {col}");
                Environment.Exit(0);
            }

            matrix[playerRow, playerCol] = '.';
            matrix[row, col] = 'P';

            playerRow = row;
            playerCol = col;
        }

        private static void Bunnies(ref char[,] matrix)
        {
            List<Coordinates> bunnies = new List<Coordinates>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        bunnies.Add(new Coordinates(i, j));
                    }
                }
            }

            foreach (var bunny in bunnies)
            {
                int i = bunny.Row;
                int j = bunny.Col;

                ChangeToBunny(i + 1, j, ref matrix);
                ChangeToBunny(i - 1, j, ref matrix);
                ChangeToBunny(i, j + 1, ref matrix);
                ChangeToBunny(i, j - 1, ref matrix);
            }


        }

        private static void ChangeToBunny(int row, int col, ref char[,] matrix)
        {
            if (!ValidCoordinates(row, col, matrix))
            {
                return;
            }

            if (matrix[row, col] == 'P')
            {
                string outputMatrix = PrintMatrix(matrix);
                Console.WriteLine(outputMatrix);
                Console.WriteLine($"dead: {row} {col}");
                Environment.Exit(0);
            }

            matrix[row, col] = 'B';
        }

        private static string PrintMatrix(char[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append($"{matrix[i, j]}");
                }
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool ValidCoordinates(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void ReadMatrix(ref char[,] matrix, ref int playerRow, ref int playerCol)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string currentRow = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (currentRow[j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }

                    matrix[i, j] = currentRow[j];
                }
            }
        }
    }
}

class Coordinates
{
    public Coordinates(int row, int col)
    {
        this.Row = row;
        this.Col = col;
    }

    public int Row { get; set; }
    public int Col { get; set; }
}
