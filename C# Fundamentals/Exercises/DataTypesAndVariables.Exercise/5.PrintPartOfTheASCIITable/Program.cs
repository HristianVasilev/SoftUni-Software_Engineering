using System;

namespace _5.PrintPartOfTheASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {       
            int startSymbol = int.Parse(Console.ReadLine());
            int lastSymbol = int.Parse(Console.ReadLine());

            for (int i = startSymbol; i <= lastSymbol; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
