using System;

namespace _08.OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            byte hourExam = byte.Parse(Console.ReadLine());
            byte minuteExam = byte.Parse(Console.ReadLine());

            byte hourArrive = byte.Parse(Console.ReadLine());
            byte minuteArrive = byte.Parse(Console.ReadLine());

            TimeSpan timeExam = new TimeSpan(hourExam, minuteExam, 0);
            TimeSpan timeArrive = new TimeSpan(hourArrive, minuteArrive, 0);

            TimeSpan diff = (timeExam - timeArrive);

            if (timeExam >= timeArrive)
            {
                if (diff.TotalMinutes <= 30)
                {
                    Console.WriteLine("On time");
                }
                else
                {
                    Console.WriteLine("Early");
                }

                if (diff.TotalMinutes > 0 && diff.TotalMinutes < 60)
                {
                    Console.WriteLine($"{diff.Minutes} minutes before the start");
                }
                else
                {
                    Console.WriteLine($"{diff.Hours}:{(diff.Minutes):d2} hours before the start");
                }
            }
            else
            {
                Console.WriteLine("Late");
                if (Math.Abs(diff.TotalMinutes) < 60)
                {
                    Console.WriteLine($"{Math.Abs(diff.TotalMinutes)} minutes after the start");
                }
                else
                {
                    Console.WriteLine($"{Math.Abs(diff.Hours)}:{Math.Abs(diff.Minutes):d2} hours after the start");
                }
            }
        }
    }
}
