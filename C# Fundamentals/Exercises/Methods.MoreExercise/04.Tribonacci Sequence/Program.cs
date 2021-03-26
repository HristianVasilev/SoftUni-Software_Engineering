using System;

namespace _04.Tribonacci_Sequence
{
    class Program
    {
        private static int[] numbers;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            numbers = new int[n];
            TribonacciSequence(n);

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static int TribonacciSequence(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (numbers[n - 1] != 0)
            {
                return numbers[n - 1];
            }

            if (n == 2 || n == 1)
            {
                numbers[0] = 1;

                if (numbers.Length > 1)
                {
                    numbers[1] = 1;
                }
                return 1;
            }

            int result = TribonacciSequence(n - 1) + TribonacciSequence(n - 2) + TribonacciSequence(n - 3);
            numbers[n - 1] = result;
            return result;
        }
    }
}
