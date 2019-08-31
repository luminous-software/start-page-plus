using FluentAssertions;
using Xunit;

namespace Luminous.Code.Tests.Dates
{
    using StartPagePlus.UI.Enums;
    using static StartPagePlus.UI.Dates.DateMethods;

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
        public void DateThisWeek_ReturnsThisSpaceWeek()
        {
            const DatePeriods datePeriod = DatePeriods.ThisWeek;
            const string expectedValue = "This Week";

            var result = DatePeriodToString(datePeriod);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void DatesThisMonth_ReturnsThisSpaceMonth()
        {
            const DatePeriods datePeriod = DatePeriods.ThisMonth;
            const string expectedValue = "This Month";

            var result = DatePeriodToString(datePeriod);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void DatesOlder_ReturnsOlder()
        {
            const DatePeriods datePeriod = DatePeriods.Older;
            const string expectedValue = "Older";

            var result = DatePeriodToString(datePeriod);

            result.Should().Be(expectedValue);
        }
    }
}