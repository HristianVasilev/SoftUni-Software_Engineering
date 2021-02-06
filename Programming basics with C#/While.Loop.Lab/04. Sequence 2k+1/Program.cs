using System;

namespace _04._Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int current = 0;

            while (current < n)
            {
                current = current* 2 + 1;
                if (current <= n)
                {
                    Console.WriteLine(current);
                }
            }
        }
    }
}
