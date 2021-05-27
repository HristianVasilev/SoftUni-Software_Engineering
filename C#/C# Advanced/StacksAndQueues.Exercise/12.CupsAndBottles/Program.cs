using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentCup = cups.Peek();
                int currentBottle = bottles.Pop();

                FillCups(currentCup, currentBottle, ref cups, ref bottles, ref wastedWater);
            }

            string output = GetOutput(cups, bottles, wastedWater);
            Console.WriteLine(output);
        }

        private static string GetOutput(Queue<int> cups, Stack<int> bottles, int wastedWater)
        {
            StringBuilder sb = new StringBuilder();

            if (bottles.Count > 0)
            {
                sb.AppendLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                sb.AppendLine($"Cups: {string.Join(" ", cups)}");
            }

            sb.AppendLine($"Wasted litters of water: {wastedWater}");
            return sb.ToString().TrimEnd();
        }

        private static void FillCups(int currentCup, int currentBottle, ref Queue<int> cups, ref Stack<int> bottles, ref int wastedWater)
        {
            int difference = currentBottle - currentCup;

            if (difference < 0)
            {
                currentCup -= currentBottle;
                currentBottle = bottles.Pop();
                FillCups(currentCup, currentBottle, ref cups, ref bottles, ref wastedWater);
                return;
            }

            wastedWater += difference;
            cups.Dequeue();
        }
    }
}
