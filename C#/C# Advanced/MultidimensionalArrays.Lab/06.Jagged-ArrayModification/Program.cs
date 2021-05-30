using System;
using System.Linq;
using System.Text;

namespace _06.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            ReadMatrix(ref matrix);

            string inputCommand;
            while ((inputCommand = Console.ReadLine()) != "END")
            {
                string[] tokens = inputCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    SwitchCommand(tokens, ref matrix);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string result = GetMatrix(matrix);
            Console.WriteLine(result);
        }

        private static void SwitchCommand(string[] tokens, ref int[][] matrix)
        {
            string action = tokens[0];
            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);
            int value = int.Parse(tokens[3]);

            switch (action)
            {
                case "Add":
                    Add(row, col, value, ref matrix);

                    break;
                case "Subtract":
                    Subtract(row, col, value, ref matrix);

                    break;
                default:
                    throw new InvalidOperationException("Invalid command!");
            }
        }

        private static void Subtract(int row, int col, int value, ref int[][] matrix)
        {
            if (!ValidCoordinates(row, col, matrix))
            {
                throw new IndexOutOfRangeException("Invalid coordinates");
            }

            matrix[row][col] -= value;
        }

        private static void Add(int row, int col, int value, ref int[][] matrix)
        {
            if (!ValidCoordinates(row, col, matrix))
            {
                throw new IndexOutOfRangeException("Invalid coordinates");
            }

            matrix[row][col] += value;
        }



        private static string GetMatrix(int[][] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sb.AppendLine(string.Join(" ", matrix[i]));
            }

            return sb.ToString().TrimEnd();
        }

        private static void ReadMatrix(ref int[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = currentRow;
            }
        }



        private static bool ValidCoordinates(int row, int col, int[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix[row].Length;
        }
    }
}
