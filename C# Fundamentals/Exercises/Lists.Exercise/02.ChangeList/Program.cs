using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int element = int.Parse(commandArgs[1]);

                switch (commandArgs[0])
                {
                    case "Delete":
                        Delete(sequence, element);

                        break;
                    case "Insert":
                        int position = int.Parse(commandArgs[2]);
                        Insert(sequence, element, position);

                        break;
                    default:
                        throw new InvalidOperationException("Invalid command!");
                }
            }

            PrintResult(sequence);
        }

        private static void PrintResult(List<int> sequence)
        {
            Console.WriteLine(string.Join(' ',sequence));
        }

        private static void Insert(List<int> sequence, int element, int position)
        {
            sequence.Insert(position, element);
        }

        private static void Delete(List<int> sequence, int element)
        {
            sequence.RemoveAll(x => x == element);
        }
    }
}
