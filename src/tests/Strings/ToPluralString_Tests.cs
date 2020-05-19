using FluentAssertions;

using Xunit;

namespace Luminous.Code.Tests.Strings
{
    using Luminous.Code.Extensions.Strings;

    public class ToPluralString_Tests
    {
        [Fact]
        public void EmptyString_ReturnsEmptyString()
        {
            var value = "";
            var count = 0;
            var expectedResult = "";

            var result = value.ToPlural(count);

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void TestWithZero_ReturnsTests()
        {
            var value = "test";
            var count = 0;
            var expectedResult = "tests";

            var result = value.ToPlural(count);

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void TestWithOne_ReturnsTest()
        {
            var value = "test";
            var count = 1;
            var expectedResult = "test";

            var result = value.ToPlural(count);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(2, "tests")]
        [InlineData(10, "tests")]
        [InlineData(100, "tests")]
        public void TestWithGreaterThanOne_ReturnsTests(int count, string expected)
        {
            var value = "test";

            var result = value.ToPlural(count);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(-1, "tests")]
        [InlineData(-10, "tests")]
        [InlineData(-100, "tests")]
        public void TestWithLessThanZero_ReturnsTests(int count, string expected)
        {
            var value = "test";

            var result = value.ToPlural(count);

            result.Should().Be(expected);
        }
    }
}