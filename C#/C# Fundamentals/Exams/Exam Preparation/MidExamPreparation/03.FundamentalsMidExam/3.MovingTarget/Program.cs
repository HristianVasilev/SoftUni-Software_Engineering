using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MovingTarget
{
    class Program
    {
        private static List<int> targets;

        static void Main(string[] args)
        {
            targets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int index = int.Parse(commandArgs[1]);
                int secondArg = int.Parse(commandArgs[2]); ;

                switch (commandArgs[0])
                {
                    case "Shoot":
                        int power = secondArg;
                        Shoot(index, power);

                        break;
                    case "Add":
                        int value = secondArg;
                        Add(index, value);

                        break;
                    case "Strike":
                        int radius = secondArg;
                        Strike(index, radius);

                        break;

                    default:
                        throw new InvalidOperationException();
                }
            }


            Console.WriteLine(string.Join('|',targets));
        }

        private static void Strike(int index, int radius)
        {
            int startIndex = index - radius;
            int endIndex = index + radius;

            if (!ValidIndex(startIndex) || !ValidIndex(endIndex))
            {
                Console.WriteLine("Strike missed!");
                return;
            }

            int count = endIndex - startIndex + 1;

            targets.RemoveRange(startIndex, count);
        }

        private static void Add(int index, int value)
        {
            if (!ValidIndex(index))
            {
                Console.WriteLine("Invalid placement!");
                return;
            }

            targets.Insert(index, value);
        }

        private static void Shoot(int index, int power)
        {
            if (!ValidIndex(index))
            {
                return;
            }

            targets[index] -= power;

            if (targets[index] <= 0)
            {
                targets.RemoveAt(index);
            }
        }

        private static bool ValidIndex(int index)
        {
            return index >= 0 && index < targets.Count;
        }
    }
}
