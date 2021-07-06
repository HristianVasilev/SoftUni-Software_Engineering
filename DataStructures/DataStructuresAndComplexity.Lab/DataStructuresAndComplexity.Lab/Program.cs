using System;

namespace DataStructuresAndComplexity.Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        long GetOperationsCount(int n)
        {
            long counter = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    counter++;
            return counter;
        }

    }
}
