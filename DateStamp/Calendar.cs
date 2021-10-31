using System;
using System.Collections.Generic;

namespace DateStamp
{
    public class Calendar
    {

        private static readonly List<DateTime> Holidays = new List<DateTime>();
 
        static Calendar()
        {
            for (int i = 1; i < 9; i++)
            {
                Holidays.Add(new DateTime(DateTime.Now.Year, i, 1));
            }
            Holidays.Add(new DateTime(DateTime.Now.Year, 2, 23));
            Holidays.Add(new DateTime(DateTime.Now.Year, 3, 8));
            Holidays.Add(new DateTime(DateTime.Now.Year, 5, 1));
            Holidays.Add(new DateTime(DateTime.Now.Year, 5, 9));
            Holidays.Add(new DateTime(DateTime.Now.Year, 6, 12));
            Holidays.Add(new DateTime(DateTime.Now.Year, 11, 4));
        }

        private static bool IsHoliday(DateTime date)
        {
            return Holidays.Contains(date);
        }

        private static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime GetNextWorkingDay(DateTime date)
        {
            do
            {
                date = date.AddDays(1);
            } while (IsHoliday(date) || IsWeekend(date));
            return date;
        }
    }
}
