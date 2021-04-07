using System;

namespace SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            int smallest = GetSmallest(n1, n2, n3);
            Console.WriteLine(smallest);
        }

        private static int GetSmallest(int n1, int n2, int n3)
        {
            return Math.Min(Math.Min(n1, n2), n3);
        }
    }
}
