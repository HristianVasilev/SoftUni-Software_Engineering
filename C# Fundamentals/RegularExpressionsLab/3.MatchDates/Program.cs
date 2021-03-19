using System;
using System.Text.RegularExpressions;

namespace _3.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<=^|\s)(?<day>\d{2})(?<separator>\/|\-|\.)(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})(?!\d)";
            Regex regex = new Regex(pattern);

            MatchCollection collection = regex.Matches(input);

            foreach (Match date in collection)
            {
                string day = date.Groups["day"].Value;
                string month = date.Groups["month"].Value;
                string year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }

        }
    }
}
