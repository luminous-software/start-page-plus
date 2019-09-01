using System;
using Luminous.Code.Extensions.DateExtensions;

namespace StartPagePlus.UI.DatePeriods.Methods
{
    using Core.Extensions.EnumExtensions;
    using DatePeriods.Enums;
    using static Dates.DateMethods;

    public class DatePeriodMethods
    {
        public static int CalculateDatePeriod(bool pinned, DateTime currentDate, DateTime comparisonDate)
        {
            if (currentDate < comparisonDate)
            {
                throw new ArgumentOutOfRangeException("DatePeriod: comparison date can't be in the future");
            }

            if (pinned)
            {
                return (int)DatePeriod.Pinned;
            }

            var daysAgo = DaysAgo(currentDate, comparisonDate);

            switch (daysAgo)
            {
                case 0:
                    return (int)DatePeriod.Today;

                case 1:
                    return (int)DatePeriod.Yesterday;

                default:
                    break;
            }

            return ThisWeek()
                ? (int)DatePeriod.ThisWeek
                : (LastWeek() || ThisMonth())
                    ? (int)DatePeriod.ThisMonth
                    : (int)DatePeriod.Older;

            bool ThisWeek()
                => (comparisonDate < currentDate) && (comparisonDate >= currentDate.FirstDayOfWeek());

            bool LastWeek()
                => (comparisonDate >= currentDate.FirstDayOfPreviousWeek()) && (comparisonDate <= currentDate.LastDayOfPreviousWeek());

            bool ThisMonth()
                => (comparisonDate >= currentDate.FirstDayOfNextMonth()) && (comparisonDate < currentDate.LastDayOfMonth());
        }


        public static string IdToString(int id)
        => ((DatePeriod)id).GetName();

        public static string DatePeriodToString(DatePeriod period)
            => period.GetName();
    }
}