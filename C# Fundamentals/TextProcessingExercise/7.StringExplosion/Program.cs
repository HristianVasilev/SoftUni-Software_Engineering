﻿using System;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            int power = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                if (current == '>')
                {
                    sb.Append(current);
                    power += int.Parse(input[i + 1].ToString());
                }
                else if (power != 0)
                {
                    power--;
                }
                else
                {
                    sb.Append(current);
                }
            }
            Console.WriteLine(sb);
        }
    }
}
