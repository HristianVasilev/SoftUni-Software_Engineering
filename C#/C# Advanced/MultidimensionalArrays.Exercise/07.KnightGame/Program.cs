using System;

namespace _07.KnightGame
{
    class Program
    {
        private static char[,] board;


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            ReadMatrix(ref matrix);

            int removedKnights = AnalyzeMatrix(n, matrix);

            Console.WriteLine(removedKnights);
        }

        private static int AnalyzeMatrix(int n, char[][] matrix)
        {
            int removedKnights = 0;

            while (true)
            {
                int knightRow = -1;
                int knightCol = -1;

                int maxAttacked = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row][col] == 'K')
                        {
                            int tempAttack = CountAttacks(matrix, row, col);

                            if (tempAttack > maxAttacked)
                            {
                                maxAttacked = tempAttack;

                                knightRow = row;
                                knightCol = col;
                            }
                        }
                    }
                }

                if (maxAttacked > 0)
                {
                    matrix[knightRow][knightCol] = '0';
                    removedKnights++;
                }
                else
                {
                    break;
                }
            }

            return removedKnights;
        }

        private static int CountAttacks(char[][] matrix, int row, int col)
        {
            int attacks = 0;

            IsKnight(row - 1, col - 2, ref attacks, ref matrix);
            IsKnight(row - 1, col + 2, ref attacks, ref matrix);
            IsKnight(row + 1, col - 2, ref attacks, ref matrix);
            IsKnight(row + 1, col + 2, ref attacks, ref matrix);

            IsKnight(row - 2, col - 1, ref attacks, ref matrix);
            IsKnight(row - 2, col + 1, ref attacks, ref matrix);
            IsKnight(row + 2, col - 1, ref attacks, ref matrix);
            IsKnight(row + 2, col + 1, ref attacks, ref matrix);

            return attacks;
        }

        private static void IsKnight(int row, int col, ref int attacks, ref char[][] matrix)
        {
            if (IsInMatrix(row, col, matrix.Length) && matrix[row][col] == 'K')
            {
                attacks++;
            }
        }

        private static bool IsInMatrix(int row, int col, int length)
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }

        private static void ReadMatrix(ref char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
