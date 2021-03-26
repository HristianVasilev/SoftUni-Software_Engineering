using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sugarCubes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command;
            while ((command = Console.ReadLine()) != "Mort")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                int value = int.Parse(commandArgs[1]);

                switch (action)
                {
                    case "Add":
                        sugarCubes.Add(value);

                        break;
                    case "Remove":
                        sugarCubes.Remove(value);

                        break;
                    case "Replace":
                        int replacement = int.Parse(commandArgs[2]);

                        int index = sugarCubes.IndexOf(value);
                        sugarCubes[index] = replacement;

                        break;
                    case "Collapse":
                        sugarCubes.RemoveAll(x => x < value);

                        break;

                    default:
                        throw new InvalidOperationException();
                }
            }

            Console.WriteLine(string.Join(" ",sugarCubes));
        }
    }
}
