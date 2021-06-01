using System;
using System.Collections.Generic;
using System.Text;

namespace _04.CitiesByContinentAndCountry
{
    class Program
    {
        private static Dictionary<string, Dictionary<string, List<string>>> cities;

        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            cities = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                AddData(continent, country, city);
            }

            string result = GetResult(cities);
            Console.WriteLine(result);
        }

        private static string GetResult(Dictionary<string, Dictionary<string, List<string>>> cities)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var continent in cities)
            {
                sb.AppendLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    sb.AppendLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static void AddData(string continent, string country, string city)
        {
            if (!cities.ContainsKey(continent))
            {
                cities.Add(continent, new Dictionary<string, List<string>>());
            }

            if (!cities[continent].ContainsKey(country))
            {
                cities[continent].Add(country, new List<string>());
            }

            cities[continent][country].Add(city);
        }
    }
}
