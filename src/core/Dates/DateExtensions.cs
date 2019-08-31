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

        //TODO: add tests for FirstDayOfPreviousWeek, LastDayOfPreviousWeek, FirstDayOfWeek, LastDayOfWeek, FirstDayOfMonth, LastDayOfMonth, FirstDayOfPreviousMonth, LastDayOfPreviousMonth

        public static DateTime FirstDayOfPreviousWeek(this DateTime instance)
            => instance.LastDayOfPreviousWeek().AddDays(-6);

        public static DateTime LastDayOfPreviousWeek(this DateTime instance)
            => instance.FirstDayOfWeek().AddDays(-1);

        public static DateTime FirstDayOfWeek(this DateTime instance, DayOfWeek weekStarts = DayOfWeek.Monday)
        {
            //var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = instance.DayOfWeek - weekStarts;

            if (diff < 0)
            {
                diff += 7;
            }

            return instance.AddDays(-diff).Date;
        }

        public static DateTime LastDayOfWeek(this DateTime instance)
            => instance.FirstDayOfWeek().AddDays(6);

        public static DateTime FirstDayOfMonth(this DateTime instance) =>
        new DateTime(instance.Year, instance.Month, 1);

        public static DateTime LastDayOfMonth(this DateTime instance) =>
            instance.FirstDayOfMonth().AddMonths(1).AddDays(-1);

        public static DateTime FirstDayOfNextMonth(this DateTime instance)
            => new DateTime(instance.Year, instance.Month, 1);

        public static DateTime LastDayOfNextMonth(this DateTime instance)
            => instance.FirstDayOfNextMonth().AddMonths(1).AddDays(-1);
    }
}