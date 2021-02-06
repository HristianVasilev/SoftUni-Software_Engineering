using System;
using System.Collections.Generic;

namespace _04.FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            int countOfFishers = int.Parse(Console.ReadLine());

            Dictionary<string, double> prices = new Dictionary<string, double>()
            {
                { "spring",3000},
                { "summer", 4200},
                { "autumn", 4200},
                { "winter",2600 }
            };

            double totalCost = prices[season];

            if (countOfFishers >= 0 && countOfFishers <= 6)
            {
                totalCost *= 0.90;
            }
            else if (countOfFishers > 6 && countOfFishers <= 11)
            {
                totalCost *= 0.85;
            }
            else if (countOfFishers > 11)
            {
                totalCost *= 0.75;
            }

            if (countOfFishers % 2 == 0 && season != "autumn")
            {
                totalCost *= 0.95;
            }

            double diff = budget - totalCost;

            if (budget >= totalCost)
            {
                Console.WriteLine($"Yes! You have {(budget - totalCost):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(totalCost - budget):F2} leva.");
            }
        }
    }
}
