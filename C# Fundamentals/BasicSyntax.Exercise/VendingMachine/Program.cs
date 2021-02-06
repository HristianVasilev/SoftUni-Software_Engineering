using System;

namespace VendingMachine
{
    class Program
    {
        private static decimal totalMoney;

        static void Main(string[] args)
        {
            totalMoney = 0m;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Start")
            {
                double coin = double.Parse(input);

                if (!(coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2))
                {
                    Console.WriteLine($"Cannot accept {coin}");
                    continue;
                }
                totalMoney += (decimal)coin;
            }

            string purchase = string.Empty;
            while ((purchase = Console.ReadLine()) != "End")
            {
                string productName;
                decimal price;
                switch (purchase)
                {
                    case "Nuts":
                        price = 2.0m;
                        productName = "Nuts";
                        Purchase(price, productName);

                        break;
                    case "Water":
                        price = 0.7m;
                        productName = "Water";
                        Purchase(price, productName);

                        break;
                    case "Crisps":
                        price = 1.50m;
                        productName = "Crisps";
                        Purchase(price, productName);

                        break;
                    case "Soda":
                        price = 0.80m;
                        productName = "Soda";
                        Purchase(price, productName);

                        break;
                    case "Coke":
                        price = 1.0m;
                        productName = "Coke";
                        Purchase(price, productName);
                        break;

                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
            }

            Console.WriteLine($"Change: {totalMoney:F2}");
        }

        private static void Purchase(decimal price, string productName)
        {
            if (totalMoney - price >= 0)
            {
                Console.WriteLine($"Purchased {productName.ToLower()}");
                totalMoney -= price;
            }
            else
            {
                Console.WriteLine("Sorry, not enough money");
            }
        }
    }
}
