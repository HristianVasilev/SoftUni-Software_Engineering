using System;
using System.Linq;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            TopNumber(n);
        }

        private static void TopNumber(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (IsDivisibleByEight(i) && HasAtLeastOneOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static int GetSumOfDigits(int n)
        {
            int[] arr = n.ToString().ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();

            return arr.Sum();
        }
        private static bool IsDivisibleByEight(int n)
        {
            int sumOfDigits = GetSumOfDigits(n);

            if (sumOfDigits % 8 == 0)
            {
                return true;
            }

            return false;
        }
        private static bool HasAtLeastOneOddDigit(int n)
        {
            int[] arr = n.ToString().ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
