using System;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int divisible = 0;

            if (n % 10 == 0)
            {
                divisible = 10;
            }
            else if (n % 7 == 0)
            {
                divisible = 7;
            }
            else if (n % 6 == 0)
            {
                divisible = 6;
            }
            else if (n % 3 == 0)
            {
                divisible = 3;
            }
            else if (n % 2 == 0)
            {
                divisible = 2;
            }

            if (divisible != 0)
            {
                Console.WriteLine($"The number is divisible by {divisible}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
