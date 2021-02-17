using System;
using System.Linq;

namespace _05.FundamentalsMidExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            int countOfLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            int[] students = new int[countOfStudents];
            int[] attendances = new int[countOfStudents];

            for (int i = 0; i < countOfStudents; i++)
            {
                int attendance = int.Parse(Console.ReadLine());

                int totalBonus = (int)Math.Round(attendance / (1.0 * countOfLectures) * (5 + additionalBonus));

                students[i] = totalBonus;
                attendances[i] = attendance;
            }

            double maxBonus = students.Max();
            int indexOfMaxBonus = FindIndex(maxBonus, students);

            int studentAttendance = attendances[indexOfMaxBonus];

            string output = OutputResult(maxBonus, studentAttendance);
            Console.WriteLine(output);
        }

        private static string OutputResult(double maxBonus, int attendance)
        {
            return $"Max Bonus: {maxBonus}.{Environment.NewLine}The student has attended {attendance} lectures.";
        }

        private static int FindIndex(double maxBonus, int[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] == maxBonus)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
