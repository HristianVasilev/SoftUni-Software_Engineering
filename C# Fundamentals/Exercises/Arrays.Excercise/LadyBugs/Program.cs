using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        private static bool[] field;

        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());

            int[] indexesWithBugs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            field = new bool[sizeOfField];
            FillTheFieldWithBugs(indexesWithBugs);

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int actualIndex = int.Parse(commandArgs[0]);
                string direction = commandArgs[1];
                int steps = int.Parse(commandArgs[2]);

                if (actualIndex < 0 || actualIndex > field.Length - 1)
                {
                    continue;
                }

                if (field[actualIndex] == false)
                {
                    continue;
                }

                field[actualIndex] = false;
                int newIndex = DefineNewIndex(actualIndex, direction, steps);

                if (newIndex < 0 || newIndex > field.Length - 1)
                {
                    continue;
                }

                Move(actualIndex, newIndex, steps);
            }


            PrintResult();
        }

        private static void PrintResult()
        {
            for (int i = 0; i < field.Length; i++)
            {
                int n = 0;

                if (field[i] == true)
                {
                    n = 1;
                }

                Console.Write($"{n} ");
            }
        }

        private static int DefineNewIndex(int actualIndex, string direction, int steps)
        {
            if (direction == "left")
            {
                steps *= -1;
            }

            return actualIndex + steps;
        }

        private static void Move(int actualIndex, int newIndex, int steps)
        {
            if (newIndex > field.Length - 1)
            {
                return;
            }

            if (field[newIndex] == true)
            {
                Move(actualIndex, newIndex + steps, steps);
                return;
            }

            field[newIndex] = true;
        }

        private static void FillTheFieldWithBugs(int[] indexesWithBugs)
        {
            for (int i = 0; i < indexesWithBugs.Length; i++)
            {
                int index = indexesWithBugs[i];

                if (index < 1 || index > field.Length - 1)
                {
                    continue;
                }

                field[index] = true;
            }
        }
    }
}
