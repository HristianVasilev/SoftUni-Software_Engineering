using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double priceForClothes = double.Parse(Console.ReadLine());

            budget = budget * 0.90;
            if (statists > 150)
            {
                budget -= (statists * priceForClothes) * 0.90;
            }
            else
            {
                budget -= (statists * priceForClothes);
            }

            if (budget < 0)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(budget):F2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget:F2} leva left.");
            }

        }
    }
}
