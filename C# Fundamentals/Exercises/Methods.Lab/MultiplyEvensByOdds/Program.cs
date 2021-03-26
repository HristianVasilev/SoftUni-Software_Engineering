using System;
using System.Linq;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int result = GetMultipleOfEvenAndOdds(number);

            Console.WriteLine(result);    
        }

        private static int GetMultipleOfEvenAndOdds(string number)
        {
            int sumOfEvenDigits = GetSumOfEvenDigits(number);
            int sumOfOddDigits = GetSumOfOddDigits(number);

            return sumOfEvenDigits * sumOfOddDigits;
        }

        private static int GetSumOfOddDigits(string number)
        {
            int sumOfOddDigits = 0;

            for (int i = 0; i < number.Length; i++)
            {
                if (char.IsDigit(number[i]) && int.Parse(number[i].ToString()) % 2 != 0)
                {
                    sumOfOddDigits += int.Parse(number[i].ToString());
                }
            }

            return sumOfOddDigits;
        }

        private static int GetSumOfEvenDigits(string number)
        {
            int sumOfEvenDigits = 0;

            for (int i = 0; i < number.Length; i++)
            {
                if (char.IsDigit(number[i]) && int.Parse(number[i].ToString()) % 2 == 0)
                {
                    sumOfEvenDigits += int.Parse(number[i].ToString());
                }
            }

            return sumOfEvenDigits;
        }
    }
}
