using System;
using System.Collections.Generic;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            Func<string, string, Predicate<string>> func = (criteria, stringValue) =>
            {
                Predicate<string> predicate;

                switch (criteria)
                {
                    case "StartsWith":
                        predicate = name => name.StartsWith(stringValue);

                        break;
                    case "EndsWith":
                        predicate = name => name.EndsWith(stringValue);

                        break;
                    case "Length":
                        predicate = name => name.Length == (int.Parse(stringValue));

                        break;

                    default:
                        throw new InvalidOperationException();
                }

                return predicate;
            };

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string criteria = tokens[1];
                string stringValue = tokens[2];

                Predicate<string> predicate = func(criteria, stringValue);

                switch (action)
                {
                    case "Remove":
                        Remove(ref names, predicate);

                        break;
                    case "Double":
                        Double(ref names, predicate);

                        break;
                    default:
                        throw new InvalidOperationException("Invalid command!");
                }
            }

            string result = GetResult(names);
            Console.WriteLine(result);
        }

        private static void Remove(ref List<string> names, Predicate<string> predicate)
        {
            names.RemoveAll(predicate);
        }

        private static void Double(ref List<string> names, Predicate<string> predicate)
        {
            var matches = names.FindAll(predicate);

            foreach (var match in matches)
            {
                if (match == null)
                {
                    continue;
                }

                int index = names.IndexOf(match);
                names.Insert(index, match);
            }
        }

        private static string GetResult(List<string> names)
        {
            if (names.Count == 0)
            {
                return "Nobody is going to the party!";
            }

            return $"{string.Join(", ", names)} are going to the party!";
        }
    }
}
