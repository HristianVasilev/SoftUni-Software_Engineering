using System;

namespace _05.DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int dateDifference = DateModifier.DayDifference(firstDate, secondDate);
            Console.WriteLine(dateDifference);
        }
    }
}
