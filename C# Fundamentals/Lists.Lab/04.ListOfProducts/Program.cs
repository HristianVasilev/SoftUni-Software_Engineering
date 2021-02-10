using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                products.Add(Console.ReadLine());
            }

            int counter = 1;
            products.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine($"{counter++}.{x}"));
        }
    }
}
