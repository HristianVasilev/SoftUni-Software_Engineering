using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Push":
                        int[] integers = tokens
                            .Skip(1)
                            .Select(x => x.Trim(','))
                            .Select(int.Parse)
                            .ToArray();

                        foreach (var i in integers)
                        {
                            stack.Push(i);
                        }

                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    default:
                        throw new InvalidOperationException("Invalid command!");
                }
            }

            Foreach(stack);
            Foreach(stack);

        }

        private static void Foreach(Stack<int> stack)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
