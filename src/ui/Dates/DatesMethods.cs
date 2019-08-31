using System;
using Luminous.Code.Dates;

namespace StartPagePlus.UI.Dates
{
    using UI.Enums;

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

        public static DatePeriods DatePeriod(bool pinned, DateTime currentDate, DateTime comparisonDate)
        {
            if (currentDate < comparisonDate)
            {
                throw new ArgumentOutOfRangeException("DatePeriod: comparison date can't be in the future");
            }

            if (pinned)
            {
                return DatePeriods.Pinned;
            }

            var daysAgo = DaysAgo(currentDate, comparisonDate);

            switch (daysAgo)
            {
                case 0:
                    return DatePeriods.Today;

                case 1:
                    return DatePeriods.Yesterday;

                default:
                    break;
            }

            return ThisWeek()
                ? DatePeriods.ThisWeek
                : (LastWeek() || ThisMonth())
                    ? DatePeriods.ThisMonth
                    : DatePeriods.Older;

            bool ThisWeek()
                => (comparisonDate < currentDate) && (comparisonDate >= currentDate.FirstDayOfWeek());

            bool LastWeek()
                => (comparisonDate >= currentDate.FirstDayOfPreviousWeek()) && (comparisonDate <= currentDate.LastDayOfPreviousWeek());

            bool ThisMonth()
                => (comparisonDate >= currentDate.FirstDayOfNextMonth()) && (comparisonDate < currentDate.LastDayOfMonth());
        }

        public static string DatePeriodToString(DatePeriods datePeriod)
            =>
            datePeriod.ToString();//.ToWords();

    }
}