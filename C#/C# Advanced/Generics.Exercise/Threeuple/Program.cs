using System;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string fullName = $"{firstTokens[0]} {firstTokens[1]}";
            string address = firstTokens[2];
            string town = firstTokens[3];

            Tuple<string, string, string> personInfo = new Tuple<string, string, string>(fullName, address, town);
            Console.WriteLine(personInfo);       

            string[] secondTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string beer = secondTokens[0];
            int litersOfBeer = int.Parse(secondTokens[1]);
            string drunkOrNot = secondTokens[2];

            bool isDrunk = CheckIfDrunk(drunkOrNot);

            Tuple<string, int, bool> amountOfBeer = new Tuple<string, int, bool>(beer, litersOfBeer, isDrunk);
            Console.WriteLine(amountOfBeer);

            string[] thirdTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = thirdTokens[0];
            double accountBalance = double.Parse(thirdTokens[1]);
            string bankName = thirdTokens[2];

            Tuple<string, double, string> bankBalance = new Tuple<string, double, string>(name, accountBalance, bankName);
            Console.WriteLine(bankBalance);
        }

        private static bool CheckIfDrunk(string drunkOrNot)
        {
            bool isDrunk;
            if (drunkOrNot == "drunk")
            {
                isDrunk = true;
            }
            else if (drunkOrNot == "not")
            {
                isDrunk = false;
            }
            else
            {
                throw new ArgumentException("Invalid type of boolean!");
            }

            return isDrunk;
        }
    }
}
