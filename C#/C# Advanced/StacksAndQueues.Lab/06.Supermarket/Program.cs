using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, queue));
                    queue.Clear();
                    continue;
                }

                queue.Enqueue(input);
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
