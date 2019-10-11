using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.HtmlBuilders.CalendarBuilder
{
    public class CalendarGrid : List<CalendarCell>
    {
        public CalendarGrid(List<DateTime> calendarDays)
        {
            var column = 1;
            var row = 4;
            for (var i = 0; i < calendarDays.Count; i++, column++)
            {
                var calendarDay = calendarDays[i];
                this.Add(new CalendarCell
                {
                    CalendarDay = calendarDay,
                    Column = column,
                    Row = row
                });

                if (column == 7)
                {
                    column = 0;
                    row += 5;
                }
            }
        }

        public CalendarCell this[DateTime calendarDay] => this.SingleOrDefault(c => c.CalendarDay == calendarDay);
    }
}