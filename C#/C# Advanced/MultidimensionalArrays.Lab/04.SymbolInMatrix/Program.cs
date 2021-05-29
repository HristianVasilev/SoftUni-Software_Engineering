using System;
using System.Linq;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            ReadMatrix(ref matrix);

            char symbol = char.Parse(Console.ReadLine());
            string result = FindSymbol(symbol, matrix);
            Console.WriteLine(result);
        }

        private static string FindSymbol(char symbol, char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        return $"({i}, {j})";
                    }
                }
            }

            return $"{symbol} does not occur in the matrix ";
        }

        private static void ReadMatrix(ref char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string currentRow = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }
        }

    }
}
