using System;
using System.Collections.Generic;

namespace _02.ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = ReadMatrix(size, countOfCommands);
            int[] playerCoord = FindPlayer(matrix);

            Stack<char[,]> matrixHistory = new Stack<char[,]>();
            matrixHistory.Push(matrix);

            for (int i = 0; i < 3; i++)
            {
                string moveCommand = Console.ReadLine();

                int playerRow = playerCoord[0];
                int playerCol = playerCoord[1];

                switch (moveCommand)
                {
                    case "down":

                        Move(matrix, playerRow, playerCol, ref playerCoord);

                        break;
                    case "up":

                        break;
                    case "left":

                        break;
                    case "right":

                        break;

                    default:
                        break;
                }
            }

        }

        private static void Move(char[,] matrix, int playerRow, int playerCol, ref int[] playerCoord, ref Stack<char[,]> matrixHistory)
        {
            int row = playerRow + 1;
            int col = playerCol;

            if (!ValidCoordinates(row, col, matrix))
            {
                RepairCoordinates(ref row, ref col, matrix);
            }

            CheckNewPosition(row, col, matrix, ref matrixHistory);

            matrix[row, col] = 'f';
            matrix[playerRow, playerCol] = '-';
            playerCoord = new int[] { row, col };

            matrixHistory.Push(matrix);
        }

        private static void CheckNewPosition(int row, int col, char[,] matrix, ref Stack<char[,]> matrixHistory)
        {
            if (matrix[row, col] == 'F')
            {
                Console.WriteLine("Player won!");
                Environment.Exit(0);
            }
            else if (matrix[row, col] == 'B')
            {

            }
            else if (matrix[row, col] == 'T')
            {
                matrixHistory.Pop();
            }


        }

        private static void RepairCoordinates(ref int row, ref int col, char[,] matrix)
        {
            if (row >= matrix.GetLength(0))
            {
                row = 0;
            }
            else if (row < matrix.GetLength(0))
            {
                row = matrix.GetLength(0) - 1;
            }


            if (col >= matrix.GetLength(1))
            {
                col = 0;
            }
            else if (col < matrix.GetLength(1))
            {
                col = matrix.GetLength(1) - 1;
            }
        }

        private static bool ValidCoordinates(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static int[] FindPlayer(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'f')
                    {
                        return new int[] { i, j };
                    }
                }
            }

            throw new ArgumentException("Cannot find the player!");
        }

        private static char[,] ReadMatrix(int size, int countOfCommands)
        {
            char[,] matrix = new char[size, size];

            for (int i = 0; i < countOfCommands; i++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            return matrix;
        }
    }
}
