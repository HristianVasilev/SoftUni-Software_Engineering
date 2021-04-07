using System;

namespace _06._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int stories = int.Parse(Console.ReadLine());
            int countOfRooms = int.Parse(Console.ReadLine());

            for (int floor = stories; floor > 0; floor--)
            {
                string output = string.Empty;

                for (int apartment = 0; apartment < countOfRooms; apartment++)
                {
                    if (floor == stories)
                    {
                        output += $"L{floor}{apartment} ";
                        continue;
                    }

                    if (floor % 2 == 0)
                    {
                        output += $"O{floor}{apartment} ";
                    }
                    else if (floor % 2 != 0)
                    {
                        output += $"A{floor}{apartment} ";
                    }
                }
                Console.WriteLine(output);
            }
        }
    }
}
