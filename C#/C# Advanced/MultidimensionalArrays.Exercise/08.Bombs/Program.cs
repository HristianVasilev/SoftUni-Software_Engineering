using System;
using System.Linq;
using System.Text;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            ReadMatrix(ref matrix);
            Bomb(ref matrix);

            string result = GetResult(matrix);
            Console.WriteLine(result);
        }

        private static string GetResult(int[,] matrix)
        {
            int aliveCells = 0;
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        aliveCells++;
                        sum += matrix[i, j];
                    }
                }
            }

            string outputMatrix = PrintMatrix(matrix);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Alive cells: {aliveCells}");
            sb.AppendLine($"Sum: {sum}");
            sb.AppendLine(outputMatrix);

            return sb.ToString().TrimEnd();
        }

        private static string PrintMatrix(int[,] matrix)
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

            return sb.ToString().TrimEnd();
        }

        private static void Bomb(ref int[,] matrix)
        {
            string[] bombCoordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                int[] coord = bombCoordinates[i]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = coord[0];
                int col = coord[1];

                Explode(row, col, ref matrix);
            }
        }

        private static void Explode(int row, int col, ref int[,] matrix)
        {
            if (!ValidCoord(row, col, matrix))
            {
                throw new IndexOutOfRangeException("Invalid coordinates of the matrix!");
            }

            int bomb = matrix[row, col];

            if (bomb <= 0)
            {
                return;
            }

            DecreaseValue(row, col, bomb, ref matrix);

            DecreaseValue(row - 1, col - 1, bomb, ref matrix);
            DecreaseValue(row, col - 1, bomb, ref matrix);
            DecreaseValue(row + 1, col - 1, bomb, ref matrix);

            DecreaseValue(row - 1, col, bomb, ref matrix);
            DecreaseValue(row + 1, col, bomb, ref matrix);

            DecreaseValue(row - 1, col + 1, bomb, ref matrix);
            DecreaseValue(row, col + 1, bomb, ref matrix);
            DecreaseValue(row + 1, col + 1, bomb, ref matrix);
        }

        private static void DecreaseValue(int row, int col, int bomb, ref int[,] matrix)
        {
            if (ValidCoord(row, col, matrix) && matrix[row, col] > 0)
            {
                matrix[row, col] -= bomb;
            }
        }

        private static bool ValidCoord(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void ReadMatrix(ref int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] tempRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = tempRow[j];
                }
            }
        }
    }
}
