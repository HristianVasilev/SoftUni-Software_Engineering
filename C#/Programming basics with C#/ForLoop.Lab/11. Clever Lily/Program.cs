using System;

namespace _11._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            byte age = byte.Parse(Console.ReadLine());
            double priceForWasher = double.Parse(Console.ReadLine());
            double priceForToys = double.Parse(Console.ReadLine());

            byte toys = 0;
            double money = 0;
            double currentMoney = 0;

            for (byte i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    currentMoney += 10;
                    money += (currentMoney - 1);
                }
                else
                {
                    toys++;
                }
            }

            money += (priceForToys * toys);

            if (priceForWasher <= money)
            {
                Console.WriteLine($"Yes! {Math.Abs(priceForWasher - money):f2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(priceForWasher - money):f2}");
            }





        }
    }
}
