using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Common.Collections;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Common.HtmlBuilders.CalendarBuilder
{
    public class CalendarBuilder : HtmlBuilderBase
    {
        private readonly DateTime _calendarDate;
        private readonly List<DateTime> _calendarDays;
        private readonly string[] _months = DateTimeFormatInfo.CurrentInfo?.MonthNames ?? CultureInfo.GetCultureInfo("en-GB").DateTimeFormat.MonthNames;

        public CalendarBuilder(DateTime calendarDate)
        {
            _calendarDate = calendarDate;
            var calendar = new Calendar(_calendarDate.Year, _calendarDate.Month);
            _calendarDays = calendar.GetCalendarDays();
        }

        public IHtmlContent CreateCalendar(IReadOnlyCollection<CalendarEvent> calendarEvents)
        {
            var calendarHeader = CreateHeader();

            var daysOfTheWeek = CreateDaysOfTheWeek();
            var days = CreateDays();
            var events = CreateEvents(calendarEvents);

            var calendarGrid = new List<IHtmlContent>();
            calendarGrid.AddRange(daysOfTheWeek);
            calendarGrid.AddRange(days);
            calendarGrid.AddRange(events);

            var calendar = CreateBasicElement(calendarGrid, "div",  new HtmlAttributes("calendar"));

            var calendarContainer = CreateBasicElement(new List<IHtmlContent> { calendarHeader, calendar }, "div",  new HtmlAttributes("calendar-container"));

            return calendarContainer;
        }

        public IHtmlContent CreateHeader()
        {
            var month = CreateDropdownList(new Collections.HtmlAttributes(otherAttributes: new Dictionary<string, string>() { {"data-role", "month-dropdown"} } ));
            var year = CreateBasicElement(new List<IHtmlContent>(), "p", value: _calendarDate.ToString("yyyy"));
            var calendarHeader = CreateBasicElement(new List<IHtmlContent> { month, year }, "div", new HtmlAttributes("calendar-header"));
            return calendarHeader;
        }

        private IHtmlContent CreateDropdownList(Collections.HtmlAttributes htmlAttributes)
        {
            var dropdownBuilder = new DropdownBuilder();

            var dropdown = dropdownBuilder.CreateDropdown(GetMonthSelectListOptions(), htmlAttributes);

            return dropdown;
        }

        private List<SelectListItem> GetMonthSelectListOptions()
        {
            var selectList = new List<SelectListItem>();
            for (int i = 0; i < _months.Length; i++)
            {
                if(string.IsNullOrWhiteSpace(_months[i])) continue;
                
                selectList.Add(new SelectListItem(_months[i], (i + 1).ToString(), (i + 1) == _calendarDate.Month));
            }

            return selectList;
        }


        public IEnumerable<IHtmlContent> CreateDaysOfTheWeek()
        {
            foreach (var dayOfWeek in Enum.GetNames(typeof(DayOfWeek)))
            {
                yield return CreateBasicElement(new List<IHtmlContent>(), "span", new HtmlAttributes("day-name"), dayOfWeek);
            }
        }

        public List<IHtmlContent> CreateDays()
        {
            var days = new List<IHtmlContent>();
            foreach (var day in _calendarDays)
            {
                var className = IsThisMonth(day) ? "day" : "day day--disabled";
                className += DateTime.UtcNow.Date == day.Date ? " day--selected" : string.Empty;
                
                var dayDiv = CreateBasicElement(new List<IHtmlContent>(), "div", new HtmlAttributes(className, otherAttributes: new Dictionary<string, string>{{"data-id", day.Date.ToString("yyyy-MM-dd")}}), day.Day.ToString());
                days.Add(dayDiv);
            }

            return days;
        }

        
        public IEnumerable<IHtmlContent> CreateEvents(IEnumerable<CalendarEvent> events)
        {
            var calendarEvents = new CalendarEvents(_calendarDays).AddEvents(events.Where(e =>
                e.DateTimeFrom >= _calendarDays.First()
                && e.DateTimeFrom <= _calendarDays.Last()).ToList());

            foreach (var calendarCell in calendarEvents)
            {
                foreach (var calendarEvent in calendarCell.CellRows.Where(cr => cr.Span > 0))
                {
                    yield return 
                        CreateBasicElement(
                            CreateInnerEventDetails(calendarEvent.Event).ToList(), 
                            "section", 
                            CreateEventAttributes(calendarCell, calendarEvent), 
                            calendarEvent.Event.Title);
                }
            }
        }

        private IEnumerable<IHtmlContent> CreateInnerEventDetails(CellEvent calendarEventEvent)
        {
            if (!string.IsNullOrWhiteSpace(calendarEventEvent.Description))
            {
                yield return CreateDescription(calendarEventEvent);
            }
        }

        private IHtmlContent CreateDescription(CellEvent calendarEvent)
        {
            var description = CreateBasicElement(new List<IHtmlContent>(), "h2", value: calendarEvent.Description);
            var divWrapper = CreateBasicElement(new List<IHtmlContent> {description}, "div",
                new HtmlAttributes("task__detail"));

            return divWrapper;
        }

        private HtmlAttributes CreateEventAttributes(CalendarCell calendarCell, CellRow cell)
        {
            var style = $"{GetColumnStyle(calendarCell.Column, cell.Span)} {GetRowStyle(calendarCell.Row + cell.Row - 1)}";
            return new HtmlAttributes(
                $"task task--info",
                style,
                otherAttributes: new Dictionary<string, string>{{"data-id", cell.Event.Id.ToString()}});
        }


        private static string GetColumnStyle(int dayColumnIndex, double span)
        {
            return $"grid-column: {dayColumnIndex} / span {span};";
        }

        private static string GetRowStyle(int dayRowIndex)
        {
            return $"grid-row: {dayRowIndex};";
        }

        private bool IsThisMonth(DateTime currentDateTime)
        {
            return _calendarDate.Month == currentDateTime.Month;
        }

        
    }
}
