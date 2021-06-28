using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            int[][] powerOfWarriors = new int[waves][];

            Queue<int> platesOfDefence = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> warriorOrcs = null;

            for (int i = 1; i <= waves; i++)
            {
                warriorOrcs = new Stack<int>(Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));

                if (i % 3 == 0)
                {
                    platesOfDefence.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (platesOfDefence.Count != 0 && warriorOrcs.Count != 0)
                {
                    int warrior = warriorOrcs.Peek();
                    int plate = platesOfDefence.Peek();

                    if (warrior > plate)
                    {
                        platesOfDefence.Dequeue();
                        warriorOrcs.Push(warriorOrcs.Pop() - plate);

                        if (warriorOrcs.Peek() <= 0)
                        {
                            warriorOrcs.Pop();
                        }
                    }
                    else if (warrior < plate)
                    {
                        warriorOrcs.Pop();
                        platesOfDefence = DecreasePlate(platesOfDefence, warrior);
                    }
                    else
                    {
                        warriorOrcs.Pop();
                        platesOfDefence.Dequeue();
                    }
                }

                if (platesOfDefence.Count == 0)
                {
                    break;
                }
            }

            string result = GetResult(platesOfDefence, warriorOrcs);
            Console.WriteLine(result);
        }

        private static string GetResult(Queue<int> platesOfDefence, Stack<int> warriorOrcs)
        {
            StringBuilder sb = new StringBuilder();

            string defenceInfo;

            if (platesOfDefence.Count == 0)
            {
                defenceInfo = "The orcs successfully destroyed the Gondor's defense.";
            }
            else
            {
                defenceInfo = "The people successfully repulsed the orc's attack.";
            }

            sb.AppendLine(defenceInfo);

            if (warriorOrcs.Count > 0)
            {
                sb.AppendLine($"Orcs left: {string.Join(", ", warriorOrcs)}");
            }

            if (platesOfDefence.Count > 0)
            {
                sb.AppendLine($"Plates left: {string.Join(", ", platesOfDefence)}");
            }

            return sb.ToString().TrimEnd();
        }

        private static Queue<int> DecreasePlate(Queue<int> platesOfDefence, int warrior)
        {
            List<int> collection = platesOfDefence.ToList();
            collection[0] -= warrior;

            return new Queue<int>(collection);
        }
    }
}
