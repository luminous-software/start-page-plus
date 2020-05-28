using FluentAssertions;

using Xunit;

namespace Luminous.Code.Tests.Strings
{
    using Extensions.Strings;

    public class ToQuotedPath_Tests
    {
        [Fact]
        public void EmptyString_ReturnsEmptyString()
        {
            var value = "";
            var expectedResult = "";

            var result = value.ToQuotedString();

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void NullString_ReturnsEmptyString()
        {
            string value = null;
            var expectedResult = "";

            var result = value.ToQuotedString();

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void StringWithNoSpaces_ReturnsSameString()
        {
            string value = "test";
            var expectedResult = "test";

            var result = value.ToQuotedString();

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void StringWithSpaces_ReturnsQuotedString()
        {
            string value = "test with spaces";
            var expectedResult = (char)34 + "test with spaces" + (char)34;

            var result = value.ToQuotedString();

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void FilenameWithNoSpaces_ReturnsFilename()
        {
            string value = "C:\\test";
            var expectedResult = "C:\\test";

            var result = value.ToQuotedString();

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void FilenameWithSpaces_ReturnsQuotedFilename()
        {
            string value = @"C:\test with spaces";
            var expectedResult = @"""C:\test with spaces""";

            var result = value.ToQuotedString();

            result.Should().Be(expectedResult);
        }
    }
}