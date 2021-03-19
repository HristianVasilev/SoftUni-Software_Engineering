using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _1.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> furnitures = new List<string>();

            decimal totalMoney = 0m;

            string pattern = @">>(?<furniture>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";
            Regex regex = new Regex(pattern);

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = regex.Match(input);

                if (!match.Success)
                {
                    continue;
                }

                string furniture = match.Groups["furniture"].Value;
                decimal price = decimal.Parse(match.Groups["price"].Value);
                int quantity = int.Parse(match.Groups["quantity"].Value);

                furnitures.Add(furniture);
                totalMoney += price * quantity;
            }

            string result = GetResult(furnitures, totalMoney);
            Console.WriteLine(result);
        }

        private static string GetResult(List<string> furnitures, decimal totalMoney)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Bought furniture:")
                .AppendLine(string.Join(Environment.NewLine, furnitures))
                .AppendLine($"Total money spend: {totalMoney:f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
