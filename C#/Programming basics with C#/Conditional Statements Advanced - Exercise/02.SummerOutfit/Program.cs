using System;

namespace _02.SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int temperature = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            string outfit = string.Empty;
            string shoes = string.Empty;

            if (time == "Morning")
            {
                if (temperature >= 10 && temperature <= 18)
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (temperature > 10 && temperature <= 24)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (temperature > 24)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
            }
            else if (time == "Afternoon")
            {
                if (temperature >= 10 && temperature <= 18)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (temperature > 10 && temperature <= 24)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (temperature > 24)
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
            }
            else if (time == "Evening")
            {
                outfit = "Shirt";
                shoes = "Moccasins";
            }

            Console.WriteLine($"It's {temperature} degrees, get your {outfit} and {shoes}.");
        }
    }
}
