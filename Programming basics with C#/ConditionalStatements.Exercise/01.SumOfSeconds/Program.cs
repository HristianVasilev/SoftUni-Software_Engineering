using System;

namespace _01.SumOfSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSeconds = 0;

            for (int i = 0; i < 3; i++)
            {
                int current = int.Parse(Console.ReadLine());
                totalSeconds += current;
            }

            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            Console.WriteLine($"{minutes}:{seconds:d2}");
        }
    }
}
