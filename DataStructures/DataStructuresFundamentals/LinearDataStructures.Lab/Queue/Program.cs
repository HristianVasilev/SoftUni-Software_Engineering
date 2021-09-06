using System;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);

            Console.WriteLine($"Queue count is: {queue.Count}");
            Console.WriteLine($"Queue peek: {queue.Peek()}");
            //Console.WriteLine($"Queue dequeue is: {queue.Dequeue()}");
            //Console.WriteLine($"Queue dequeue is: {queue.Dequeue()}");
            //Console.WriteLine($"Queue dequeue is: {queue.Dequeue()}");
            //Console.WriteLine($"Queue dequeue is: {queue.Dequeue()}");
            //Console.WriteLine($"Queue dequeue is: {queue.Dequeue()}");
        }
    }
}
