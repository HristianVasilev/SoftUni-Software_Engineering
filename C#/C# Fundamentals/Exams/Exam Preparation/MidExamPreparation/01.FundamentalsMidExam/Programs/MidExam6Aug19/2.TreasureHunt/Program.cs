using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.TreasureHunt
{
    class Program
    {
        private static List<string> initialLoot;

        static void Main(string[] args)
        {
            initialLoot = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];

                switch (action)
                {
                    case "Loot":
                        Loot(commandArgs);

                        break;
                    case "Drop":
                        Drop(commandArgs);

                        break;
                    case "Steal":
                        Steal(commandArgs);

                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            if (initialLoot.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
                return;
            }

            double averageTreasureGain = GetAverageTreasureGain();
            Console.WriteLine($"Average treasure gain: {averageTreasureGain:f2} pirate credits.");
        }

        private static double GetAverageTreasureGain()
        {
            double result = initialLoot.Sum(l => l.Length) * 1.0 / (1.0 * initialLoot.Count);

            return result;
        }

        private static void Drop(string[] commandArgs)
        {
            int index = int.Parse(commandArgs[1]);

            if (index < 0 || index >= initialLoot.Count)
            {
                return;
            }

            string element = initialLoot[index];
            initialLoot.RemoveAt(index);
            initialLoot.Add(element);
        }

        private static void Steal(string[] commandArgs)
        {
            int count = int.Parse(commandArgs[1]);
            int ind = initialLoot.Count  - count;

            if (ind < 0)
            {
                ind = 0;
            }

            var stealed = initialLoot.GetRange(ind, count);
            initialLoot.RemoveRange(ind, count);

            Console.WriteLine(string.Join(", ", stealed));
        }

        private static void Loot(string[] commandArgs)
        {
            string[] items = commandArgs.Skip(1).Where(i => initialLoot.All(x => x != i)).Reverse().ToArray();
            initialLoot.InsertRange(0, items);
        }
    }
}
