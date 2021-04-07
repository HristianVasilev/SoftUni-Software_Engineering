using System;
using System.Globalization;
using System.Linq;

namespace ArraysDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5] { 1, 3, 2, 5, 7 };

            Console.WriteLine(string.Join("-", numbers));

        }
    }
}

