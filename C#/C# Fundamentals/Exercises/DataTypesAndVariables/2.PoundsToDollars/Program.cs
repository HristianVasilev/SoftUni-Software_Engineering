using System;

namespace _2.PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal britishPounds = decimal.Parse(Console.ReadLine());
            decimal USdollars = britishPounds*(decimal)1.31;

            Console.WriteLine($"{USdollars:f3}");
        }
    }
}
