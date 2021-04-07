using System;

namespace _06._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int specialNumber = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                string num = i.ToString();
                bool special = true;
                for (int j = 0; j < num.Length; j++)
                {
                    if (int.Parse(num[j].ToString()) == 0)
                    {
                        special = false;
                        break;
                    }
                    if (!(specialNumber % int.Parse(num[j].ToString()) == 0))
                    {
                        special = false;
                        break;
                    }
                }
                if (special)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
