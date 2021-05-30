using System;

namespace _07._1.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] pascalTriangle = new int[n][];
            int row = 0;

            for (int i = 0; i < n; i++)
            {
                FillPascalTriangle(i, ref pascalTriangle);
            }

        }

        private static void FillPascalTriangle(int row, ref int[][] pascalTriangle)
        {
            if (row == 0)
            {
                pascalTriangle[row] = new int[] { 1 };
            }
            else if (row == 1)
            {
                pascalTriangle[row] = new int[] { 1, 1 };
            }




        }
    }
}
