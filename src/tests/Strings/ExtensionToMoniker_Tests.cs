using System;
using FluentAssertions;
using Microsoft.VisualStudio.Imaging;
using Xunit;

namespace StartPagePlus.UI.Tests.Strings
{
    using static StartPagePlus.UI.Strings.StringMethods;

    public class ExtensionToMoniker_Tests
    {
        [Fact]
        public void Null_Throws_ArgumentOutOfRangeException()
        {
            const string ext = null;
            var expectedValue = KnownMonikers.ExclamationPoint;

            Action action = () => ExtensionToMoniker(ext);

            action.Should()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Unknown_Returns_ExclamationPoint()
        {
            const string ext = "abc";
            var expectedValue = KnownMonikers.ExclamationPoint;

            var result = ExtensionToMoniker(ext);

            result.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(".sln")]
        [InlineData("sln")]
        public void Sln_Returns_Solution(string ext)
        {
            var expectedValue = KnownMonikers.Solution;

            var result = ExtensionToMoniker(ext);

            result.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(".csproj")]
        [InlineData("csproj")]
        public void CsProj_Returns_CSProjectNode(string ext)
        {
            var expectedValue = KnownMonikers.CSProjectNode;

            var result = ExtensionToMoniker(ext);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void EmptyString_Returns_FolderOpen()
        {
            const string ext = "";
            var expectedValue = KnownMonikers.FolderOpened;

            var result = ExtensionToMoniker(ext);

            result.Should().Be(expectedValue);
        }
    }
}