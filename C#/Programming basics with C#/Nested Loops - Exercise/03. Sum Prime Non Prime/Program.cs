using System;

namespace _03._Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumPrime = 0;
            int sumNonPrime = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "stop")
            {
                int number = int.Parse(input);

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                bool prime = true;
                for (int i = 2; i < 10; i++)
                {
                    if (number % i == 0 && number != i)
                    {
                        prime = false;
                        break;
                    }
                }

                if (prime)
                {
                    sumPrime += number;
                }
                else
                {
                    sumNonPrime += number;
                }
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
        }
    }
}
