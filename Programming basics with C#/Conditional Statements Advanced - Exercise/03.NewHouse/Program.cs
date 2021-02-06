using System;

namespace _03.NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            double roses = 5.00;
            double dahlias = 3.80;
            double tulips = 2.80;
            double narcissus = 3.00;
            double gladiolus = 2.50;

            string type = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double totalCost = 0;

            if (type == "Roses")
            {
                totalCost = roses * count;
                if (count > 80)
                {
                    totalCost *= 0.9;
                }
            }
            else if (type == "Dahlias")
            {
                totalCost = dahlias * count;
                if (count > 90)
                {
                    totalCost *= 0.85;
                }
            }
            else if (type == "Tulips")
            {
                totalCost = tulips * count;
                if (count > 80)
                {
                    totalCost *= 0.85;
                }
            }
            else if (type == "Narcissus")
            {
                totalCost = narcissus * count;
                if (count < 120)
                {
                    totalCost *= 1.15;
                }
            }
            else if (type == "Gladiolus")
            {
                totalCost = gladiolus * count;
                if (count < 80)
                {
                    totalCost *= 1.20;
                }
            }

            if (totalCost <= budget)
            {
                Console.WriteLine($"Hey, you have a great garden with {count} {type} and {(budget - totalCost):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(totalCost - budget):F2} leva more.");
            }
        }
    }
}
