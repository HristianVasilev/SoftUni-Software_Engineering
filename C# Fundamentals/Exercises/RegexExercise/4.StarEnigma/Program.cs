using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _4.StarEnigma
{
    class Program
    {
        private static List<string> attackedPlanets;
        private static List<string> destroyedPlanets;

        static void Main(string[] args)
        {
            attackedPlanets = new List<string>();
            destroyedPlanets = new List<string>();

            byte countOfMessages = byte.Parse(Console.ReadLine());

            for (int i = 0; i < countOfMessages; i++)
            {
                string message = Console.ReadLine();

                int countOfDecrease = CalculateCountOfDecrease(message);

                string decreasedMessage = DecreaseSymbols(message, countOfDecrease);

                AnalyzeMessage(decreasedMessage);
            }

            string result = GetResult();
            Console.WriteLine(result);
        }

        private static string GetResult()
        {
            StringBuilder sb = new StringBuilder();

            string attackedPlanetsResult = OrderAndGetCollection(attackedPlanets, "Attacked");
            string destroyedPlanetsResult = OrderAndGetCollection(destroyedPlanets, "Destroyed");

            sb.AppendLine(attackedPlanetsResult)
                .AppendLine(destroyedPlanetsResult);

            return sb.ToString().TrimEnd();
        }

        private static string OrderAndGetCollection(IEnumerable<string> collection, string type)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{type} planets: {collection.Count()}");

            foreach (var planet in collection.OrderBy(e => e))
            {
                sb.AppendLine($"-> {planet}");
            }

            return sb.ToString().TrimEnd();
        }


        private static void AnalyzeMessage(string decreasedMessage)
        {
            string planet = GetPlanet(decreasedMessage);
            int? population = GetPopulation(decreasedMessage);
            string attackType = GetAttackType(decreasedMessage);
            int? soldiersCount = GetSoldiersCount(decreasedMessage);

            if (planet is null || population is null || attackType is null || soldiersCount is null)
            {
                return;
            }

            if (attackType == "A")
            {
                attackedPlanets.Add(planet);
            }
            else if (attackType == "D")
            {
                destroyedPlanets.Add(planet);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private static int? GetSoldiersCount(string decreasedMessage)
        {
            string pattern = @"->(?<soldiersCount>\d+)";
            Match match = Regex.Match(decreasedMessage, pattern);

            if (!match.Success)
            {
                return null;
            }

            return int.Parse(match.Groups["soldiersCount"].Value);
        }

        private static string GetAttackType(string decreasedMessage)
        {
            string pattern = @"!(?<attackType>[A,D])!";
            Match match = Regex.Match(decreasedMessage, pattern);

            if (!match.Success)
            {
                return null;
            }

            return match.Groups["attackType"].Value;
        }

        private static int? GetPopulation(string decreasedMessage)
        {
            string pattern = @":(?<population>\d+)";
            Match match = Regex.Match(decreasedMessage, pattern);

            if (!match.Success)
            {
                return null;
            }

            return int.Parse(match.Groups["population"].Value);
        }

        private static string GetPlanet(string decreasedMessage)
        {
            string pattern = @"@(?<planet>[A-Za-z]+)";
            Match match = Regex.Match(decreasedMessage, pattern);

            if (!match.Success)
            {
                return null;
            }

            return match.Groups["planet"].Value;
        }


        private static string DecreaseSymbols(string message, int countOfDecrease)
        {
            return string.Join(string.Empty, message.Select(c => (char)(c - countOfDecrease)));
        }

        private static int CalculateCountOfDecrease(string message)
        {
            string pattern = @"[s,t,a,r]";

            return Regex.Matches(message, pattern, RegexOptions.IgnoreCase).Count;
        }
    }
}
