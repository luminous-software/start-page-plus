using System;

namespace Luminous.Code.Dates
{
    public static class DateMethods
    {
        public enum DatePeriods
        {

            Pinned = 0,
            Today = 1,
            Yesterday = 2,
            ThisWeek = 3,
            ThisMonth = 4,
            Older = 5
        }

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

            if (ThisWeek())
            {
                return (int)DatePeriods.ThisWeek;
            }

            if (LastWeek())
            {
                return (int)DatePeriods.ThisMonth;
            }

            return (int)DatePeriods.Older;

            bool ThisWeek()
            {
                var startDayOfWeek = currentDate.StartOfWeek().DayOfWeek;
                var comparisonDayOfWeek = comparisonDate.DayOfWeek;

                return (comparisonDate < currentDate) && (comparisonDate >= currentDate.FirstDayOfWeek());
            }

            bool LastWeek()
            {
                return (comparisonDate >= currentDate.FirstDayOfWeek().AddDays(-7)) && (comparisonDate <= currentDate.LastDayOfWeek().AddDays(-7));
            }
        }
    }
}