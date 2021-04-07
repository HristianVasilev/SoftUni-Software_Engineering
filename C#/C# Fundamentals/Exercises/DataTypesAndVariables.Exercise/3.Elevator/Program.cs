using System;

namespace _3.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            byte p = byte.Parse(Console.ReadLine());
            int result = n / p;

            if (n % p != 0)
            {
                result += 1;
            }
           
            Console.WriteLine(result);
        }
    }
}
