using System;
using System.Linq;

namespace _1.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            int countOfLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonus = double.MinValue;
            int studentAttendance = -1;

            for (int i = 0; i < countOfStudents; i++)
            {
                int currentAttendance = int.Parse(Console.ReadLine());
                double totalBonus = currentAttendance * 1.0 / (1.0 * countOfLectures) * (5.0 + additionalBonus);

                if (maxBonus < totalBonus)
                {
                    maxBonus = totalBonus;
                    studentAttendance = currentAttendance;
                }
            }

            string output = OutputResult(maxBonus, studentAttendance);
            Console.WriteLine(output);
        }

        private static string OutputResult(double maxBonus, int attendance)
        {
            return $"Max Bonus: {Math.Ceiling(maxBonus)}.{Environment.NewLine}The student has attended {attendance} lectures.";
        }
    }
}
