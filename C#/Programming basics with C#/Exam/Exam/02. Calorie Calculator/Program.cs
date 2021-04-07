using System;

namespace _02._Calorie_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string sex = Console.ReadLine();
            double weight = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            int age = int.Parse(Console.ReadLine());
            string activity = Console.ReadLine();

            double BNM = 0.0;

            if (sex == "m")
            {
                BNM = 66 + 13.7 * weight + 5 * height * 100 - 6.8 * age;
            }
            else if (sex == "f")
            {
                BNM = 655 + 9.6 * weight + 1.8 * height * 100 - 4.7 * age;
            }

            switch (activity)
            {
                case "sedentary":
                    BNM *= 1.2;
                    break;
                case "lightly active":
                    BNM *= 1.375;
                    break;
                case "moderately active":
                    BNM *= 1.55;
                    break;
                case "very active":
                    BNM *= 1.725;
                    break;
            }

            Console.WriteLine($"To maintain your current weight you will need {Math.Round(Math.Ceiling(BNM), 0)} calories per day.");
        }
    }
}
