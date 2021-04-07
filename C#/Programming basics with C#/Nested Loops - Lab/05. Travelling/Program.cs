using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string destination = input;
                double cost = double.Parse(Console.ReadLine());
                double money = 0;

                while (money < cost)
                {
                    money += double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {destination}!");
            }
       }
    }
}
