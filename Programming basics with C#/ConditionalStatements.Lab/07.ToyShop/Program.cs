using System;

namespace _07.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double pricePuzzle = 2.60;
            double priceDoll = 3.00;
            double priceTeddyBear = 4.10;
            double priceMinion = 8.20;
            double priceTruck = 2.00;

            double vacancyPrice = double.Parse(Console.ReadLine());
            int puzzlesCount = int.Parse(Console.ReadLine());
            int dollsCount = int.Parse(Console.ReadLine());
            int teddyBearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            double totalMoney
                = puzzlesCount * pricePuzzle
                + dollsCount * priceDoll
                + teddyBearsCount * priceTeddyBear
                + minionsCount * priceMinion
                + trucksCount * priceTruck;

            int totalCount
                = puzzlesCount
                + dollsCount
                + teddyBearsCount
                + minionsCount
                + trucksCount;

            if (totalCount >= 50)
            {
                totalMoney = totalMoney * 0.75;
            }
            totalMoney -= totalMoney * 0.1;

            if (totalMoney >= vacancyPrice)
            {
                Console.WriteLine($"Yes! {(totalMoney - vacancyPrice):F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(vacancyPrice - totalMoney):f2} lv needed.");
            }

        }
    }
}
