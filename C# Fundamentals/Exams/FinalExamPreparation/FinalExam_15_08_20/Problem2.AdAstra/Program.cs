using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem2.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int totalCalories = 0;
            List<string> food = new List<string>();

            string pattern = @"([|#])(?<itemName>[A-Za-z\s]+)\1(?<expirationDate>(?<day>\d{2})\/(?<month>\d{2})\/(?<year>\d{2}))\1(?<calories>\d{1,5})\1";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string item = match.Groups["itemName"].Value;
                string bestBefore = match.Groups["expirationDate"].Value;
                int nutrition = int.Parse(match.Groups["calories"].Value);

                totalCalories += nutrition;

                string currentFood = $"Item: {item}, Best before: {bestBefore}, Nutrition: {nutrition}";
                food.Add(currentFood);
            }

            string result = GetResult(food, totalCalories);
            Console.WriteLine(result);
        }

        private static string GetResult(List<string> food, int totalCalories)
        {
            int caloriesPerDay = 2000;

            int days = totalCalories / caloriesPerDay;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"You have food to last you for: {days} days!");
            sb.AppendLine(string.Join(Environment.NewLine, food));

            return sb.ToString().TrimEnd();
        }
    }
}
