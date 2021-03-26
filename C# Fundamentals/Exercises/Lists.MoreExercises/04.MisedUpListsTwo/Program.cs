using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MisedUpListsTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstList = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> secondList = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            List<int> result = new List<int>();

            while (secondList.Count > 0)
            {
                result.Add(firstList.Dequeue());
                result.Add(secondList.Pop());
            }

            int lowerLimit = firstList.Min();
            int higherLimit = firstList.Max();


            Console.WriteLine(string.Join(' ',result.Where(x => x > lowerLimit && x < higherLimit).OrderBy(n => n)));
        }
    }
}
