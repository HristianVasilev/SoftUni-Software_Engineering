using System;
using System.Linq;

namespace _2.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            string rndString = Console.ReadLine();

            var filtered = rndString.Where(c => c > first && c < second).ToArray();

            int sum = filtered.Sum(c => c);
            Console.WriteLine(sum);
        }
    }
}
