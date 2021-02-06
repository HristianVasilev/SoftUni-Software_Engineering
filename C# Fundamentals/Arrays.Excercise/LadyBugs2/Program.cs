using System;
using System.IO;
using System.Linq;

namespace WhileCycles___Lab_and_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] field = new int[size];
            int[] ladyBudsIdexes = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

            for (int i = 0; i < ladyBudsIdexes.Length; i++)
            {
                int index = ladyBudsIdexes[i];
                if (index >= 0 && index < field.Length)
                {
                    field[index] = 1;
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int ladyBugIndex = int.Parse(tokens[0]);
                string sideToMove = tokens[1];
                int flyLength = int.Parse(tokens[2]);

                if (ladyBugIndex < 0 || ladyBugIndex >= field.Length)
                {
                    continue;
                }
                if (field[ladyBugIndex] == 0)
                {
                    continue;
                }
                field[ladyBugIndex] = 0;

                if (sideToMove == "right")
                {
                    MoveRight(field, ladyBugIndex, flyLength);
                }
                if (sideToMove == "left")
                {
                    MoveLeft(field, ladyBugIndex, flyLength);
                }
            }
            Console.WriteLine(string.Join(' ', field));
        }

        static void MoveLeft(int[] field, int laduBugIndex, int flyLength)
        {
            if (flyLength < 0)
            {
                MoveRight(field, laduBugIndex, Math.Abs(flyLength));
            }
            else
            {
                int index = laduBugIndex - flyLength;
                if (index >= 0)
                {
                    if (field[index] == 0)
                    {
                        field[index] = 1;
                    }
                    else
                    {
                        while (true)
                        {
                            index -= flyLength;
                            if (index < 0)
                            {
                                break;
                            }
                            if (field[index] == 0)
                            {
                                field[index] = 1;
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void MoveRight(int[] field, int ladyBugIndex, int flyLength)
        {
            if (flyLength < 0)
            {
                MoveLeft(field, ladyBugIndex, Math.Abs(flyLength));
            }
            else
            {
                int index = ladyBugIndex + flyLength;
                if (index < field.Length)
                {
                    if (field[index] == 0)
                    {
                        field[index] = 1;
                    }
                    else
                    {
                        while (true)
                        {
                            index += flyLength;
                            if (index >= field.Length)
                            {
                                break;
                            }
                            if (field[index] == 0)
                            {
                                field[index] = 1;
                                break;
                            }
                        }
                    }
                }
            }

        }
    }
}