﻿using System;

namespace _05._Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 1; k <= l; k++)
                    {
                        for (int m = 1; m <= l; m++)
                        {
                            for (int o = 1; o <= n; o++)
                            {
                                if (o > i && o > j)
                                {
                                    Console.Write($"{i}{j}{Convert.ToChar(k + 96)}{Convert.ToChar(m + 96)}{o} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}