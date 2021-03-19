using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> raceResults = new Dictionary<string, int>();

            string[] participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                string pattern = @"(?<name>[A-Za-z])";
                MatchCollection nameChars = Regex.Matches(input, pattern);

                string name = string.Join(string.Empty, nameChars.Select(x => x.Value));

                if (!participants.Contains(name))
                {
                    continue;
                }

                pattern = @"(?<distance>\d)";
                MatchCollection distanceChars = Regex.Matches(input, pattern);

                int distance = distanceChars.Select(x => int.Parse(x.Value)).Sum();

                AddPlayer(name, distance, ref raceResults);
            }

            string result = GetTop3Racers(raceResults);
            Console.WriteLine(result);
        }

        private static string GetTop3Racers(Dictionary<string, int> raceResults)
        {
            string[] orderedRacers = raceResults
                .OrderByDescending(x => x.Value)
                .Take(3)
                .Select(x => x.Key)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"1st place: {orderedRacers[0]}")
                .AppendLine($"2nd place: {orderedRacers[1]}")
                .AppendLine($"3rd place: {orderedRacers[2]}");

            return sb.ToString().TrimEnd();
        }

        private static void AddPlayer(string name, int distance, ref Dictionary<string, int> raceResults)
        {
            if (!raceResults.ContainsKey(name))
            {
                raceResults.Add(name, 0);
            }

            raceResults[name] += distance;
        }
    }
}
