using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var prices = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(double.Parse)
                 .Select(x => (x *= 1.2).ToString("F2"));               

            Console.WriteLine(string.Join(Environment.NewLine, prices));
        }
    }
}
