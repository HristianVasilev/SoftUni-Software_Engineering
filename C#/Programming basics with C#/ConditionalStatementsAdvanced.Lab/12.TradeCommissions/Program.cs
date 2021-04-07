using System;

namespace _12.TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double trade = double.Parse(Console.ReadLine());

            if (trade < 0)
            {
                Console.WriteLine("error");
                return;
            }

            double percent = 0;

            if (city == "Sofia")
            {
                if (trade >= 0 && trade <= 500)
                {
                    percent = 5;
                }
                else if (trade > 500 && trade <= 1000)
                {
                    percent = 7;
                }
                else if (trade > 1000 && trade <= 10000)
                {
                    percent = 8;
                }
                else if (trade > 10000)
                {
                    percent = 12;
                }
            }
            else if (city == "Varna")
            {
                if (trade >= 0 && trade <= 500)
                {
                    percent = 4.5;
                }
                else if (trade > 500 && trade <= 1000)
                {
                    percent = 7.5;
                }
                else if (trade > 1000 && trade <= 10000)
                {
                    percent = 10;
                }
                else if (trade > 10000)
                {
                    percent = 13;
                }
            }
            else if (city == "Plovdiv")
            {
                if (trade >= 0 && trade <= 500)
                {
                    percent = 5.5;
                }
                else if (trade > 500 && trade <= 1000)
                {
                    percent = 8;
                }
                else if (trade > 1000 && trade <= 10000)
                {
                    percent = 12;
                }
                else if (trade > 10000)
                {
                    percent = 14.5;
                }
            }
            else
            {
                Console.WriteLine("error");
                return;
            }
            double result = trade * percent / 100;
            Console.WriteLine($"{result:F2}");
        }
    }
}
