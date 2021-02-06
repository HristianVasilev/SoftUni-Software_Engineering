using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalMoney = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "NoMoreMoney")
            {
                double money = double.Parse(command);
                if (money < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {money:f2}");
                totalMoney += money;
            }

            Console.WriteLine($"Total: {totalMoney:f2}");
        }
    }
}
