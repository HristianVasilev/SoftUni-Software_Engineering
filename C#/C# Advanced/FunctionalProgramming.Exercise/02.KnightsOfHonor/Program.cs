using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> print = arr => 
            {
                arr = arr.Select(i => i = $"Sir {i}").ToArray();

                Console.WriteLine(string.Join(Environment.NewLine, arr));
            };

            print(names);
        }
    }
}
