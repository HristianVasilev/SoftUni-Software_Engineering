using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance= int.Parse(Console.ReadLine());
            byte exhaustionFactor = byte.Parse(Console.ReadLine());
            int N = pokePower;
            int M = distance;

            byte target = 0;
            while (N >= M)
            {
                N -= M;
                target++;
                if (N == 0.5*pokePower && exhaustionFactor > 0)
                {
                    N /= exhaustionFactor;
                    continue;
                }
            }
            Console.WriteLine(N);
            Console.WriteLine(target);
        }
    }
}
