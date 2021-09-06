using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Collections.Generic.ICollection<int> numbers = new int[] { 10, 20, 30 };

            Stack<int> stack = new Stack<int>(numbers);

            var stackCloned = stack.Clone();

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(string.Join(", ",stack.ToArray()));


            //Console.WriteLine($"Stack valid contains: {stack.Contains(10)}");
            //Console.WriteLine($"Stack valid contains: {stack.Contains(20)}");
            //Console.WriteLine($"Stack valid contains: {stack.Contains(30)}");

            //Console.WriteLine($"Stack invalid contains: {stack.Contains(300)}");
            //;

            //Console.WriteLine($"Stack count: {stack.Count}");
            //Console.WriteLine($"Stack's top element: {stack.Peek()}");

            //while (stack.Count != 0)
            //{
            //   Console.WriteLine(stack.Pop());
            //   Console.WriteLine($"stack count: {stack.Count}");
            //}
        }
    }
}
