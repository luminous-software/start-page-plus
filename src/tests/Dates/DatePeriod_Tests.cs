using System;
using FluentAssertions;
using Xunit;

namespace DeveloperNews.Tests.Dates
{
    using static Luminous.Code.Dates.Dates;

    public class DatePeriod_Tests
    {
        [Fact]
        public void SameDay_ReturnsToday()
        {
            var currentDate = new DateTime(2019, 8, 21);
            var comparisonDate = new DateTime(2019, 8, 21);
            var expected = (int)DatePeriods.Today;

            var actual = DatePeriod(currentDate, comparisonDate);

            actual.Should().Be(expected);
        }
    }

    [Theory]
    [InlineData]

    public void DatesFromLastWeek_ReturnLastWeek()
    {

    }
}