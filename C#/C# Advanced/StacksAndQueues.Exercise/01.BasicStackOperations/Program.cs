using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arguments = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int toPush = arguments[0];
            int toPop = arguments[1];
            int toLook = arguments[2];

            Stack<int> stack = new Stack<int>();

            PushStack(toPush, ref stack);
            PopStack(toPop, ref stack);
            bool contains = LookupStack(toLook, ref stack);

            string output = GetOutput(stack, contains);
            Console.WriteLine(output);
        }

        private static string GetOutput(Stack<int> stack, bool contains)
        {
            if (contains)
            {
                return "true";
            }
            else if (!contains && stack.Count > 0)
            {
                return $"{stack.Min()}";
            }
            else
            {
                return $"{0}";
            }
        }

        private static bool LookupStack(int toLook, ref Stack<int> stack)
        {
            if (stack.Contains(toLook))
            {
                return true;
            }

            return false;
        }

        private static void PopStack(int toPop, ref Stack<int> stack)
        {
            for (int i = 0; i < toPop; i++)
            {
                stack.Pop();
            }
        }

        private static void PushStack(int toPush, ref Stack<int> stack)
        {
            int[] integers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < toPush; i++)
            {
                stack.Push(integers[i]);
            }
        }
    }
}
