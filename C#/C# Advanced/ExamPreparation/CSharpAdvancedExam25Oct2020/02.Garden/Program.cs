using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] garden = new int[rows, cols];

            GeneratePlants(ref garden);

            string result = GetGardenMatrix(garden);
            Console.WriteLine(result);
        }

        private static string GetGardenMatrix(int[,] garden)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    sb.Append($"{garden[i,j]} ");
                }
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

        private static void GeneratePlants(ref int[,] garden)
        {
            string input;
            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] plantCoordinates = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = plantCoordinates[0];
                int col = plantCoordinates[1];

                if (!ValidCoordinates(row, col, garden))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                PlantFlower(row, col, ref garden);
            }
        }

        private static void PlantFlower(int row, int col, ref int[,] garden)
        {
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                if (i == row)
                {
                    continue;
                }

                garden[i, col]++;
            }

            for (int i = 0; i < garden.GetLength(1); i++)
            {
                if (i == col)
                {
                    continue;
                }

                garden[row, i]++;
            }

            garden[row, col]++;
        }

        private static bool ValidCoordinates(int row, int col, int[,] garden)
        {
            return row >= 0 && row < garden.GetLength(0)
                && col >= 0 && col < garden.GetLength(1);
        }
    }
}
