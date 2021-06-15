using System;
using System.Collections.Generic;

namespace _11.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            List<string> filters = new List<string>();

            Func<string, string, Predicate<string>> func = (filterType, filterParameter) =>
            {
                Predicate<string> predicate;

                switch (filterType)
                {
                    case "Starts with":
                        predicate = name => name.StartsWith(filterParameter);

                        break;
                    case "Ends with":
                        predicate = name => name.EndsWith(filterParameter);

                        break;
                    case "Length":
                        predicate = name => name.Length == int.Parse(filterParameter);

                        break;
                    case "Contains":
                        predicate = name => name.Contains(filterParameter);

                        break;

                    default:
                        throw new InvalidOperationException();
                }

                return predicate;
            };

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] tokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string filterType = tokens[1];
                string filterParameter = tokens[2];

                string predicateArguments = $"{filterType};{filterParameter}";

                switch (command)
                {
                    case "Add filter":
                        filters.Add(predicateArguments);

                        break;
                    case "Remove filter":
                        filters.Remove(predicateArguments);

                        break;

                    default:
                        throw new InvalidOperationException();
                }
            }

            string result = GetResult(names, filters, func);
            Console.WriteLine(result);
        }

        private static string GetResult(List<string> names, List<string> filters, Func<string, string, Predicate<string>> func)
        {
            foreach (var filter in filters)
            {
                string[] filterArguments = filter.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string filterType = filterArguments[0];
                string filterParameter = filterArguments[1];

                Predicate<string> predicate = func(filterType, filterParameter);

                for (int i = 0; i < names.Count; i++)
                {
                    if (predicate(names[i]))
                    {
                        names.Remove(names[i]);
                    }
                }
            }

            return string.Join(' ', names);
        }
    }
}
