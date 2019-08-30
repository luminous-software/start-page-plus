using FluentAssertions;
using Luminus.Code.Enums;
using Xunit;

namespace Luminous.Code.Tests.Dates
{
    using static Luminous.Code.Dates.DateMethods;

    public class DatePeriodToString_Tests
    {
        [Fact]
        public void Pinned_ReturnsPinned()
        {
            const DatePeriods datePeriod = DatePeriods.Pinned;
            const string expectedValue = "Pinned";

            var result = DatePeriodToString(datePeriod);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void Today_ReturnsToday()
        {
            const DatePeriods datePeriod = DatePeriods.Today;
            const string expectedValue = "Today";

            var result = DatePeriodToString(datePeriod);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void Yesterday_ReturnsYesterday()
        {
            const DatePeriods datePeriod = DatePeriods.Yesterday;
            const string expectedValue = "Yesterday";

            var result = DatePeriodToString(datePeriod);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void ThisWeek_ReturnsThisSpaceWeek()
        {
            const DatePeriods datePeriod = DatePeriods.ThisWeek;
            const string expectedValue = "This Week";

            var result = DatePeriodToString(datePeriod);

            result.Should().Be(expectedValue);
        }
    }
}