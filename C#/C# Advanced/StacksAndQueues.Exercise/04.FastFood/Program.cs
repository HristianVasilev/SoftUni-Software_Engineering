using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            Queue<int> orders = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int biggestOrder = orders.Max();
            Console.WriteLine(biggestOrder);

            string output = ServiceOrders(foodQuantity, ref orders);
            Console.WriteLine(output);
        }

        private static string ServiceOrders(int foodQuantity, ref Queue<int> orders)
        {
            while (orders.Count > 0)
            {
                int currentOrder = orders.Peek();

                if (foodQuantity - currentOrder >= 0)
                {
                    foodQuantity -= currentOrder;
                    orders.Dequeue();
                }
                else
                {
                    return $"Orders left: {string.Join(" ", orders)}";
                }
            }

            return "Orders complete";
        }
    }
}
