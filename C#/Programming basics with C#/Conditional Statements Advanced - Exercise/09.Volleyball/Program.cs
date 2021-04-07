using System;

namespace _09.Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string leapOrNoemal = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            int weekends = 48;

            double games = weekends - h;
            games *= (3.0 / 4.0);
            games += h;
            games += (p * 2.0 / 3.0);

            if (leapOrNoemal == "leap")
            {
                games *= 1.15;
            }
            Console.WriteLine(Math.Floor(games));
        }
    }
}
