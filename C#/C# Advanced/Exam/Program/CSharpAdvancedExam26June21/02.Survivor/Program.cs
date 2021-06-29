using System;
using System.Linq;
using System.Text;

namespace _02.Survivor
{
    class Program
    {
        private static char[][] jaggedArray;
        private static int collectedTokens;
        private static int opponentTokens;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            jaggedArray = ReadArray(rows);

            collectedTokens = 0;
            opponentTokens = 0;

            string command;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (!ValidCoordinates(row, col))
                {
                    continue;
                }

                switch (action)
                {
                    case "Find":
                        if (jaggedArray[row][col].Equals('T'))
                        {
                            collectedTokens = CollectToken(row, col, collectedTokens);
                        }

                        break;
                    case "Opponent":
                        if (jaggedArray[row][col].Equals('T'))
                        {
                            opponentTokens = CollectToken(row, col, opponentTokens);
                        }

                        string direction = tokens[3];
                        Move(row, col, direction);


                        break;

                    default:
                        throw new ArgumentException();
                }
            }

            string result = GetResult();
            Console.WriteLine(result);
        }

        private static string GetResult()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                sb.AppendLine($"{string.Join(' ', jaggedArray[i])}");
            }

            sb.AppendLine($"Collected tokens: {collectedTokens}");
            sb.AppendLine($"Opponent's tokens: {opponentTokens}");

            return sb.ToString().TrimEnd();
        }

        private static void Move(int row, int col, string direction)
        {
            switch (direction)
            {
                case "up":
                    for (int i = 0; i < 3; i++)
                    {
                        row--;

                        if (!ValidCoordinates(row, col))
                        {
                            break;
                        }

                        if (jaggedArray[row][col].Equals('T'))
                        {
                            opponentTokens = CollectToken(row, col, opponentTokens);
                        }
                    }

                    break;
                case "down":
                    for (int i = 0; i < 3; i++)
                    {
                        row++;

                        if (!ValidCoordinates(row, col))
                        {
                            break;
                        }

                        if (jaggedArray[row][col].Equals('T'))
                        {
                            opponentTokens = CollectToken(row, col, opponentTokens);
                        }
                    }

                    break;
                case "left":
                    for (int i = 0; i < 3; i++)
                    {
                        col--;

                        if (!ValidCoordinates(row, col))
                        {
                            break;
                        }

                        if (jaggedArray[row][col].Equals('T'))
                        {
                            opponentTokens = CollectToken(row, col, opponentTokens);
                        }
                    }

                    break;
                case "right":
                    for (int i = 0; i < 3; i++)
                    {
                        col++;

                        if (!ValidCoordinates(row, col))
                        {
                            break;
                        }

                        if (jaggedArray[row][col].Equals('T'))
                        {
                            opponentTokens = CollectToken(row, col, opponentTokens);
                        }
                    }

                    break;

                default:
                    throw new ArgumentException();
            }
        }

        private static int CollectToken(int row, int col, int collect)
        {
            jaggedArray[row][col] = '-';

            return ++collect;
        }

        private static bool ValidCoordinates(int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;
        }

        private static char[][] ReadArray(int rows)
        {
            char[][] jaggedArray = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            return jaggedArray;
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(' ', jaggedArray[i]));
            }
        }
    }
}
