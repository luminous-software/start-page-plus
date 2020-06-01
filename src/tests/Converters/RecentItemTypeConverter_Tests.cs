using System.Globalization;
using FluentAssertions;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;
using Xunit;

namespace StartPagePlus.UI.Tests.Converters
{
    using StartPagePlus.UI.Converters;
    using StartPagePlus.UI.Enums;

    public class RecentItemTypeConverter_Tests
    {
        [Fact]
        public void RecentItemTypeFolder_Returns_KnownMonikersFolderOpened()
        {
            var converter = new RecentItemTypeToImageMonikerConverter();

            var result = (ImageMoniker)converter.Convert(RecentItemType.Folder, typeof(ImageMoniker), null, CultureInfo.InvariantCulture);

            result.Should().Be(KnownMonikers.FolderOpened);
        }

        [Fact]
        public void RecentItemTypeSolution_Returns_Solution()
        {
            var converter = new RecentItemTypeToImageMonikerConverter();

            var result = (ImageMoniker)converter.Convert(RecentItemType.Solution, typeof(ImageMoniker), null, CultureInfo.InvariantCulture);

            result.Should().Be(KnownMonikers.Solution);
        }

        [Fact]
        public void RecentItemTypeCsProject_Returns_CSProjectNode()
        {
            var converter = new RecentItemTypeToImageMonikerConverter();

            var result = (ImageMoniker)converter.Convert(RecentItemType.CSharpProject, typeof(ImageMoniker), null, CultureInfo.InvariantCulture);

            result.Should().Be(KnownMonikers.CSProjectNode);
        }

        [Fact]
        public void RecentItemTypeUnknown_Returns_QuestionMark()
        {
            var converter = new RecentItemTypeToImageMonikerConverter();

            var result = (ImageMoniker)converter.Convert(RecentItemType.Unknown, typeof(ImageMoniker), null, CultureInfo.InvariantCulture);

            result.Should().Be(KnownMonikers.QuestionMark);
        }
    }
}