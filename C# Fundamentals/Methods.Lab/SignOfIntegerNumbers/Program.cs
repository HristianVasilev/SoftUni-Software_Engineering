using System;

namespace SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string result = GetSign(n);
            Console.WriteLine(result);
        }

        private static string GetSign(int n)
        {
            string message = string.Empty;
            if (n > 0)
            {
                message = $"The number {n} is positive.";
            }
            else if (n == 0)
            {
                message = $"The number {n} is zero.";
            }
            else
            {
                message = $"The number {n} is negative.";
            }

            return message;
        }
    }
}
