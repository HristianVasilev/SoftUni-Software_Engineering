using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> scarfs = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            List<int> sets = new List<int>();
            Operate(ref hats, ref scarfs, ref sets);

            int mostExpensiveSet = sets.Max();
            string allSets = string.Join(' ', sets);
            Console.WriteLine($"The most expensive set is: {mostExpensiveSet}");
            Console.WriteLine(allSets);
        }

        private static void Operate(ref Stack<int> hats, ref Queue<int> scarfs, ref List<int> sets)
        {
            while (hats.Count != 0 && scarfs.Count != 0)
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (hat > scarf)
                {
                    int setPrice = hats.Pop() + scarfs.Dequeue();

                    sets.Add(setPrice);
                }
                else if (scarf > hat)
                {
                    hats.Pop();
                }
                else if (hat == scarf)
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }
        }
    }
}
