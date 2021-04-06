using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem2.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(=|\/)([A-Z][a-z]{2,})\1";

            var matches = Regex.Matches(input, pattern);

            string[] destinations = matches.Select(x => x.Groups[2].Value).ToArray();
            int travelPoints = destinations.Sum(x => x.Length);

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
