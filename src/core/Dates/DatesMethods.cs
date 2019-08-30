using System;

namespace Luminous.Code.Dates
{
    using Luminus.Code.Enums;

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

        public static int DatePeriod(bool pinned, DateTime currentDate, DateTime comparisonDate)
        {
            if (currentDate < comparisonDate)
            {
                throw new ArgumentOutOfRangeException("DatePeriod: comparison date can't be in the future");
            }

            if (pinned)
            {
                return (int)DatePeriods.Pinned;
            }

            var daysAgo = DaysAgo(currentDate, comparisonDate);

            switch (daysAgo)
            {
                case 0:
                    return (int)DatePeriods.Today;

                case 1:
                    return (int)DatePeriods.Yesterday;

                default:
                    break;
            }

            return ThisWeek()
                ? (int)DatePeriods.ThisWeek
                : (LastWeek() || ThisMonth())
                    ? (int)DatePeriods.ThisMonth
                    : (int)DatePeriods.Older;

            bool ThisWeek()
            {
                return (comparisonDate < currentDate) && (comparisonDate >= currentDate.FirstDayOfWeek());
            }

            bool LastWeek()
            {
                return (comparisonDate >= currentDate.FirstDayOfWeek().AddDays(-7)) && (comparisonDate <= currentDate.LastDayOfWeek().AddDays(-7));
            }

            bool ThisMonth()
            {
                return (comparisonDate >= currentDate.FirstDayOfMonth()) && (comparisonDate < currentDate.FirstDayOfWeek().AddDays(-7));
            }
        }

        public static string DatePeriodToString(DatePeriods datePeriod)
            => datePeriod.ToString();//.ToWords();

    }
}