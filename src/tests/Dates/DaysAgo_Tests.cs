using System;
using FluentAssertions;
using Xunit;

namespace Luminous.Code.Dates.Tests
{
    using Luminous.Code.Dates;

    public class DaysAgo_Tests
    {
        [Fact]
        public void SameDate_ReturnsZero()
        {
            var currentDate = new DateTime(2019, 8, 21);
            var comparisonDate = new DateTime(2019, 8, 21);
            var expected = 0;

            var actual = Dates.DaysAgo(currentDate, comparisonDate);

            actual.Should().Be(expected);
        }

        [Fact]
        public void FutureDate_ReturnsZero()
        {
            var currentDate = new DateTime(2019, 8, 21);
            var comparisonDate = new DateTime(2019, 8, 20);
            var expected = 0;

            var actual = Dates.DaysAgo(currentDate, comparisonDate);

            actual.Should().Be(expected);
        }
    }

}