using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.HtmlBuilders.CalendarBuilder
{
    public class CellRows : List<CellRow>
    {
        public void AddRow(int id, string title, string description, int span, int row = 1)
        {
            this.Add(new CellRow
            {
                Row = row,
                Event = new CellEvent
                {
                    Id = id,
                    Title = title,
                    Description = description
                },
                Span = span
            });
        }

        public int GetNewRowNumber()
        {
            var newRow = 1;
            var cellRows = this.OrderBy(cr => cr.Row).ToList();

            for (int i = 0; i < cellRows.Count; i++)
            {
                var row = cellRows[i].Row;
                newRow = i + 1 < row ? i + 1 : row + 1;
            }

            return newRow;
        }
    }
}