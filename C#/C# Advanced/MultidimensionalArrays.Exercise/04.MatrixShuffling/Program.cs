using System;
using System.Linq;
using System.Text;

namespace _04.MatrixShuffling
{
    class Program
    {

        static void Main(string[] args)
        {
            byte[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(byte.Parse)
                .ToArray();

            byte rows = dimensions[0];
            byte cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            ReadMatrix(ref matrix);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {

                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] != "swap" || commandArgs.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(commandArgs[1]);
                int col1 = int.Parse(commandArgs[2]);
                int row2 = int.Parse(commandArgs[3]);
                int col2 = int.Parse(commandArgs[4]);

                string output = Swap(row1, col1, row2, col2, ref matrix);
                Console.WriteLine(output);
            }


        }

        private static string Swap(int row1, int col1, int row2, int col2, ref string[,] matrix)
        {
            if (!Valid(row1, col1, ref matrix) || !Valid(row2, col2, ref matrix))
            {
                return "Invalid input!";
            }

            string temp = matrix[row2, col2];
            matrix[row2, col2] = matrix[row1, col1];
            matrix[row1, col1] = temp;

            return PrintMatrix(matrix);
        }

        private static void ReadMatrix(ref string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }
        }

        private static string PrintMatrix(string[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append($"{matrix[i, j]} ");
                }
                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }


        private static bool Valid(int row, int col, ref string[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}
