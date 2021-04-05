using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime AddWorkDays(this DateTime date, int workingDays)
        {
            int direction = workingDays < 0 ? -1 : 1;
            DateTime newDate = date;
            while (workingDays != 0)
            {
                newDate = newDate.AddDays(direction);
                if (newDate.DayOfWeek != DayOfWeek.Saturday && newDate.DayOfWeek != DayOfWeek.Sunday && !newDate.IsHoliday())
                    workingDays -= direction;
            }
            return newDate;
        }

        public static bool IsHoliday(this DateTime date)
        {
            return false;
        }
    }
}
