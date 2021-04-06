using System;

namespace _03.FundamentalsMidExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int count = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(command);

                if (energy - distance < 0)
                {
                    
                    Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {energy} energy");
                    Environment.Exit(0);
                }

                energy -= distance;
                count++;

                if (count % 3 == 0)
                {
                    energy += count;
                }
            }

            Console.WriteLine($"Won battles: {count}. Energy left: {energy}");
        }
    }
}
