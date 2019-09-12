using System;
using FluentAssertions;
using Xunit;

namespace Luminous.Code.Tests.Enums
{
    using StartPagePlus.UI.Enums;
    using static StartPagePlus.UI.Enums.PeriodTypes;

    public class CalculatePeriodType_Tests
    {
        // sameday

        [Theory]
        [InlineData("2019-08-18", "2019-08-18")] // sunday
        [InlineData("2019-08-15", "2019-08-15")] // thursday
        [InlineData("2019-08-12", "2019-08-12")] // monday
        public void Pinned_SameDay_ReturnsPeriodTypePinned(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = true;

            var result = CalculatePeriodType(pinned, currentDate, comparisonDate);

            result.Should().Be(PeriodType.Pinned);
        }

        [Theory]
        [InlineData("2019-08-18", "2019-08-18")] // sunday
        [InlineData("2019-08-15", "2019-08-15")] // thursday
        [InlineData("2019-08-12", "2019-08-12")] // monday
        public void NotPinned_SameDay_ReturnsPeriodTypeToday(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = false;

            var result = CalculatePeriodType(pinned, currentDate, comparisonDate);

            result.Should().Be(PeriodType.Today);
        }

        //previous day

        [Theory]
        [InlineData("2019-08-18", "2019-08-17")] // sunday/saturday
        [InlineData("2019-08-17", "2019-08-16")] // saturday/friday
        [InlineData("2019-08-16", "2019-08-15")] // friday/thursday
        [InlineData("2019-08-15", "2019-08-14")] // thursday/wednesday
        [InlineData("2019-08-14", "2019-08-13")] // wednesday/tuesday
        [InlineData("2019-08-13", "2019-08-12")] // tuesday/monday
        public void Pinned_PreviousDay_ReturnsPeriodTypePinned(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = true;

            var result = CalculatePeriodType(pinned, currentDate, comparisonDate);

            result.Should().Be(PeriodType.Pinned);
        }

        [Theory]
        [InlineData("2019-08-18", "2019-08-17")] // sunday/saturday
        [InlineData("2019-08-17", "2019-08-16")] // saturday/friday
        [InlineData("2019-08-16", "2019-08-15")] // friday/thursday
        [InlineData("2019-08-15", "2019-08-14")] // thursday/wednesday
        [InlineData("2019-08-14", "2019-08-13")] // wednesday/tuesday
        [InlineData("2019-08-13", "2019-08-12")] // tuesday/monday
        public void NotPinned_PreviousDay_ReturnsPeriodTypeYesterday(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = false;

            var result = CalculatePeriodType(pinned, currentDate, comparisonDate);

            result.Should().Be(PeriodType.Yesterday);
        }

        // this week

        [Theory]
        [InlineData("2019-08-18", "2019-08-16")] // sunday/friday
        [InlineData("2019-08-18", "2019-08-15")] // sunday/thursday
        [InlineData("2019-08-18", "2019-08-14")] // sunday/wednesday
        [InlineData("2019-08-18", "2019-08-13")] // sunday/tuesday
        [InlineData("2019-08-18", "2019-08-12")] // sunday/monday

        public void Pinned_ThisWeek_ReturnsPeriodTypePinned(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = true;

            var result = CalculatePeriodType(pinned, currentDate, comparisonDate);

            result.Should().Be(PeriodType.Pinned);
        }

        [Theory]
        [InlineData("2019-08-18", "2019-08-16")] // sunday/friday
        [InlineData("2019-08-18", "2019-08-15")] // sunday/thursday
        [InlineData("2019-08-18", "2019-08-14")] // sunday/wednesday
        [InlineData("2019-08-18", "2019-08-13")] // sunday/tuesday
        [InlineData("2019-08-18", "2019-08-12")] // sunday/monday
        public void NotPinned_ThisWeek_ReturnsPeriodTypeThisWeek(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = false;

            var result = CalculatePeriodType(pinned, currentDate, comparisonDate);

            result.Should().Be(PeriodType.ThisWeek);
        }

