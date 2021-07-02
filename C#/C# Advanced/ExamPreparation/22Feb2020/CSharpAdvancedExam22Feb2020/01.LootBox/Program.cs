using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> secondBox = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            List<int> claimedItems = new List<int>();

            string emptyBox = OperateItems(firstBox, secondBox, ref claimedItems);
            string claimedResult = GetClaimedItemsResult(claimedItems);
            Console.WriteLine($"{emptyBox}{Environment.NewLine}{claimedResult}");
        }

        private static string GetClaimedItemsResult(List<int> claimedItems)
        {
            int sum = claimedItems.Sum();

            if (sum >= 100)
            {
                return $"Your loot was epic! Value: {sum}";
            }

            return $"Your loot was poor... Value: {sum}";
        }

        private static string OperateItems(Queue<int> firstBox, Stack<int> secondBox, ref List<int> claimedItems)
        {
            while (firstBox.Count != 0 && secondBox.Count != 0)
            {
                int sum = firstBox.Peek() + secondBox.Peek();

                if (sum % 2 == 0)
                {
                    firstBox.Dequeue();
                    secondBox.Pop();

                    claimedItems.Add(sum);
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if (firstBox.Count == 0)
            {
                return "First lootbox is empty";
            }
            else
            {
                return "Second lootbox is empty";
            }
        }
    }
}
