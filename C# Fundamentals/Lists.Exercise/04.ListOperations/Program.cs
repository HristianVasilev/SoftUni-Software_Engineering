using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int number;
                int index;

                switch (commandArgs[0])
                {
                    case "Add":
                        number = int.Parse(commandArgs[1]);
                        integers.Add(number);

                        break;
                    case "Insert":
                        number = int.Parse(commandArgs[1]);
                        index = int.Parse(commandArgs[2]);

                        if (ValidIndex(integers,index))
                        {
                            integers.Insert(index, number);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;
                    case "Remove":
                        index = int.Parse(commandArgs[1]);

                        if (ValidIndex(integers, index))
                        {
                            integers.RemoveAt(index);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        
                        break;
                    case "Shift":
                        string direction = commandArgs[1];
                        int count = int.Parse(commandArgs[2]);
                        Shift(integers, direction, count);

                        break;

                    default:
                        throw new InvalidOperationException("Invalid command!");
                }
            }

            PrintResult(integers);
        }

        private static bool ValidIndex(List<int> integers, int index)
        {
            return index >= 0 && index < integers.Count;
        }

        private static void PrintResult(List<int> integers)
        {
            Console.WriteLine(string.Join(' ', integers));
        }

        private static void Shift(List<int> integers, string direction, int count)
        {
            if (direction == "left")
            {
                ShiftingLeft(integers, count);
            }
            else if (direction == "right")
            {
                ShiftingRight(integers, count);
            }
        }

        private static void ShiftingRight(List<int> integers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int number = integers[integers.Count - 1];
                integers.RemoveAt(integers.Count - 1);
                integers.Insert(0, number);
            }
        }

        private static void ShiftingLeft(List<int> integers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int number = integers[0];
                integers.RemoveAt(0);
                integers.Add(number);
            }
        }
    }
}
