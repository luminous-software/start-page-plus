using System;
using FluentAssertions;
using Xunit;

namespace Luminous.Code.Tests.Dates
{
    using static StartPagePlus.UI.Dates.DateMethods;

    public class DaysAgo_Tests
    {
        [Fact]
        public void FutureDate_ThrowsArgumentOutOfRangeException()
        {
            var currentDate = new DateTime(2019, 8, 21);
            var comparisonDate = currentDate.AddDays(1);

            Action action = () => DaysAgo(currentDate, comparisonDate);

            action.Should().Throw<ArgumentOutOfRangeException>();

            //https://fluentassertions.com/exceptions/
            //.WithMessage("DaysAgo: comparison date can't be in the future");
        }

        [Fact]
        public void SameDay_ReturnsZero()
        {
            var currentDate = new DateTime(2019, 8, 21);
            var comparisonDate = new DateTime(2019, 8, 21);
            var expectedValue = 0;

            var result = DaysAgo(currentDate, comparisonDate);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void PreviousDay_ReturnsOne()
        {
            var currentDate = new DateTime(2019, 8, 21);
            var comparisonDate = new DateTime(2019, 8, 20);
            var expectedValue = 1;

            var result = DaysAgo(currentDate, comparisonDate);

            result.Should().Be(expectedValue);
        }
    }

}