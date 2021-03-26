using System;
using System.Text.RegularExpressions;

namespace _3.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalIncome = 0;

            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                string pattern = @"[%](?<customer>[A-Z][a-z]+)[%]([^.|$%]+(?<!\d))?[<](?<product>\w+)[>]([^.|$%]+)?[|](?<count>\d+)[|]([^.|$%]+(?<!\d))?(?<price>(?:\d+|\d+.\d+))[$]";
                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);

                if (!match.Success)
                {
                    continue;
                }

                string customerName = match.Groups["customer"].Value;
                string product = match.Groups["product"].Value;
                int count = int.Parse(match.Groups["count"].Value);
                decimal price = decimal.Parse(match.Groups["price"].Value);
                decimal totalPrice = price * count*1.0m;

                totalIncome += totalPrice;

                Console.WriteLine($"{customerName}: {product} - {totalPrice:f2}");
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
