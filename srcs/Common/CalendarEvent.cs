using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Common
{
    public class CalendarEvent
    {
        public CalendarEvent()
        {

        }

        public CalendarEvent(int id)
        {
            this.Id = id;
        }

        public int Id { get; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool CollidesWith(CalendarEvent calendarEvent)
        {
            return this.DateTimeFrom < calendarEvent.DateTimeTo && calendarEvent.DateTimeFrom < this.DateTimeTo;
        }
    }
}
