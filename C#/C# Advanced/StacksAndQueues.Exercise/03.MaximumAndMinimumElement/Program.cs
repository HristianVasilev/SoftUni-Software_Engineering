using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfQueries = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < countOfQueries; i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int action = tokens[0];

                switch (action)
                {
                    case 1:
                        stack.Push(tokens[1]);
                        break;
                    case 2:
                        DeleteTopOfStack(ref stack);
                        break;
                    case 3:
                        MaxOfStack(ref stack);
                        break;
                    case 4:
                        MinOfStack(ref stack);
                        break;
                    default:
                        break;
                }
            }

            string outputStack = string.Join(", ", stack);
            Console.WriteLine(outputStack);
        }

        private static void MinOfStack(ref Stack<int> stack)
        {
            if (stack.Count == 0)
            {
                return;
            }

            Console.WriteLine(stack.Min());
        }

        private static void MaxOfStack(ref Stack<int> stack)
        {
            if (stack.Count == 0)
            {
                return;
            }

            Console.WriteLine(stack.Max());
        }

        private static void DeleteTopOfStack(ref Stack<int> stack)
        {
            if (stack.Count > 0)
            {
                stack.Pop();
            }
        }
    }
}
