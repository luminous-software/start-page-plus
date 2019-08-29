using System;
using FluentAssertions;
using Xunit;

namespace Luminous.Code.DateTests
{
    using static Dates.DateMethods;

    public class DatePeriod_Tests
    {
        // sameday

        [Theory]
        [InlineData("2019-08-12", "2019-08-12")] // monday
        [InlineData("2019-08-15", "2019-08-15")] // thursday
        [InlineData("2019-08-18", "2019-08-18")] // sunday
        public void Pinned_SameDay_ReturnsPinned(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = true;

            var result = DatePeriod(pinned, currentDate, comparisonDate);

            result.Should().Be((int)DatePeriods.Pinned);
        }

        [Theory]
        [InlineData("2019-08-12", "2019-08-12")] // monday
        [InlineData("2019-08-15", "2019-08-15")] // thursday
        [InlineData("2019-08-18", "2019-08-18")] // sunday
        public void NotPinned_SameDay_ReturnsToday(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = false;

            var result = DatePeriod(pinned, currentDate, comparisonDate);

            result.Should().Be((int)DatePeriods.Today);
        }

        //previous day

        [Theory]
        [InlineData("2019-08-13", "2019-08-12")] // tuesday/monday
        [InlineData("2019-08-14", "2019-08-13")] // wednesday/tuesday
        [InlineData("2019-08-15", "2019-08-14")] // thursday/wednesday
        [InlineData("2019-08-16", "2019-08-15")] // friday/thursday
        [InlineData("2019-08-17", "2019-08-16")] // saturday/friday
        [InlineData("2019-08-18", "2019-08-17")] // sunday/saturday
        public void Pinned_PreviousDay_ReturnsPinned(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = true;

            var result = DatePeriod(pinned, currentDate, comparisonDate);

            result.Should().Be((int)DatePeriods.Pinned);
        }

        [Theory]
        [InlineData("2019-08-13", "2019-08-12")] // tuesday/monday
        [InlineData("2019-08-14", "2019-08-13")] // wednesday/tuesday
        [InlineData("2019-08-15", "2019-08-14")] // thursday/wednesday
        [InlineData("2019-08-16", "2019-08-15")] // friday/thursday
        [InlineData("2019-08-17", "2019-08-16")] // saturday/friday
        [InlineData("2019-08-18", "2019-08-17")] // sunday/saturday
        public void NotPinned_PreviousDay_ReturnsYesterday(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = false;

            var result = DatePeriod(pinned, currentDate, comparisonDate);

            result.Should().Be((int)DatePeriods.Yesterday);
        }

        // this week

        [Theory]
        [InlineData("2019-08-18", "2019-08-12")] // sunday/monday
        [InlineData("2019-08-18", "2019-08-13")] // sunday/tuesday
        [InlineData("2019-08-18", "2019-08-14")] // sunday/wednesday
        [InlineData("2019-08-18", "2019-08-15")] // sunday/thursday
        [InlineData("2019-08-18", "2019-08-16")] // sunday/friday

        public void Pinned_DatesFromThisWeek_ReturnPinned(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = true;
            const int expectedValue = (int)DatePeriods.Pinned;

            var result = DatePeriod(pinned, currentDate, comparisonDate);

            result.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("2019-08-18", "2019-08-12")] // sunday/monday
        [InlineData("2019-08-18", "2019-08-13")] // sunday/tuesday
        [InlineData("2019-08-18", "2019-08-14")] // sunday/wednesday
        [InlineData("2019-08-18", "2019-08-15")] // sunday/thursday
        [InlineData("2019-08-18", "2019-08-16")] // sunday/friday
        public void NotPinned_DatesFromThisWeek_ReturnThisWeek(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = false;
            const int expectedValue = (int)DatePeriods.ThisWeek;

            var result = DatePeriod(pinned, currentDate, comparisonDate);

            result.Should().Be(expectedValue);
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
        public void NotPinned_DatesFromLastWeek_ReturnThisMonth(DateTime currentDate, DateTime comparisonDate)
        {
            const bool pinned = false;
            const int expectedValue = (int)DatePeriods.ThisMonth;

            var result = DatePeriod(pinned, currentDate, comparisonDate);

            result.Should().Be(expectedValue);
        }
    }
}