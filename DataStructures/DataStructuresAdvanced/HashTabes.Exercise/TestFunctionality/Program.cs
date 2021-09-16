namespace TestFunctionality
{
    using _01.RoyaleArena;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            ICollection<int> slots = new List<int>();
            int capacity = 8;
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
              //  int id = random.Next(10, 999);
                slots.Add(i / capacity);
            }

            List<int> described = new List<int>();
            foreach (var num in slots)
            {
                if (described.Contains(num)) continue;
                described.Add(num);
                Console.WriteLine($"Number: {num} - count: {slots.Count(x => x == num)}");
            }
            ;

            RoyaleArena arena = new RoyaleArena();

            BattleCard battleCard =
                new BattleCard(12, CardType.BUILDING, "Doesn't matter", 90, 43);

            arena.Add(battleCard);

            Console.WriteLine(battleCard.GetHashCode());
        }
    }
}
