using System;

namespace _1.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int four = int.Parse(Console.ReadLine());

            int result = (first + second) / third * four;
            Console.WriteLine(result);
        }    
    }
}
