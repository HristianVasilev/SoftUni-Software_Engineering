using System;
using System.Collections.Generic;
using System.Text;

namespace _05.DateModifier
{
    class DateModifier
    {
        public static int DayDifference(string firstDate, string secondDate)
        {
            DateTime dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);

            int difference = Math.Abs((int)(dateTwo - dateOne).TotalDays);
            return difference;
        }
    }
}
