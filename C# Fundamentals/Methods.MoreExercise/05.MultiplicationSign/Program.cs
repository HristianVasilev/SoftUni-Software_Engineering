using System;

namespace _05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            byte positive = 0;
            byte negative = 0;
            bool hasZero = false;

            for (byte i = 0; i < 3; i++)
            {
                int num = int.Parse(Console.ReadLine());
                int type = TypeOfNumber(num);
                if (type == 1)
                {
                    positive++;
                }
                else if (type == 0)
                {
                    hasZero = true;
                }
                else if (type == -1)
                {
                    negative++;
                }
            }         

            if (hasZero)
            {
                Console.WriteLine("zero");
            }
            else
            {
                if ((positive == 3 && negative ==0)|| (positive == 1 && negative == 2))
                {
                    Console.WriteLine("positive");
                }
                else if ((positive == 2 && negative == 1) || (positive == 0 && negative == 3))
                {
                    Console.WriteLine("negative");
                }
            }
        }
        static int TypeOfNumber(int number)
        {
            if (number > 0)
            {
                return 1;
            }
            else if (number == 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
