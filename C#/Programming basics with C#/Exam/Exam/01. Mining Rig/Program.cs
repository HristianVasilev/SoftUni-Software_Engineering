using System;

namespace _01._Mining_Rig
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceForVideoCard = int.Parse(Console.ReadLine());
            int priceForAdapter = int.Parse(Console.ReadLine());
            double consumationForDay = double.Parse(Console.ReadLine());
            double earningsPerDay = double.Parse(Console.ReadLine());

            double videoCards = priceForVideoCard * 13;
            double adapters = priceForAdapter * 13;
            double others = 1000;

            double totalCost = videoCards + adapters + others;

            double realEarnings = 13 * (earningsPerDay - consumationForDay);

            double days = Math.Ceiling(totalCost / realEarnings);

            Console.WriteLine(totalCost);
            Console.WriteLine(days);
        }
    }
}
