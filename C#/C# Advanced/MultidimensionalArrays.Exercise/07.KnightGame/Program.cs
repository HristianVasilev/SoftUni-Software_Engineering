using System;

namespace _07.KnightGame
{
    class Program
    {
        private static char[,] board;


        static void Main(string[] args)
        {
            byte boardSize = byte.Parse(Console.ReadLine());

            board = new char[boardSize, boardSize];
            FillBoard(boardSize);

            RemoveKnight();




        }

        private static void RemoveKnight()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 'K')
                    {
                        int[,] options = new int[8, 2]
                        {
                           {i + 1, j - 2},
                           {i + 2, j - 1},
                           {i + 2, j + 1},
                           {i + 1, j + 2},

                           {i - 1, j - 2},
                           {i - 2, j - 1},
                           {i - 2, j + 1},
                           {i - 1, j + 2}
                        };

                        CheckOptions(options);


                        //;
                        //CheckIfIsKnight(i + 1, j - 2);
                        //CheckIfIsKnight(i + 2, j - 1);
                        //CheckIfIsKnight(i + 2, j + 1);
                        //CheckIfIsKnight(i + 1, j + 2);

                        //CheckIfIsKnight(i - 1, j - 2);
                        //CheckIfIsKnight(i - 2, j - 1);
                        //CheckIfIsKnight(i - 2, j + 1);
                        //CheckIfIsKnight(i - 1, j + 2);
                    }
                }
            }


        }

        private static void CheckOptions(int[,] options)
        {        
            for (int i = 0; i < options.GetLength(0); i++)
            {
                if (CheckIfIsKnight(options[i, 0], options[i, 1]))
                {

                } 
            }
        }

        private static bool CheckIfIsKnight(int row, int col)
        {
            if (!ValidCoordinates(row, col) || board[row, col] != 'K')
            {
                return false;
            }

            return true;
        }

        private static bool ValidCoordinates(int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) &&
                col >= 0 && col < board.GetLength(1);
        }

        private static void FillBoard(byte boardSize)
        {
            for (int i = 0; i < boardSize; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = char.Parse(input[j].ToString());
                }
            }
        }

        private static void PrintArray()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
