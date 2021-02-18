using System;
using System.Linq;

namespace _3.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            double averageNum = arr.Average();
            var collection = arr.Where(x => x > averageNum).OrderByDescending(x => x).Take(5).ToArray();

            if (collection.Length == 0)
            {
                Console.WriteLine("No");
                Environment.Exit(0);
            }

            Console.WriteLine(string.Join(' ',collection));
        }
    }
}