        //last week

        [Theory]
        [InlineData("2019-08-18", "2019-08-11")] // sunday/previous sunday
        [InlineData("2019-08-18", "2019-08-10")] // sunday/previous saturday
        [InlineData("2019-08-18", "2019-08-09")] // sunday/previous friday
        [InlineData("2019-08-18", "2019-08-08")] // sunday/previous thursday
        [InlineData("2019-08-18", "2019-08-07")] // sunday/previous wednesday
        [InlineData("2019-08-18", "2019-08-06")] // sunday/previous tuesday
        [InlineData("2019-08-18", "2019-08-05")] // sunday/previous monday
        public void Pinned_LastWeek_ReturnsPeriodTypePinned(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = true;

            var result = CalculatePeriodType(pinned, currentDate, comparisonDate);

            result.Should().Be(PeriodType.Pinned);
        }

        [Theory]
        [InlineData("2019-08-18", "2019-08-11")] // sunday/previous sunday
        [InlineData("2019-08-18", "2019-08-10")] // sunday/previous saturday
        [InlineData("2019-08-18", "2019-08-09")] // sunday/previous friday
        [InlineData("2019-08-18", "2019-08-08")] // sunday/previous thursday
        [InlineData("2019-08-18", "2019-08-07")] // sunday/previous wednesday
        [InlineData("2019-08-18", "2019-08-06")] // sunday/previous tuesday
        [InlineData("2019-08-18", "2019-08-05")] // sunday/previous monday
        public void NotPinned_LastWeek_ReturnsPeriodTypeThisMonth(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = false;

            var result = CalculatePeriodType(pinned, currentDate, comparisonDate);

            result.Should().Be(PeriodType.ThisMonth);
        }

        [Theory]
        [InlineData("2019-08-18", "2019-08-04")] // sunday/2 sundays ago
        [InlineData("2019-08-18", "2019-08-03")] // sunday/2 saturdays ago
        [InlineData("2019-08-18", "2019-08-02")] // sunday/2 fridays ago
        [InlineData("2019-08-18", "2019-08-01")] // sunday/2 thursdays ago
        public void Pinned_ThisMonth_ReturnsPeriodTypePinned(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = true;

            var result = CalculatePeriodType(pinned, currentDate, comparisonDate);

            result.Should().Be(PeriodType.Pinned);
        }

        [Theory]
        [InlineData("2019-08-18", "2019-08-04")] // sunday/2 sundays ago
        [InlineData("2019-08-18", "2019-08-03")] // sunday/2 saturdays ago
        [InlineData("2019-08-18", "2019-08-02")] // sunday/2 fridays ago
        [InlineData("2019-08-18", "2019-08-01")] // sunday/2 thursdays ago
        public void NotPinned_ThisMonth_ReturnsPeriodTypeThisMonth(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = false;

            var result = CalculatePeriodType(pinned, currentDate, comparisonDate);

            result.Should().Be(PeriodType.ThisMonth);
        }

        [Theory]
        [InlineData("2019-08-18", "2019-07-31")] // sunday/last day of previous month
        [InlineData("2019-08-18", "2019-07-01")] // sunday/first day of previous month
        [InlineData("2019-08-18", "2018-01-01")] // sunday/first day of previous year
        public void Pinned_Older_ReturnsPeriodTypePinned(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = true;

            var result = CalculatePeriodType(pinned, currentDate, comparisonDate);

            result.Should().Be(PeriodType.Pinned);
        }

        [Theory]
        [InlineData("2019-08-18", "2019-07-31")] // sunday/last day of previous month
        [InlineData("2019-08-18", "2019-07-01")] // sunday/first day of previous month
        [InlineData("2019-08-18", "2018-01-01")] // sunday/first day of previous year
        public void NotPinned_Older_ReturnsPeriodTypeOlder(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = false;

            var result = CalculatePeriodType(pinned, currentDate, comparisonDate);

            result.Should().Be(PeriodType.Older);
        }
    }
}