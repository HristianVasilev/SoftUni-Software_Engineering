using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine()), val = 1;
 

            for (int i = 0; i < rows; i++)
            {             
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || i == 0)
                    {
                        val = 1;
                    }
                    else
                    {
                        val = val * (i - j + 1) / j;
                    }
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
