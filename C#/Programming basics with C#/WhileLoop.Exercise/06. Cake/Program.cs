using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int area = width * length;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "STOP")
            {
                int pieces = int.Parse(input);
                area -= pieces;
                if (area <= 0)
                {
                    break;
                }
            }

            if (area > 0)
            {
                Console.WriteLine($"{area} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(area)} pieces more.");
            }
        }
    }
}
