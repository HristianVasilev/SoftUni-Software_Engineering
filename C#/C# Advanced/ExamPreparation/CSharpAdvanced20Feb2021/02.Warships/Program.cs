using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Warships
{
    class Player
    {
        public Player(char id, int countOfShips)
        {
            this.ID = id;
            this.CountOfShips = countOfShips;
        }

        public char ID { get; set; }
        public int CountOfShips { get; set; }

        public void Attack()
        {
            this.CountOfShips--;
        }

        public bool IsAlive()
        {
            if (this.CountOfShips > 0)
            {
                return true;
            }

            return false;
        }
    }

    class Program
    {
        private static char[,] field;
        private static Player playerOne;
        private static Player playerTwo;
        private static int totalShipsDestroyed;

        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            string[] attackCoordinates = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            totalShipsDestroyed = 0;
            field = ReadField(fieldSize);

            int playerOneShips = GetCountOfShips('<');
            playerOne = new Player('<', playerOneShips);

            int playerTwoShips = GetCountOfShips('>');
            playerTwo = new Player('>', playerTwoShips);

            for (int i = 0; i < attackCoordinates.Length; i++)
            {
                int[] playerAttackCoordinates = attackCoordinates[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int attackRow = playerAttackCoordinates[0];
                int attackCol = playerAttackCoordinates[1];

                if (!ValidCoordinates(attackRow, attackCol))
                {
                    continue;
                }

                Attack(attackRow, attackCol, i);

                if (!playerOne.IsAlive() || !playerTwo.IsAlive())
                {
                    break;
                }

            }

            string result = GetResult();
            Console.WriteLine(result);

        }

        private static void PrintMatrix()
        {
            Console.WriteLine();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write($"{field[i, j]} ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static string GetResult()
        {
            if (playerOne.IsAlive() && playerTwo.IsAlive())
            {
                return $"It's a draw! Player One has {playerOne.CountOfShips} ships left. Player Two has {playerTwo.CountOfShips} ships left.";
            }
            else if (playerOne.IsAlive())
            {
                return $"Player One has won the game! {totalShipsDestroyed} ships have been sunk in the battle.";
            }

            return $"Player Two has won the game! {totalShipsDestroyed} ships have been sunk in the battle.";
        }

        private static void Attack(int attackRow, int attackCol, int turn)
        {
            Player attackedPlayer;

            if (turn % 2 == 0)
            {
                attackedPlayer = playerTwo;
            }
            else
            {
                attackedPlayer = playerOne;
            }

            char currentPosition = field[attackRow, attackCol];

            if (currentPosition.Equals('#'))
            {
                Mine(attackRow, attackCol);
                return;
            }

            if (currentPosition.Equals(attackedPlayer.ID))
            {
                attackedPlayer.Attack();
                totalShipsDestroyed++;
            }

            field[attackRow, attackCol] = 'X';
        }

        private static void Mine(int row, int col)
        {
            int[][] mineCoordinates = new int[][]
            {
                new int[] {row - 1, col - 1},
                new int[] {row, col - 1},
                new int[] {row + 1, col - 1},

                new int[] {row - 1, col},

                new int[] {row + 1, col},

                new int[] {row - 1, col + 1},
                new int[] {row, col + 1},
                new int[] {row + 1, col + 1}
            };

            for (int i = 0; i < mineCoordinates.Length; i++)
            {
                int[] currentCoordinates = mineCoordinates[i];

                int currentRow = currentCoordinates[0];
                int currentCol = currentCoordinates[1];

                if (!ValidCoordinates(currentRow, currentCol))
                {
                    continue;
                }

                char currentPosition = field[currentRow, currentCol];

                if (currentPosition.Equals('<'))
                {
                    playerOne.Attack();
                    totalShipsDestroyed++;
                }
                else if (currentPosition.Equals('>'))
                {
                    playerTwo.Attack();
                    totalShipsDestroyed++;
                }

                field[currentRow, currentCol] = 'X';
            }
        }

        private static int GetCountOfShips(char symbol)
        {
            int count = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j].Equals(symbol))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static bool ValidCoordinates(int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }

        private static char[,] ReadField(int fieldSize)
        {
            char[,] field = new char[fieldSize, fieldSize];

            for (int i = 0; i < field.GetLength(0); i++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = currentRow[j];
                }
            }

            return field;
        }
    }
}
