using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        private static int[][] matrix;

        static void Main(string[] args)
        {
            ReadMatrix();

            AnalyzeMatrix();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int column = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if (!Valid(row, column))
                {
                    continue;
                }

                switch (action)
                {
                    case "Add":
                        AddValue(row, column, value);
                        break;
                    case "Subtract":
                        SubtractValue(row, column, value);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            PrintMatrix();
        }

        private static void SubtractValue(int row, int column, int value)
        {
            matrix[row][column] -= value;
        }

        private static void AddValue(int row, int column, int value)
        {
            matrix[row][column] += value;
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(' ', matrix[i]));
            }
        }

        private static void AnalyzeMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    Operation(i, Options.MultiplyBy2);
                }
                else
                {
                    Operation(i, Options.DivideBy2);
                }
            }
        }

        private static void Operation(int i, Options option)
        {
            Func<int, int> operation;

            switch (option)
            {
                case Options.MultiplyBy2:
                    operation = x => x * 2;
                    break;
                case Options.DivideBy2:
                    operation = x => x / 2;
                    break;
                default:
                    throw new InvalidOperationException("There is no such operation!");
            }

            matrix[i] = matrix[i].Select(operation).ToArray();
            matrix[i + 1] = matrix[i + 1].Select(operation).ToArray();
        }

        private static void ReadMatrix()
        {
            int rows = int.Parse(Console.ReadLine());
            matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = currentRow;
            }
        }

        private static bool Valid(int row, int column)
        {
            return row >= 0 && row < matrix.Length &&
                column >= 0 && column < matrix[row].Length;
        }

    }

    public enum Options
    {
        MultiplyBy2 = 10,
        DivideBy2 = 20,
    }
}
