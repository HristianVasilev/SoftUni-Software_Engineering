using System;
using System.Collections.Generic;

namespace _08._Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double grades = 0;


            for (int i = 1; i <= 12; i++)
            {
                double current = double.Parse(Console.ReadLine());
                grades += current;

                if (current < 4)
                {
                    Console.WriteLine($"{name} has been excluded at {i} grade");
                    return;
                }
            }
            double average = grades / 12;
            Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
        }
    }
}
