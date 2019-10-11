using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Calendar
    {
        private readonly DateTime _firstDayOfTheMonth;

        public Calendar(int year, int month)
        {
            _firstDayOfTheMonth = new DateTime(year, month, 1);
        }

        public DateTime GetFirstDayOfCalendar()
        {
            if (_firstDayOfTheMonth.DayOfWeek == DayOfWeek.Monday)
            {
                return _firstDayOfTheMonth;
            }

            var current = _firstDayOfTheMonth;
            while (current.DayOfWeek != DayOfWeek.Monday)
            {
                current = current.AddDays(-1);
            }

            return current;
        }

        public List<DateTime> GetCalendarDays()
        {
            var days = new List<DateTime>();
            var firstCalendarDay = GetFirstDayOfCalendar();
            
            for (int i = 0; i < 42; i++)
            {
                var dayToAdd = new DateTime(firstCalendarDay.Year, firstCalendarDay.Month, firstCalendarDay.Day).AddDays(i);
                days.Add(dayToAdd);
            }

            return days;
        }
    }
}
