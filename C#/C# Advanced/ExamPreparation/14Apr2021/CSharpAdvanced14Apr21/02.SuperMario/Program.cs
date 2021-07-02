using System;

namespace _02.SuperMario
{
    class Program
    {
        private static int lives;
        private static char[][] matrix;
        private static int[] marioCoordinates;

        static void Main(string[] args)
        {
            lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            matrix = ReadMatrix(n);
            marioCoordinates = FindMario(matrix);

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string directionToMove = command[0];
                int[] enemyCoordinates = new int[] { int.Parse(command[1]), int.Parse(command[2]) };

                int enemyRow = int.Parse(command[1]);
                int enemyCol = int.Parse(command[2]);

                Bowser(enemyRow, enemyCol);
                TryMove(directionToMove);
            }

        }

        private static void Bowser(int enemyRow, int enemyCol)
        {
            matrix[enemyRow][enemyCol] = 'B';
        }

        private static int[] FindMario(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'M')
                    {
                        return new int[] { i, j };
                    }
                }
            }

            throw new ArgumentException("There is no Mario!");
        }

        private static void TryMove(string direction)
        {
            int row = marioCoordinates[0];
            int col = marioCoordinates[1];

            switch (direction)
            {
                case "W":
                    row--;
                    break;
                case "S":
                    row++;
                    break;
                case "A":
                    col--;
                    break;
                case "D":
                    col++;
                    break;

                default:
                    throw new InvalidOperationException("Invalid direction!");
            }

            DecreaseLive(1);

            if (ValidCoordinates(row, col))
            {
                Move(row, col);
            }
        }

        private static void Move(int row, int col)
        {
            char cell = matrix[row][col];
            int marioRow = marioCoordinates[0];
            int marioCol = marioCoordinates[1];

            matrix[marioRow][marioCol] = '-';

            if (cell == 'P')
            {
                SavePrincess(row, col, marioRow, marioCol);
                return;
            }

            if (cell == 'B')
            {
                DecreaseLive(2);
            }

            bool isAlive = IsAlive();

            if (!isAlive)
            {
                Dead(row, col);
            }

            matrix[row][col] = 'M';
            marioCoordinates = new int[] { row, col };
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(string.Empty, matrix[i]));
            }
        }

        private static void DecreaseLive(int value)
        {
            lives -= value;
        }

        private static bool IsAlive()
        {
            if (lives <= 0)
            {
                return false;
            }

            return true;
        }

        private static bool ValidCoordinates(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static char[][] ReadMatrix(int n)
        {
            char[][] matrix = new char[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            return matrix;
        }

        private static void SavePrincess(int row, int col, int marioRow, int marioCol)
        {
            matrix[marioRow][marioCol] = '-';
            matrix[row][col] = '-';

            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            PrintMatrix();
            Environment.Exit(0);
        }

        private static void Dead(int row, int col)
        {
            matrix[row][col] = 'X';

            Console.WriteLine($"Mario died at {row};{col}.");
            PrintMatrix();
            Environment.Exit(0);
        }
    }
}
