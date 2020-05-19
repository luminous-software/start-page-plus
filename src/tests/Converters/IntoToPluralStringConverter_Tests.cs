using FluentAssertions;

using Xunit;

namespace StartPagePlus.UI.Tests.Converters
{
    using System.Globalization;

    using StartPagePlus.UI.Converters;

    public class IntToPluralStringConverter_Tests
    {
        [Fact]
        public void UnspecifiedTextWithZero_ReturnsZeroItems()
        {
            var count = 0;
            var expected = "(0 items)";
            var converter = new IntToPluralStringConverter();

            var result = (string)converter.Convert(count, typeof(string), null, CultureInfo.InvariantCulture);

            result.Should().Be(expected);
        }

        [Fact]
        public void UnspecifiedTextWithOne_ReturnsOneItem()
        {
            var count = 1;
            var expected = "(1 item)";
            var converter = new IntToPluralStringConverter();

            var result = (string)converter.Convert(count, typeof(string), null, CultureInfo.InvariantCulture);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(2, "(2 items)")]
        [InlineData(10, "(10 items)")]
        [InlineData(100, "(100 items)")]
        public void UnspecifiedTextWithGreaterThanOne_ReturnsCountItems(int count, string expected)
        {
            var converter = new IntToPluralStringConverter();

            var result = (string)converter.Convert(count, typeof(string), null, CultureInfo.InvariantCulture);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(-1, "(-1 items)")]
        [InlineData(-10, "(-10 items)")]
        [InlineData(-100, "(-100 items)")]
        public void UnspecifiedTextWithLessThanOne_ReturnsMinusCountItems(int count, string expected)
        {
            var converter = new IntToPluralStringConverter();

            var result = (string)converter.Convert(count, typeof(string), null, CultureInfo.InvariantCulture);

            result.Should().Be(expected);
        }

        [Fact]
        public void TestWithZero_ReturnsZeroTests()
        {
            var count = 0;
            var expected = "(0 tests)";
            var converter = new IntToPluralStringConverter
            {
                Text = "test"
            };

            var result = (string)converter.Convert(count, typeof(string), null, CultureInfo.InvariantCulture);

            result.Should().Be(expected);
        }

        [Fact]
        public void TestWithOne_ReturnsOneTest()
        {
            var count = 1;
            var expected = "(1 test)";
            var converter = new IntToPluralStringConverter()
            {
                Text = "test"
            };

            var result = (string)converter.Convert(count, typeof(string), null, CultureInfo.InvariantCulture);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(2, "(2 tests)")]
        [InlineData(10, "(10 tests)")]
        [InlineData(100, "(100 tests)")]
        public void TestWithGreaterThanOne_ReturnsCountTests(int count, string expected)
        {
            var converter = new IntToPluralStringConverter()
            {
                Text = "test"
            };

            var result = (string)converter.Convert(count, typeof(string), null, CultureInfo.InvariantCulture);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(-1, "(-1 tests)")]
        [InlineData(-10, "(-10 tests)")]
        [InlineData(-100, "(-100 tests)")]
        public void TestWithLessThanOne_ReturnsMinusCountTests(int count, string expected)
        {
            var converter = new IntToPluralStringConverter()
            {
                Text = "test"
            };

            var result = (string)converter.Convert(count, typeof(string), null, CultureInfo.InvariantCulture);

            result.Should().Be(expected);
        }
    }
}