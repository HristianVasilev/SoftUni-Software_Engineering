using System;
using System.Linq;
using System.Text;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lowerBoundary = range[0];
            int upperBoundary = range[1];

            string type = Console.ReadLine();

            Predicate<int> predicate;

            switch (type)
            {
                case "odd":
                    predicate = x => x % 2 != 0;
                    break;
                case "even":
                    predicate = x => x % 2 == 0;
                    break;

                default:
                    throw new InvalidOperationException();
            }

            StringBuilder sb = new StringBuilder();

            for (int i = lowerBoundary; i <= upperBoundary; i++)
            {
                if (predicate(i))
                {
                    sb.Append($"{i} ");
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
