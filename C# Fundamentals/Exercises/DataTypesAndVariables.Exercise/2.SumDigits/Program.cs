using System;

namespace _2.SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < num.Length; i++)
            {
                sum += int.Parse(num[i].ToString());
            }
            Console.WriteLine(sum);
        }
    }
}
