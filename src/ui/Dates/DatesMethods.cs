using System;

namespace StartPagePlus.UI.Dates
{
    // https://markb.uk/csharp-datetime-get-first-last-day-of-week-or-month.html

    public static class DateMethods
    {
        public static int DaysAgo(DateTime currentDate, DateTime comparisonDate)
        {
            var days = (currentDate.Date - comparisonDate.Date).Days;

            if (days < 0)
            {
                throw new ArgumentOutOfRangeException("DaysAgo: comparison date can't be in the future");
            }

            return days;
        }
    }
}