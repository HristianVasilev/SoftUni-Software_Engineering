using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, CityInfo> cities = new Dictionary<string, CityInfo>();

            string command;
            while ((command = Console.ReadLine()) != "Sail")
            {
                AddCity(ref cities, command);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Plunder":
                        Plunder(tokens, ref cities);

                        break;
                    case "Prosper":
                        Prosper(tokens, ref cities);
                        break;

                    default:
                        throw new InvalidOperationException("Invalid command!");
                }

            }

            PrintResult(ref cities);
        }

        private static void PrintResult(ref Dictionary<string, CityInfo> cities)
        {
            if (cities.Count == 0)
            {
                return;
            }

            var towns = cities
                .OrderByDescending(x => x.Value.Gold)
                .ThenBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

            foreach (var town in towns)
            {
                Console.WriteLine($"{town.Key} -> Population: {town.Value.Population} citizens, Gold: {town.Value.Gold} kg");
            }
        }

        private static void Prosper(string[] tokens, ref Dictionary<string, CityInfo> cities)
        {
            string town = tokens[1];
            int gold = int.Parse(tokens[2]);

            if (!cities.ContainsKey(town))
            {
                throw new InvalidOperationException("Non existent town!");
            }

            if (gold < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
                return;
            }

            cities[town].Gold += gold;
            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town].Gold} gold.");
        }

        private static void Plunder(string[] tokens, ref Dictionary<string, CityInfo> cities)
        {
            string town = tokens[1];
            int people = int.Parse(tokens[2]);
            int gold = int.Parse(tokens[3]);

            if (!cities.ContainsKey(town))
            {
                throw new InvalidOperationException("Non existent town!");
            }

            bool bann = false;

            if (cities[town].Population - people <= 0)
            {
                people = cities[town].Population;
                bann = true;
            }
            else
            {
                cities[town].Population -= people;
            }

            if (cities[town].Gold - gold <= 0)
            {
                gold = cities[town].Gold;
                bann = true;
            }
            else
            {
                cities[town].Gold -= gold;
            }

            Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

            if (bann)
            {
                cities.Remove(town);
                Console.WriteLine($"{town} has been wiped off the map!");
            }
        }


        private static void AddCity(ref Dictionary<string, CityInfo> cities, string command)
        {
            string[] tokens = command.Split("||", StringSplitOptions.RemoveEmptyEntries);

            string city = tokens[0];
            int population = int.Parse(tokens[1]);
            int gold = int.Parse(tokens[2]);

            if (!cities.ContainsKey(city))
            {
                cities.Add(city, new CityInfo(0, 0));
            }

            cities[city].Population += population;
            cities[city].Gold += gold;
        }

    }

    internal class CityInfo
    {
        public CityInfo(int population, int gold)
        {
            this.Population = population;
            this.Gold = gold;
        }

        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
