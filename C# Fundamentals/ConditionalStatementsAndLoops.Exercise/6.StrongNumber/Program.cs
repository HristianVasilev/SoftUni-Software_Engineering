using System;

namespace _6.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sumOfFactSym = 0;
            int number = int.Parse(input);

            for (int i = 0; i < input.Length; i++)
            {
                string sym = Convert.ToString(input[i]);
                int num = int.Parse(sym);
                int fact = 1;

                for (int j = 1; j <= num; j++)
                {
                    fact *= j;
                }
                sumOfFactSym += fact;
            }
            if (sumOfFactSym == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
