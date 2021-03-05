using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.LegendaryFarming
{
    class Program
    {
        private static Dictionary<string, int> materials;
        private static Dictionary<string, int> junk;
        private static Dictionary<string, string> items;

        private const int required = 250;

        static void Main(string[] args)
        {
            materials = new Dictionary<string, int>()
            {
                { "shards", 0 },
                { "fragments", 0 },
                { "motes", 0 }
            };

            junk = new Dictionary<string, int>();

            items = new Dictionary<string, string>
            {
                {"Shadowmourne", "shards" },
                {"Valanyr","fragments" },
                {"Dragonwrath", "motes" }
            };

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string type = input[i + 1];

                    Share(quantity, type.ToLower());
                }
            }
        }

        private static void Share(int quantity, string type)
        {
            switch (type)
            {
                case "shards":
                case "fragments":
                case "motes":
                    AddMaterial(type, quantity, ref materials);

                    bool isMaterial = items.Values.Contains(type);

                    if (isMaterial && materials[type] >= required)
                    {
                        PrintResult(quantity, type);
                    }

                    break;
                default:
                    AddMaterial(type, quantity, ref junk);
                    break;
            }
        }

        private static void AddMaterial(string type, int quantity, ref Dictionary<string, int> collection)
        {
            if (!collection.ContainsKey(type))
            {
                collection.Add(type, 0);
            }

            collection[type] += quantity;
        }

        private static void PrintResult(int quantity, string type)
        {
            string winnerType = materials.Where(x => x.Value >= required).First().Key;
            string winner = items.First(x => x.Value == winnerType).Key;

            materials[type] -= required;

            materials = materials
               .OrderByDescending(x => x.Value)
               .ThenBy(x => x.Key)
               .ToDictionary(x => x.Key, x => x.Value);

            junk = junk
               .OrderBy(x => x.Key)
               .ToDictionary(x => x.Key, x => x.Value);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{winner} obtained!");

            Take(materials, ref sb);
            Take(junk, ref sb);

            Console.WriteLine(sb.ToString().TrimEnd());
            Environment.Exit(0);
        }

        private static void Take(Dictionary<string, int> collection, ref StringBuilder sb)
        {
            foreach (var itme in collection)
            {
                sb.AppendLine($"{itme.Key}: {itme.Value}");
            }
        }

    }
}
