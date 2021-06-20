using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string fullName = $"{firstTokens[0]} {firstTokens[1]}";
            string address = firstTokens[2];

            Tuple<string, string> personInfo = new Tuple<string, string>(fullName, address);


            string[] secondTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string beer = secondTokens[0];
            int litersOfBeer = int.Parse(secondTokens[1]);

            Tuple<string, int> amountOfBeer = new Tuple<string, int>(beer, litersOfBeer);


            string[] thirdTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int integerType = int.Parse(thirdTokens[0]);
            double doubleType = double.Parse(thirdTokens[1]);

            Tuple<int, double> numbers = new Tuple<int, double>(integerType, doubleType);

            Console.WriteLine(personInfo);
            Console.WriteLine(amountOfBeer);
            Console.WriteLine(numbers);
        }
    }
}
