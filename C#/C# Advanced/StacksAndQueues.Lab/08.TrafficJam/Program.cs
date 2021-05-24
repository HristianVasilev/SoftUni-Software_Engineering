using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();
            int passed = 0;

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    PassCars(n, ref queue, ref passed);
                    continue;
                }

                queue.Enqueue(command);
            }

            Console.WriteLine($"{passed} cars passed the crossroads.");
        }

        private static void PassCars(int n, ref Queue<string> queue, ref int passed)
        {
            for (int i = 0; i < n; i++)
            {
                if (queue.Count == 0)
                {
                    return;
                }

                string car = queue.Dequeue();
                Console.WriteLine($"{car} passed!");
                passed++;
            }
        }
    }
}
