using System;

namespace _09.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double volume = width * length * height;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Done")
            {
                int countOfBoxes = int.Parse(input);
                volume -= (countOfBoxes * 1.0);
                if (volume < 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(volume)} Cubic meters more.");
                    return;
                }
            }
            Console.WriteLine($"{volume} Cubic meters left.");
        }
    }
}
