using System;
using System.Linq;

namespace _2.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagonCapacity = 4;

            int peopleWaiting = int.Parse(Console.ReadLine());

            int[] wagons = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            for (int i = 0; i < wagons.Length; i++)
            {
                while (wagons[i] < 4 && peopleWaiting > 0)
                {
                    wagons[i]++;
                    peopleWaiting--;
                }
            }

            if (peopleWaiting == 0 && wagons.Any(x => x != 4))
            {
                Console.WriteLine("The lift has empty spots!");
            }

            if (peopleWaiting != 0)
            {
                Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
            }

            Console.WriteLine(string.Join(' ',wagons));
        }
    }
}
