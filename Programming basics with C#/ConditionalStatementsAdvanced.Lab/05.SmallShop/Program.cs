using System;
using System.Collections.Generic;

namespace _05.SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> sofia = new Dictionary<string, double>()
            {
                {"coffee", 0.5},
                {"water", 0.8},
                {"beer", 1.20},
                {"sweets", 1.45},
                {"peanuts", 1.60}
            };

            Dictionary<string, double> plovdiv = new Dictionary<string, double>()
            {
                {"coffee", 0.40},
                {"water", 0.7},
                {"beer", 1.15},
                {"sweets", 1.30},
                {"peanuts", 1.50}
            };

            Dictionary<string, double> varna = new Dictionary<string, double>()
            {
                {"coffee", 0.45},
                {"water", 0.7},
                {"beer", 1.10},
                {"sweets", 1.35},
                {"peanuts", 1.55}
            };

            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());

            double price = 0;

            if (city == "Sofia")
            {
                price = sofia[product];
            }
            else if (city == "Plovdiv")
            {
                price = plovdiv[product];
            }
            else if (city == "Varna")
            {
                price = varna[product];
            }

            double result = count * price;
            Console.WriteLine($"{result:F2}");
        }
    }
}
