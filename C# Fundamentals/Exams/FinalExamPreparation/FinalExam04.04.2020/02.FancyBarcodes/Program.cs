using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            string pattern = @"(@#+)([A-Z][A-Za-z0-9]{4,}[A-Z])(@#+)";

            for (byte i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    ProductGroup(match);
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }

        private static void ProductGroup(Match match)
        {
            MatchCollection collection = Regex.Matches(match.Groups[2].Value, @"\d");

            if (collection.Count > 0)
            {
                string productGroup = string.Join(string.Empty, collection.Select(x => x.Value));
                Console.WriteLine($"Product group: {productGroup}");
            }
            else
            {
                Console.WriteLine("Product group: 00");
            }
        }
    }
}
