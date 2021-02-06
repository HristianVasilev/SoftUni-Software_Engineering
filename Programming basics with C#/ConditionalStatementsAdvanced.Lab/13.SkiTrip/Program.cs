using System;
using System.Collections.Generic;

namespace _13.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> prices = new Dictionary<string, double>();

            prices.Add("room for one person", 18.00);
            prices.Add("apartment", 25.00);
            prices.Add("president apartment", 35.00);

            int days = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string mark = Console.ReadLine();

            if (days < 0 || !prices.ContainsKey(type))
            {
                Console.WriteLine("Error!");
                return;
            }

            int countOfDays = days - 1;
            double discount = 0;
            double price = prices[type];

            if (countOfDays < 10)
            {
                if (type == "room for one person")
                {
                    discount = 0;
                }
                else if (type == "apartment")
                {
                    discount = 0.30;
                }
                else if (type == "president apartment")
                {
                    discount = 0.10;
                }
            }
            else if (countOfDays >= 10 && countOfDays <= 15)
            {
                if (type == "room for one person")
                {
                    discount = 0;
                }
                else if (type == "apartment")
                {
                    discount = 0.35;
                }
                else if (type == "president apartment")
                {
                    discount = 0.15;
                }
            }
            else
            {
                if (type == "room for one person")
                {
                    discount = 0;
                }
                else if (type == "apartment")
                {
                    discount = 0.50;
                }
                else if (type == "president apartment")
                {
                    discount = 0.20;
                }
            }

            double result = (price * countOfDays) - (price * countOfDays) * discount;

            if (mark == "positive")
            {
                result += (result * 0.25);
            }
            else if (mark == "negative")
            {
                result -= (result * 0.10);
            }

            Console.WriteLine($"{result:F2}");
        }
    }
}
