using System;

namespace NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            GetMatrix(n);
        }

        private static void GetMatrix(int n)
        {
            for (int i = 0; i < n; i++)
            {
                int[] arr = new int[n];
                Array.Fill(arr, n);
                Console.WriteLine(string.Join(' ', arr));
            }
        }
    }
}
