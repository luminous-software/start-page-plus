using FluentAssertions;
using Microsoft.VisualStudio.Imaging;
using Xunit;

namespace StartPagePlus.UI.Tests.Enums
{
    using StartPagePlus.UI.Enums;

    public class RecentItemTypeToImageMoniker_Tests
    {
        [Fact]
        public void RecentItemTypeUnknown_Returns_QuestionMark()
        {
            var result = RecentItemType.Unknown.ToImageMoniker();

            result.Should().Be(KnownMonikers.QuestionMark);
        }

        [Fact]
        public void RecentItemTypeFolder_Returns_FolderOpened()
        {
            var result = RecentItemType.Folder.ToImageMoniker();

            result.Should().Be(KnownMonikers.FolderOpened);
        }

        [Fact]
        public void RecentItemTypeSolution_Returns_Solution()
        {
            var result = RecentItemType.Solution.ToImageMoniker();

            result.Should().Be(KnownMonikers.Solution);
        }

        [Fact]
        public void RecentItemTypeCsProject_Returns_CSProjectNode()
        {
            var result = RecentItemType.CsProject.ToImageMoniker();

            result.Should().Be(KnownMonikers.CSProjectNode);
        }
    }
}