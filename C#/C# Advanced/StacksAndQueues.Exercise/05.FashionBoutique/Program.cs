using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int capacity = int.Parse(Console.ReadLine());

            byte countOfRacks = GetCountOfRacks(clothes, capacity);
            Console.WriteLine(countOfRacks);
        }

        private static byte GetCountOfRacks(Stack<int> clothes, int capacity)
        {
            byte racks = 1;
            int currentRack = 0;

            while (clothes.Count > 0)
            {
                if (currentRack + clothes.Peek() <= capacity)
                {
                    currentRack += clothes.Pop();
                    continue;
                }

                racks++;
                currentRack = 0;
            }

            return racks;
        }
    }
}
