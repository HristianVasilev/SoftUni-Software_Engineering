using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double requiredMoney = double.Parse(Console.ReadLine());
            double existentMoney = double.Parse(Console.ReadLine());
            int counterDays = 0;
            int daysSpend = 0;

            while (requiredMoney > existentMoney)
            {
                string command = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                counterDays++;
                switch (command)
                {
                    case "spend":

                        if (existentMoney >= money)
                        {
                            existentMoney -= money;
                        }
                        else
                        {
                            existentMoney = 0;
                        }
                        daysSpend++;

                        break;
                    case "save":

                        existentMoney += money;
                        daysSpend = 0;

                        break;
                }
                if (daysSpend >= 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(counterDays);
                    return;
                }
            }
            Console.WriteLine($"You saved the money for {counterDays} days.");
        }
    }
}
