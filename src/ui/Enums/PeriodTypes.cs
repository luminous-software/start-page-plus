using System;
using Luminous.Code.Extensions.Dates;

namespace StartPagePlus.UI.Enums
{
    using Core.Extensions.Enums;
    using static Dates.DateMethods;

    public static class PeriodTypes
    {
        public static PeriodType CalculatePeriodType(bool pinned, DateTime currentDate, DateTime comparisonDate)
        {
            if (currentDate < comparisonDate)
            {
                throw new ArgumentOutOfRangeException("PeriodType: comparison date can't be in the future");
            }

            if (pinned)
            {
                return (int)PeriodType.Pinned;
            }

            var daysAgo = DaysAgo(currentDate, comparisonDate);

            switch (daysAgo)
            {
                case 0:
                    return PeriodType.Today;

                case 1:
                    return PeriodType.Yesterday;

                default:
                    break;
            }

            return ThisWeek()
                ? PeriodType.ThisWeek
                : (LastWeek() || ThisMonth())
                    ? PeriodType.ThisMonth
                    : PeriodType.Older;

            bool ThisWeek()
                => (comparisonDate < currentDate) && (comparisonDate >= currentDate.FirstDayOfWeek());

            bool LastWeek()
                => (comparisonDate >= currentDate.FirstDayOfPreviousWeek()) && (comparisonDate <= currentDate.LastDayOfPreviousWeek());

            bool ThisMonth()
                => (comparisonDate >= currentDate.FirstDayOfNextMonth()) && (comparisonDate < currentDate.LastDayOfMonth());
        }

        public static string ToName(this PeriodType period)
            => period.GetName();
    }
}