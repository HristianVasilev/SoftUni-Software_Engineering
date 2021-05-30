using System;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] triangle = new long[n][];
            int currentLength = 1;

            for (int i = 0; i < n; i++)
            {
                triangle[i] = new long[currentLength];
                triangle[i][0] = 1;
                triangle[i][currentLength - 1] = 1;

                if (currentLength > 2)
                {
                    for (int j = 1; j < currentLength - 1; j++)
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    }
                }

                currentLength++;
            }

            PrintMatrix(triangle);
        }

        private static void PrintMatrix(long[][] triangle)
        {
            foreach (var row in triangle)
            {
                Console.WriteLine(String.Join(' ', row));
            }
        }
    }
}
