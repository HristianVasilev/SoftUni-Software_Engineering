using System;
using System.Collections.Generic;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfVisitors = int.Parse(Console.ReadLine());
            string typeOfVisitors = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            Dictionary<string, Dictionary<string, decimal>> prices = new Dictionary<string, Dictionary<string, decimal>>();

            prices.Add("Students", new Dictionary<string, decimal>()
            {
                { "Friday", 8.45m },
                { "Saturday", 9.80m },
                { "Sunday", 10.46m }
            });

            prices.Add("Business", new Dictionary<string, decimal>()
            {
                { "Friday", 10.90m },
                { "Saturday", 15.60m },
                { "Sunday", 16m }
            });

            prices.Add("Regular", new Dictionary<string, decimal>()
            {
                { "Friday", 15m },
                { "Saturday", 20m },
                { "Sunday", 22.50m}
            });

            decimal price = prices[typeOfVisitors][dayOfWeek];
            decimal totalPrice = price * countOfVisitors;

            switch (typeOfVisitors)
            {
                case "Students":
                    if (countOfVisitors >= 30)
                    {
                        totalPrice *= 0.85m;
                    }

                    break;
                case "Business":
                    if (countOfVisitors >= 100)
                    {
                        totalPrice = totalPrice -=10*price;
                    }

                    break;
                case "Regular":
                    if (countOfVisitors >= 10 && countOfVisitors <= 20)
                    {
                        totalPrice *= 0.95m;
                    }

                    break;
            }

            string output = $"Total price: {totalPrice:F2}";
            Console.WriteLine(output);
        }
    }
}
