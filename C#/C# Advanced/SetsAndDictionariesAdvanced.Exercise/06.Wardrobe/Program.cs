using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            byte n = byte.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = tokens[0];
                string[] clothes = tokens[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                AddClothes(color, clothes, ref wardrobe);
            }

            string target = Console.ReadLine();

            string result = GetResult(target, wardrobe);
            Console.WriteLine(result);
        }

        private static string GetResult(string target, Dictionary<string, Dictionary<string, int>> wardrobe)
        {
            string[] tokens = target.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string targetColor = tokens[0];
            string targetItem = tokens[1];

            StringBuilder sb = new StringBuilder();

            foreach (var color in wardrobe)
            {
                sb.AppendLine($"{color.Key} clothes:");

                foreach (var item in color.Value)
                {
                    if (color.Key == targetColor && item.Key == targetItem)
                    {
                        sb.AppendLine($"* {item.Key} - {item.Value} (found!)");
                        continue;
                    }

                    sb.AppendLine($"* {item.Key} - {item.Value}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static void AddClothes(string color, string[] clothes, ref Dictionary<string, Dictionary<string, int>> wardrobe)
        {
            if (!wardrobe.ContainsKey(color))
            {
                wardrobe.Add(color, new Dictionary<string, int>());
            }

            foreach (var item in clothes)
            {
                if (!wardrobe[color].ContainsKey(item))
                {
                    wardrobe[color].Add(item, 0);
                }

                wardrobe[color][item]++;
            }
        }
    }
}
