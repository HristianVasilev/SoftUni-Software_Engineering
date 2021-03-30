using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Plant> plantsInfo = new Dictionary<string, Plant>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);

                RegisterPlant(tokens, ref plantsInfo);
            }

            string command;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] tokens = command.Split(":");
                string action = tokens[0];

                string info = tokens[1].Trim();

                switch (action)
                {
                    case "Rate":
                        Rate(info, ref plantsInfo);
                        break;
                    case "Update":
                        Update(info, ref plantsInfo);
                        break;
                    case "Reset":
                        Reset(info, ref plantsInfo);
                        break;

                    default:
                        throw new NotImplementedException("Invalid command!");
                }
            }

            PrintResult(ref plantsInfo);

        }

        private static void PrintResult(ref Dictionary<string, Plant> plantsInfo)
        {
            Console.WriteLine("Plants for the exhibition:");

            Func<KeyValuePair<string, Plant>, double> ordering = x =>
            {
                if (x.Value.Rating.Count == 0)
                {
                    return 0;
                }

                return x.Value.Rating.Average();
            };

            var collection = plantsInfo.OrderByDescending(x => x.Value.Rarity)
                .ThenByDescending(ordering)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var plant in collection)
            {
                double rating;

                if (plant.Value.Rating.Count == 0)
                {
                    rating = 0;
                }
                else
                {
                    rating = plant.Value.Rating.Average();
                }

                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {rating:f2}");
            }
        }



        private static void Reset(string plant, ref Dictionary<string, Plant> plantsInfo)
        {
            if (!plantsInfo.ContainsKey(plant))
            {
                Console.WriteLine("error");
                return;
            }

            plantsInfo[plant].Rating.Clear();
        }

        private static void Update(string info, ref Dictionary<string, Plant> plantsInfo)
        {
            string[] tokens = info.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            string plant = tokens[0];
            int newRarity = int.Parse(tokens[1]);

            if (!plantsInfo.ContainsKey(plant))
            {
                Console.WriteLine("error");
                return;
            }

            plantsInfo[plant].Rarity = newRarity;
        }

        private static void Rate(string info, ref Dictionary<string, Plant> plantsInfo)
        {
            string[] tokens = info.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            string plant = tokens[0];

            if (!plantsInfo.ContainsKey(plant))
            {
                Console.WriteLine("error");
                return;
            }

            double rating = double.Parse(tokens[1]);

            plantsInfo[plant].Rating.Add(rating);
        }



        private static void RegisterPlant(string[] tokens, ref Dictionary<string, Plant> plantsInfo)
        {
            string plant = tokens[0];
            int rarity = int.Parse(tokens[1]);

            if (!plantsInfo.ContainsKey(plant))
            {
                plantsInfo.Add(plant, new Plant());
            }

            plantsInfo[plant].Rarity = rarity;
        }
    }

    class Plant
    {
        public Plant()
        {
            this.Rating = new List<double>();
        }

        public int Rarity { get; set; }
        public List<double> Rating { get; set; }
    }

}
