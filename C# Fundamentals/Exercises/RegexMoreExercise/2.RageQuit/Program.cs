using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string input = Console.ReadLine();

            string pattern = @"(?<symbols>\D+)(?<count>\d+)";

            MatchCollection collection = Regex.Matches(input, pattern);

            foreach (Match match in collection)
            {
                string symbols = match.Groups["symbols"].Value.ToUpper();
                int count = int.Parse(match.Groups["count"].Value);

                Replicate(ref sb, symbols, count);
            }

            string result = sb.ToString().TrimEnd();
            int uniqueSymbols = result.ToCharArray().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
            Console.WriteLine(result);
        }

        private static void Replicate(ref StringBuilder sb, string symbols, int count)
        {
            for (int i = 0; i < count; i++)
            {
                sb.Append(symbols);
            }
        }

    }
}
