using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double resto = double.Parse(Console.ReadLine());
            int coins = 0;

            while (resto > 0)
            {
                if (resto >= 2)
                {
                    coins += ((int)resto / 2);
                    resto -= ((int)resto / 2) * 2;
                }
                else if (resto >= 1 && resto < 2)
                {
                    coins++;
                    resto -= 1;
                }
                else if (resto >= 0.5 && resto < 1)
                {
                    coins++;
                    resto -= 0.5;
                }
                else if (resto >= 0.2 && resto < 0.5)
                {
                    coins++;
                    resto -= 0.2;
                }
                else if (resto >= 0.1 && resto < 0.2)
                {
                    coins++;
                    resto -= 0.1;
                }
                else if (resto >= 0.05 && resto < 0.1)
                {
                    coins++;
                    resto -= 0.05;
                }
                else if (resto >= 0.02 && resto < 0.05)
                {
                    coins++;
                    resto -= 0.02;
                }
                else if (resto >= 0.01 && resto < 0.02)
                {
                    coins++;
                    resto -= 0.01;
                }
                resto = Math.Round(resto, 2);
            }
            Console.WriteLine(coins);
        }
    }
}
