using System;
using System.Text;

namespace _7.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double insertedMoney = 0;
            while (input != "Start")
            {
                double coin = double.Parse(input);   
                switch (coin)
                {
                    case 0.1:
                        insertedMoney += coin;
                        break;
                    case 0.2:
                        insertedMoney += coin;
                        break;
                    case 0.5:
                        insertedMoney += coin;
                        break;
                    case 1:
                        insertedMoney += coin;
                        break;
                    case 2:
                        insertedMoney += coin;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {coin:f1}");
                        break;
                }
                input = Console.ReadLine();
            }
            string product = Console.ReadLine();
            while (product != "End")
            {
                double cost = 0;
                switch (product)
                {
                    case "Nuts":
                        cost = 2;
                        break;
                    case "Water":
                        cost = 0.7;
                        break;
                    case "Crisps":
                        cost = 1.5;
                        break;
                    case "Soda":
                        cost = 0.8;
                        break;
                    case "Coke":
                        cost = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        product = Console.ReadLine();
                        continue;
                }
                if (insertedMoney-cost >= 0)
                {
                    insertedMoney -= cost;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                    Console.WriteLine($"Change: {insertedMoney:f2}");
                    return;
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {insertedMoney:f2}");
        }
    }
}
