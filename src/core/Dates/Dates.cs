using System;

namespace Luminous.Code.Dates
{
    public static class Dates
    {
        public enum DatePeriods
        {

            Pinned = 0,
            Today = 1,
            Yesterday = 2,
            ThisWeek = 3,
            LastWeek = 4,
            LastMonth = 5,
            Older = 10
        }

        public static int DaysAgo(DateTime currentDate, DateTime comparisonDate)
        {
            var days = (comparisonDate.Date - currentDate.Date).Days;

            return (days >= 0)
                ? days
                : 0;
        }

        public static int DatePeriod(DateTime currentDate, DateTime comparisonDate)
        {
            var daysAgo = DaysAgo(currentDate, comparisonDate);

            switch (daysAgo)
            {
                case 0:
                    return daysAgo;

                default:
                    return -1;
            }
        }
    }
}