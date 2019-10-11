using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.HtmlBuilders.CalendarBuilder
{
    public class CalendarEvents
    {
        private readonly List<DateTime> _calendarDays;

        public CalendarEvents(List<DateTime> calendarDays)
        {
            _calendarDays = calendarDays;
        }

        public CalendarGrid AddEvents(List<CalendarEvent> calendarEvents)
        {
            var calendarGrid = new CalendarGrid(_calendarDays);

            if (calendarEvents == null || calendarEvents.Count == 0) return calendarGrid;


            var columns = new List<List<CalendarEvent>>();

            DateTime? lastEventEnding = null;
            foreach (var ev in calendarEvents.OrderBy(ev => ev.DateTimeFrom).ThenBy(ev => ev.DateTimeTo))
            {
                if (ev.DateTimeFrom > _calendarDays.Last()) return calendarGrid;
                if (ev.DateTimeTo < _calendarDays.First()) return calendarGrid;

                // Just add without worry
                if (!lastEventEnding.HasValue || ev.DateTimeFrom > lastEventEnding)
                {
                    CreateEvent(ev, calendarGrid);
                }
                else
                {
                    CreateOverlappingEvents(ev, calendarGrid);
                }

                if (lastEventEnding == null || ev.DateTimeTo > lastEventEnding.Value)
                {
                    lastEventEnding = ev.DateTimeTo;
                }
            }

            return calendarGrid;
        }

        private void CreateEvent(CalendarEvent ev, CalendarGrid calendarGrid)
        {
            var eventDateDifference = (int) (ev.DateTimeTo - ev.DateTimeFrom).TotalDays + 1;
            var eventTitle = ev.Title;
            var totalSpan = eventDateDifference;
            for (int i = 0; i < eventDateDifference; i++)
            {
                var currentDay = ev.DateTimeFrom.AddDays(i);

                var calendarCell = calendarGrid[currentDay];

                if (calendarCell == null)
                {
                    break;
                }

                var rowTitle = GetRowTitle(i, eventTitle, calendarCell);
                int span = 0;
                if (!string.IsNullOrWhiteSpace(rowTitle))
                {
                    span = GetSpan(calendarCell, totalSpan);

                    totalSpan -= span;
                }
                

                calendarCell.CellRows.AddRow(ev.Id, rowTitle, ev.Description, span);
            }
        }

        private int GetSpan(CalendarCell currentCel, int totalSpan)
        {
            var column = currentCel.Column;
            var span = 0;
            for (int i = 0; i < totalSpan; i++, column++, span++)
            {
                if (column == 8)
                {
                    return span;
                }
            }

            return span;
        }

        private string GetRowTitle(int i, string eventTitle, CalendarCell calendarCell)
        {
            var rowTitle = i == 0 ? eventTitle : string.Empty;

            if (calendarCell.Column == 1 && i > 0)
            {
                rowTitle = $"{eventTitle} Cont..";
            }

            return rowTitle;
        }

        private void CreateOverlappingEvents(CalendarEvent ev, CalendarGrid calendarGrid)
        {
            var eventDateDifference = (int) (ev.DateTimeTo - ev.DateTimeFrom).TotalDays + 1;
            var row = 0;
            var eventTitle = ev.Title;

            var totalSpan = eventDateDifference;

            for (int i = 0; i < eventDateDifference; i++)
            {
                var currentDay = ev.DateTimeFrom.AddDays(i);

                var calendarCell = calendarGrid[currentDay];

                if (calendarCell == null)
                {
                    break;
                }

                var rowTitle = GetRowTitle(i, eventTitle, calendarCell);
                int span = 0;
                if (!string.IsNullOrWhiteSpace(rowTitle))
                {
                    span = GetSpan(calendarCell, totalSpan);

                    totalSpan -= span;
                }

                var cellRows = calendarCell.CellRows;
                row = row == 0 ? cellRows.GetNewRowNumber() : row;
                calendarCell.CellRows.AddRow(ev.Id, rowTitle, ev.Description, span, row);
            }
        }
    }
}
