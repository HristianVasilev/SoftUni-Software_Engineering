using System;

namespace _05._Christmas_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            int toyPrice = 5;
            int clothPrice = 15;

            byte kids = 0;
            byte adults = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Christmas")
            {
                int age = int.Parse(input);

                if (age <= 16)
                {
                    kids++;
                }
                else
                {
                    adults++;
                }
            }

            Console.WriteLine($"Number of adults: {adults}");
            Console.WriteLine($"Number of kids: {kids}");
            Console.WriteLine($"Money for toys: {kids * toyPrice}");
            Console.WriteLine($"Money for sweaters: {adults * clothPrice}");
        }
    }
}
