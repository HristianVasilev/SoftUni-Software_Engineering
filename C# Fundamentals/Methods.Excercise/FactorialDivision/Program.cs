using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            long firstResult = Factorial(Math.Abs(n1));
            long secondResult = Factorial(Math.Abs(n2));

            double result = firstResult * 1.0 / (1.0 * secondResult);

            if (IsResultNegative(n1, n2))
            {
                result *= -1.0;
            }

            Console.WriteLine($"{result:F2}");
        }

        private static bool IsResultNegative(int n1, int n2)
        {
            bool result = false;

            if (n1 < 0 && n2 >= 0)
            {
                result = true;
            }
            else if (n2 < 0 && n1 >= 0)
            {
                result = true;
            }

            return result;
        }

        private static long Factorial(int n)
        {
            if (n == 1 || n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
