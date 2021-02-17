using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Inventory
{
    class Program
    {
        private static List<string> collectingItems;

        static void Main(string[] args)
        {
            collectingItems = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Craft!")
            {
                string[] commandArgs = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                string item = commandArgs[1];

                switch (action)
                {
                    case "Collect":

                        Collect(item);

                        break;
                    case "Drop":

                        Drop(item);

                        break;
                    case "Combine Items":

                        CombineItems(item);

                        break;
                    case "Renew":

                        Renew(item);

                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            PrintInventory();
        }

        private static void PrintInventory()
        {
            Console.WriteLine(string.Join(", ", collectingItems));
        }

        private static void Renew(string item)
        {
            if (!collectingItems.Contains(item))
            {
                return;
            }

            collectingItems.Remove(item);
            collectingItems.Add(item);
        }

        private static void CombineItems(string input)
        {
            string[] items = input.Split(':');
            string oldItem = items[0];
            string newItem = items[1];

            if (!collectingItems.Contains(oldItem))
            {
                return;
            }

            int indexOfOldItem = collectingItems.IndexOf(oldItem);
            collectingItems.Insert(indexOfOldItem + 1, newItem);
        }

        private static void Drop(string item)
        {
            collectingItems.Remove(item);
        }

        private static void Collect(string item)
        {
            if (collectingItems.Contains(item))
            {
                return;
            }

            collectingItems.Add(item);
        }
    }
}
