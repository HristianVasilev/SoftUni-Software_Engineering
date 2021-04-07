using System;
using System.Linq;

namespace _5.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var collection = words.Where(w => w.Length % 2 == 0);

            Console.WriteLine(string.Join(Environment.NewLine, collection));
        }
    }
}
