using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int taskToKill = int.Parse(Console.ReadLine());
            string result = SearchTask(tasks, threads, taskToKill);
            Console.WriteLine($"{result}{Environment.NewLine}{string.Join(' ', threads)}");
        }

        private static string SearchTask(Stack<int> tasks, Queue<int> threads, int taskToKill)
        {
            while (tasks.Count != 0 && threads.Count != 0)
            {
                int threadValue = threads.Peek();
                int taskValue = tasks.Peek();

                if (taskValue == taskToKill)
                {
                    return $"Thread with value {threadValue} killed task {taskValue}";
                }

                if (threadValue >= taskValue)
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            throw new Exception();
        }
    }
}
