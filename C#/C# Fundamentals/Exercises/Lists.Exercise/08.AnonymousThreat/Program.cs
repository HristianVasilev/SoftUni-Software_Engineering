using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    class Program
    {
        private static List<string> inputArr;

        static void Main(string[] args)
        {
            inputArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (commandArgs[0])
                {
                    case "merge":
                        int startIndex = int.Parse(commandArgs[1]);
                        int endIndex = int.Parse(commandArgs[2]);
                        Merge(startIndex, endIndex);

                        break;
                    case "divide":
                        int index = int.Parse(commandArgs[1]);
                        int partitions = int.Parse(commandArgs[2]);
                        Divide(index, partitions);

                        break;
                    default:
                        throw new InvalidOperationException("Invalid command!");
                }
            }

            Console.WriteLine(string.Join(' ', inputArr));
        }

        private static void Divide(int index, int partitions)
        {
            if (!ValidateIndex(index))
            {
                throw new IndexOutOfRangeException();
            }

            string item = inputArr[index];
            int partitionLength;
            string lastItem = string.Empty;

            List<string> dividedItems = new List<string>();

            if (item.Length % partitions == 0)
            {
                partitionLength = item.Length / partitions;
            }
            else
            {
                partitionLength = item.Length % partitions;
                int startIndex = partitionLength * partitions;
                lastItem = item.Substring(startIndex, item.Length - startIndex);
            }

            dividedItems = GetItems(dividedItems, partitions, partitionLength, item);

            inputArr.RemoveAt(index);
            inputArr.InsertRange(index, dividedItems);

            if (lastItem != string.Empty)
            {
                dividedItems.Add(lastItem);
            }
        }

        private static List<string> GetItems(List<string> dividedItems, int partitions, int partitionLength, string item)
        {
            int startIndex = 0;

            for (int i = 0; i < partitions; i++)
            {
                string currentItem = item.Substring(startIndex, partitionLength);
                dividedItems.Add(currentItem);
                startIndex += partitionLength;
            }

            return dividedItems;
        }

        private static void Merge(int startIndex, int endIndex)
        {
            if (!ValidateIndex(startIndex))
            {
                startIndex = 0;
            }

            if (!ValidateIndex(endIndex))
            {
                endIndex = inputArr.Count - 1;
            }

            int count = endIndex - startIndex + 1;
            string mergedItem = string.Join("", inputArr.GetRange(startIndex, count));
            inputArr.RemoveRange(startIndex, count);
            inputArr.Insert(startIndex, mergedItem);
        }

        private static bool ValidateIndex(int index)
        {
            return index >= 0 && index < inputArr.Count;
        }
    }
}
