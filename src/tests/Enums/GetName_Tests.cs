using System.ComponentModel;
using FluentAssertions;
using Xunit;

namespace Luminous.Code.Tests.Enums
{
    using StartPagePlus.Core.Extensions.Enums;

    public class GetName_Tests
    {
        private enum TestEnum
        {
            NoDescription,

            [Description("Has Description")]
            HasDescription
        }

        [Fact]
        public void NoDescription_ReturnsEnumText()
        {
            var enumValue = TestEnum.NoDescription;
            var expectedResult = "NoDescription";

            var result = enumValue.GetName();

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void HasDescription_ReturnsDescription()
        {
            var enumValue = TestEnum.HasDescription;
            var expectedResult = "Has Description";

            var result = enumValue.GetName();

            result.Should().Be(expectedResult);
        }
    }
}