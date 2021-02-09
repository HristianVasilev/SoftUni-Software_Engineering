using System;

namespace PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            GenerateTriangle(n);
        }

        private static void GenerateTriangle(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write($"{j + 1} ");
                }
                Console.WriteLine();
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 0; j < i ; j++)
                {
                    Console.Write($"{j + 1} ");
                }
                Console.WriteLine();
            }
        }
    }
}
