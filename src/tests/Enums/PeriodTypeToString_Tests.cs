using FluentAssertions;
using Xunit;

namespace Luminous.Code.Tests.Enums
{
    using StartPagePlus.UI.Enums;

    public class PeriodTypeToName_Tests
    {
        [Fact]
        public void Pinned_ReturnsPinned()
        {
            const PeriodType periodType = PeriodType.Pinned;
            const string expectedValue = "Pinned";

            var result = periodType.ToName();

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void Today_ReturnsToday()
        {
            const PeriodType periodType = PeriodType.Today;
            const string expectedValue = "Today";

            var result = periodType.ToName();

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void Yesterday_ReturnsYesterday()
        {
            const PeriodType periodType = PeriodType.Yesterday;
            const string expectedValue = "Yesterday";

            var result = periodType.ToName();

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void DateThisWeek_ReturnsThisSpaceWeek()
        {
            const PeriodType periodType = PeriodType.ThisWeek;
            const string expectedValue = "This Week";

            var result = periodType.ToName();

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void DatesThisMonth_ReturnsThisSpaceMonth()
        {
            const PeriodType periodType = PeriodType.ThisMonth;
            const string expectedValue = "This Month";

            var result = periodType.ToName();

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void DatesOlder_ReturnsOlder()
        {
            const PeriodType periodType = PeriodType.Older;
            const string expectedValue = "Older";

            var result = periodType.ToName();

            result.Should().Be(expectedValue);
        }
    }
}