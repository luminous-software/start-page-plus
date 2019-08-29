using System;

namespace Luminous.Code.Dates
{
    public static class DateExtensions
    {
        public static DateTime StartOfWeek(this DateTime date, DayOfWeek weekStarts = DayOfWeek.Monday)
        {
            var diff = (7 + (date.DayOfWeek - weekStarts)) % 7;

            return date.AddDays(-1 * diff).Date;
        }

        // https://markb.uk/csharp-datetime-get-first-last-day-of-week-or-month.html

        //TODO: add tests for FirstDayOfWeek, LastDayOfWeek, FirstDayOfMonth, LastDayOfMonth, FirstDayOfNextMonth
        public static DateTime FirstDayOfWeek(this DateTime date, DayOfWeek weekStarts = DayOfWeek.Monday)
        {
            //var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = date.DayOfWeek - weekStarts;

            if (diff < 0)
            {
                diff += 7;
            }

            return date.AddDays(-diff).Date;
        }

        public static DateTime LastDayOfWeek(this DateTime date)
            => date.FirstDayOfWeek().AddDays(6);

        public static DateTime FirstDayOfMonth(this DateTime date)
            => new DateTime(date.Year, date.Month, 1);

        public static DateTime LastDayOfMonth(this DateTime date)
            => date.FirstDayOfMonth().AddMonths(1).AddDays(-1);

        public static DateTime FirstDayOfNextMonth(this DateTime date)
            => date.FirstDayOfMonth().AddMonths(1);
    }
}