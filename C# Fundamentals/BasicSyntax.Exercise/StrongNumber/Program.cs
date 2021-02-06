using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int result = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int digit = int.Parse(number[i].ToString());
                result += Factorial(digit);
            }

            int num = int.Parse(number);

            if (result == num)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        private static int Factorial(int digit)
        {
            if (digit == 1 || digit == 0)
            {
                return 1;
            }

            return digit * Factorial(digit - 1);
        }
    }
}
