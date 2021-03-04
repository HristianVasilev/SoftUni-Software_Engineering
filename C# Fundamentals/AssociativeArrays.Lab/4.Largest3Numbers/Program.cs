using System;
using System.Linq;

namespace _4.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var collection = numbers.OrderByDescending(n => n).Take(3);

            Console.WriteLine(string.Join(' ',collection));
        }
    }
}
