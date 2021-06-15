using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printFilteredNames = array => 
            {
                foreach (var name in names)
                {
                    if (name.Length <= n)
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            printFilteredNames(names);
        }
    }
}
