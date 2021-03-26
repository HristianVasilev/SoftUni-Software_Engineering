using System;
using System.Numerics;

namespace _2.BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            BigInteger result = Factorial(num);
            Console.WriteLine(result);
        }

        private static BigInteger Factorial(int num)
        {
            if (num == 0 || num == 1)
            {
                return 1;
            }

            return num * Factorial(num - 1);
        }
    }
}
