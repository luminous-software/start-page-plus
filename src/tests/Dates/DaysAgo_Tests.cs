using System;
using FluentAssertions;
using Xunit;

namespace Luminous.Code.DateTests
{
    using static Dates.DateMethods;

    public class DaysAgo_Tests
    {
        [Fact]
        public void SameDate_ReturnsZero()
        {
            var currentDate = new DateTime(2019, 8, 21);
            var comparisonDate = new DateTime(2019, 8, 21);
            var expectedValue = 0;

            var result = DaysAgo(currentDate, comparisonDate);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void FutureDate_ThrowsArgumentOutOfRangeException()
        {
            var currentDate = new DateTime(2019, 8, 21);
            var comparisonDate = currentDate.AddDays(1);

            Action action = () => DaysAgo(currentDate, comparisonDate);

            action.Should()
                .Throw<ArgumentOutOfRangeException>();

            //https://fluentassertions.com/exceptions/
            //.WithMessage("DaysAgo: comparison date can't be in the future");
        }
    }

}