using System;
using FluentAssertions;
using Xunit;

namespace Luminous.Code.Tests.Dates
{
    using Luminous.Code.Extensions.DateExtensions;

    public class StartOfWeek_Tests
    {
        [Theory]
        [InlineData("2019-08-11", "2019-08-05")] //Sunday
        [InlineData("2019-08-10", "2019-08-05")] //Saturday
        [InlineData("2019-08-09", "2019-08-05")] //Friday
        [InlineData("2019-08-08", "2019-08-05")] //Thursday
        [InlineData("2019-08-07", "2019-08-05")] //Wednesday
        [InlineData("2019-08-06", "2019-08-05")] //Tuesday
        [InlineData("2019-08-05", "2019-08-05")] //Monday
        public void AllDays_ReturnMonday(DateTime date, DateTime expectedDate)
        {
            var result = date.StartOfWeek();

            result.Should().Be(expectedDate);
        }
    }
}