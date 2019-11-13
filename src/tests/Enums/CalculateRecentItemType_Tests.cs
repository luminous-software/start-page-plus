using FluentAssertions;
using Xunit;

namespace Luminous.Code.Tests.Enums
{
    using System;
    using StartPagePlus.UI.Enums;

    public class CalculateRecentItemType_Tests
    {
        [Fact]
        public void NullString_ThrowsArgumentException()
        {
            const string value = null;

            Action action = () => value.CalculateRecentItemType();

            action.Should().Throw<ArgumentException>("Recent item type can't be calculated from a null string");
        }

        [Fact]
        public void EmptyString_ThrowsArgumentException()
        {
            const string value = "";

            Action action = () => value.CalculateRecentItemType();

            action.Should().Throw<ArgumentException>("Recent item type can't be calculated from an empty string");
        }

        [Fact]
        public void NoExtension_ReturnsRecentItemType_Folder()
        {
            const string value = "C:\\SomeFolder";

            var result = value.CalculateRecentItemType();

            result.Should().Be(RecentItemType.Folder);
        }

        [Fact]
        public void DotSln_ReturnsRecentItemType_Solution()
        {
            const string value = ".sln";

            var result = value.CalculateRecentItemType();

            result.Should().Be(RecentItemType.Solution);
        }

        [Fact]
        public void DotCsProj_ReturnsRecentItemType_CsProject()
        {
            const string value = ".csproj";

            var result = value.CalculateRecentItemType();

            result.Should().Be(RecentItemType.CSharpProject);
        }

        [Fact]
        public void RandomExtension_ReturnsRecentItemType_Unknown()
        {
            const string value = ".abc";

            var result = value.CalculateRecentItemType();

            result.Should().Be(RecentItemType.Unknown);
        }
    }
}