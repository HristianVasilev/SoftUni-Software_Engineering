using System;
using System.Collections.Generic;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> print = words => Console.WriteLine(string.Join(Environment.NewLine, words));

            print(strings);
        }
    }
}
