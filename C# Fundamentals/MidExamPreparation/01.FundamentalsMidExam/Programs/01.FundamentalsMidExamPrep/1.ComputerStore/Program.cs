using System;
using System.Text;

namespace _1.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalPriceWithoutTaxes = 0m;

            string input = Console.ReadLine();

            while (input != "special" && input != "regular")
            {
                decimal price = decimal.Parse(input);

                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }

                totalPriceWithoutTaxes += price;

                input = Console.ReadLine();
            }

            decimal taxes = totalPriceWithoutTaxes * 0.2m;
            decimal totalPrice = totalPriceWithoutTaxes + taxes;

            if (input == "special")
            {
                totalPrice *= 0.9m;
            }

            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Congratulations you've just bought a new computer!");
            sb.AppendLine($"Price without taxes: {totalPriceWithoutTaxes:f2}$");
            sb.AppendLine($"Taxes: {taxes:f2}$");
            sb.AppendLine($"-----------");
            sb.AppendLine($"Total price: {totalPrice:f2}$");

            Console.WriteLine(sb.ToString().TrimEnd());
        }

    }
}
