using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequenceOfNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            bool isChanged = false;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                int number;
                int index;

                switch (command)
                {
                    case "Add":

                        number = int.Parse(tokens[1]);
                        sequenceOfNumbers.Add(number);
                        isChanged = true;

                        break;
                    case "Remove":

                        number = int.Parse(tokens[1]);
                        sequenceOfNumbers.Remove(number);
                        isChanged = true;

                        break;
                    case "RemoveAt":

                        index = int.Parse(tokens[1]);
                        sequenceOfNumbers.RemoveAt(index);
                        isChanged = true;

                        break;
                    case "Insert":

                        number = int.Parse(tokens[1]);
                        index = int.Parse(tokens[2]);
                        sequenceOfNumbers.Insert(index, number);
                        isChanged = true;

                        break;
                    case "Contains":

                        number = int.Parse(tokens[1]);
                        bool contains = sequenceOfNumbers.Contains(number);

                        if (contains)
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }

                        break;
                    case "PrintEven":

                        List<int> even = sequenceOfNumbers.Where(x => x % 2 == 0).ToList();
                        Print(even);

                        break;
                    case "PrintOdd":

                        List<int> odd = sequenceOfNumbers.Where(x => x % 2 != 0).ToList();
                        Print(odd);

                        break;
                    case "GetSum":

                        Console.WriteLine(sequenceOfNumbers.Sum());

                        break;
                    case "Filter":

                        string condition = tokens[1];
                        number = int.Parse(tokens[2]);

                        Filter(sequenceOfNumbers, condition, number);

                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            if (isChanged)
            {
                Print(sequenceOfNumbers);
            }
        }

        private static void Print(List<int> even)
        {
            Console.WriteLine(string.Join(' ', even));
        }

        private static void Filter(List<int> sequenceOfNumbers, string condition, int number)
        {
            Func<int, bool> predicate;

            switch (condition)
            {
                case "<":
                    predicate = x => x < number;
                    break;
                case "<=":
                    predicate = x => x <= number;
                    break;
                case ">":
                    predicate = x => x > number;
                    break;
                case ">=":
                    predicate = x => x >= number;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            List<int> filteredSequence = sequenceOfNumbers.Where(predicate).ToList();

            Console.WriteLine(string.Join(' ', filteredSequence));
        }
    }
}
