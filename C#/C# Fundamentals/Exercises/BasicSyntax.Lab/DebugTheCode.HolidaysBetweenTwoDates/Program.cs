using System;
using System.Globalization;

namespace DebugTheCode.HolidaysBetweenTwoDates
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startDate = DateTime
                .ParseExact(Console.ReadLine(), new string[] { "d.m.yyyy", "d.mm.yyyy", "dd.m.yyyy", "dd.mm.yyyy" }, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime
                .ParseExact(Console.ReadLine(), new string[] { "d.m.yyyy", "d.mm.yyyy", "dd.m.yyyy", "dd.mm.yyyy" }, CultureInfo.InvariantCulture);

            Console.WriteLine(startDate.ToString());

            var totalDays = (startDate - endDate);
            ;

        }
    }
}
