using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _5.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> results = new List<string>();
            string[] demons = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(e => e.Trim())
                .ToArray();

            foreach (var demon in demons)
            {
                int demonsHealth = GetDemonsHealth(demon);
                double damage = GetDamage(demon);

                results.Add($"{demon} - {demonsHealth} health, {damage:f2} damage");
            }

            Console.WriteLine(string.Join(Environment.NewLine, results.OrderBy(x => x)));
        }

        private static double GetDamage(string input)
        {
            string pattern = @"\d+\.\d+|-\d+\.\d+|\d+|-\d+";

            double sum = Regex.Matches(input, pattern).Sum(x => double.Parse(x.Value));

            string patternMultiply = @"\*";
            int multiplyTimes = Regex.Matches(input, patternMultiply).Count;

            if (multiplyTimes > 0)
            {
                sum *= (2 * multiplyTimes);
            }

            string patternDivide = @"\\";
            int divideTimes = Regex.Matches(input, patternDivide).Count;

            if (divideTimes > 0)
            {
                sum /= (2 * divideTimes);
            }

            return sum;
        }

        private static int GetDemonsHealth(string input)
        {
            string pattern = @"[^0-9+*/\-.]";

            MatchCollection matches = Regex.Matches(input, pattern);

            if (matches.Count == 0)
            {
                return 0;
            }

            int sum = matches.Sum(x => char.Parse(x.Value));
            return sum;
        }
    }
}
