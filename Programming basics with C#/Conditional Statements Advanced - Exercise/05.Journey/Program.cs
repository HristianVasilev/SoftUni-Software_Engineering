using System;

namespace _05.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double totalCost = 0;
            string destination = string.Empty;
            string type = string.Empty;
            if (season == "summer" && budget <= 1000)
            {
                type = "Camp";
            }
            else if (season == "winter" && budget <= 1000)
            {
                type = "Hotel";
            }
            else
            {
                type = "Hotel";
            }

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    totalCost = 0.30 * budget;
                }
                else if (season == "winter")
                {
                    totalCost = 0.70 * budget;
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    totalCost = 0.40 * budget;
                }
                else if (season == "winter")
                {
                    totalCost = 0.80 * budget;
                }
            }
            else
            {
                destination = "Europe";
                totalCost = 0.90 * budget;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{type} - {totalCost:F2}");
        }
    }
}
