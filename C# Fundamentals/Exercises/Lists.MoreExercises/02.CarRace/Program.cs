using System;
using System.Linq;

namespace _02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] road = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] leftCar = road.Take(road.Length / 2).ToArray();
            int[] rightCar = road.Reverse().Take(road.Length / 2).ToArray();

            double leftCarTime = CalculateTIme(leftCar);
            double rightCarTime = CalculateTIme(rightCar);

            string winner = GetWinner(leftCarTime, rightCarTime);
            Console.WriteLine(winner);
        }

        private static string GetWinner(double leftCarTime, double rightCarTime)
        {
            double totalTime;
            string winner;

            if (leftCarTime < rightCarTime)
            {
                totalTime = leftCarTime;
                winner = "left";
            }
            else if (leftCarTime == rightCarTime)
            {
                totalTime = leftCarTime;
                winner = "left/right";
            }
            else
            {
                totalTime = rightCarTime;
                winner = "right";
            }

            return $"The winner is {winner} with total time: {totalTime:f1}";
        }

        private static double CalculateTIme(int[] road)
        {
            double time = 0;

            for (int i = 0; i < road.Length; i++)
            {
                if (road[i] == 0)
                {
                    time *= 0.8;
                    continue;
                }

                time += road[i];
            }

            return time;
        }
    }
}
