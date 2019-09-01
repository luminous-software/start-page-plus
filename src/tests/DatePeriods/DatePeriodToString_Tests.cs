using FluentAssertions;
using Xunit;

namespace Luminous.Code.Tests.Dates
{
    using StartPagePlus.UI.DatePeriods.Enums;
    using static StartPagePlus.UI.DatePeriods.Methods.DatePeriodMethods;

    public class DatePeriodToString_Tests
    {
        [Fact]
        public void Pinned_ReturnsPinned()
        {
            const DatePeriod datePeriod = DatePeriod.Pinned;
            const string expectedValue = "Pinned";

            var result = DatePeriodToString(datePeriod);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void Today_ReturnsToday()
        {
            const DatePeriod datePeriod = DatePeriod.Today;
            const string expectedValue = "Today";

            var result = DatePeriodToString(datePeriod);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void Yesterday_ReturnsYesterday()
        {
            const DatePeriod datePeriod = DatePeriod.Yesterday;
            const string expectedValue = "Yesterday";

            var result = DatePeriodToString(datePeriod);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void DateThisWeek_ReturnsThisSpaceWeek()
        {
            const DatePeriod datePeriod = DatePeriod.ThisWeek;
            const string expectedValue = "This Week";

            var result = DatePeriodToString(datePeriod);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void DatesThisMonth_ReturnsThisSpaceMonth()
        {
            const DatePeriod datePeriod = DatePeriod.ThisMonth;
            const string expectedValue = "This Month";

            var result = DatePeriodToString(datePeriod);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void DatesOlder_ReturnsOlder()
        {
            const DatePeriod datePeriod = DatePeriod.Older;
            const string expectedValue = "Older";

            var result = DatePeriodToString(datePeriod);

            result.Should().Be(expectedValue);
        }
    }
}