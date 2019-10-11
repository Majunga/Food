using System;

namespace Common.HtmlBuilders.CalendarBuilder
{
    public class CalendarCell
    {
        public DateTime CalendarDay { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }

        public CellRows CellRows { get; set; } = new CellRows();
    }
}