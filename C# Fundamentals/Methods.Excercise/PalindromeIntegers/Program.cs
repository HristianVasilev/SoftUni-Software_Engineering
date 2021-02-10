using System;
using System.Linq;

namespace PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                if (IsPalindrome(input))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        private static bool IsPalindrome(string input)
        {
            int[] digitsOfNumber = input.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
            byte lastIndex = (byte)(digitsOfNumber.Length - 1);

            for (int i = 0; i < digitsOfNumber.Length / 2; i++)
            {
                if (digitsOfNumber[i] != digitsOfNumber[lastIndex--])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
