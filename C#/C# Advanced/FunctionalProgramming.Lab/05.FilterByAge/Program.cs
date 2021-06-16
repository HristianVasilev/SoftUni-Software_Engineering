using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> persons = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                AddPerson(name, age, ref persons);
            }

            string condition = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            string result = GetResult(condition, ageFilter, format, persons);
            Console.WriteLine(result);
        }

        private static string GetResult(string condition, int ageFilter, string format, Dictionary<string, int> persons)
        {
            string[] filtered;

            Func<KeyValuePair<string, int>, bool> conditionPredicate;

            switch (condition)
            {
                case "younger":
                    conditionPredicate = x => x.Value < ageFilter;
                    break;
                case "older":
                    conditionPredicate = x => x.Value >= ageFilter;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            Func<KeyValuePair<string, int>, string> formatPredicate;

            switch (format)
            {
                case "name":
                    formatPredicate = x => $"{x.Key}";

                    break;
                case "age":
                    formatPredicate = x => $"{x.Value}";

                    break;
                case "name age":
                    formatPredicate = x => $"{x.Key} - {x.Value}";

                    break;
                default:
                    throw new InvalidOperationException();
            }

            filtered = persons.Where(conditionPredicate).Select(formatPredicate).ToArray();

            return string.Join(Environment.NewLine, filtered);
        }

        private static void AddPerson(string name, int age, ref Dictionary<string, int> persons)
        {
            if (!persons.ContainsKey(name))
            {
                persons.Add(name, age);
            }
        }
    }
}
