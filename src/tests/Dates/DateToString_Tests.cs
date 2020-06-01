using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

namespace Luminous.Code.Tests.Dates
{
    using static Luminous.Code.Dates.DateMethods;

    public class DateToString_Tests
    {
        [Fact]
        public void Format_d_en_AU_ReturnsAustralianShortDate()
        {
            var date = new DateTime(2019, 10, 11);
            var format = "d";
            var culture = new CultureInfo("en-AU");
            var expectedValue = "11/10/2019";

            var result = DateToString(date, format, culture);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void Format_D_en_AU_ReturnsAustralianLongDate()
        {
            var date = new DateTime(2019, 10, 11);
            var format = "D";
            var culture = new CultureInfo("en-AU");
            var expectedValue = "Friday, 11 October 2019";

            var result = DateToString(date, format, culture);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void Format_d_en_US_ReturnsAmericanShortDate()
        {
            var date = new DateTime(2019, 10, 11);
            var format = "d";
            var culture = new CultureInfo("en-US");
            var expectedValue = "10/11/2019";

            var result = DateToString(date, format, culture);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void Format_D_en_US_ReturnsAmericanLongDate()
        {
            var date = new DateTime(2019, 10, 11);
            var format = "D";
            var culture = new CultureInfo("en-US");
            var expectedValue = "Friday, October 11, 2019";

            var result = DateToString(date, format, culture);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void Format_d_fr_FR_ReturnsFrenchShortDate()
        {
            var date = new DateTime(2019, 10, 11);
            var format = "d";
            var culture = new CultureInfo("fr-FR");
            var expectedValue = "11/10/2019";

            var result = DateToString(date, format, culture);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void Format_D_fr_FR_ReturnsFrenchLongDate()
        {
            var date = new DateTime(2019, 10, 11);
            var format = "D";
            var culture = new CultureInfo("fr-FR");
            var expectedValue = "vendredi 11 octobre 2019";

            var result = DateToString(date, format, culture);

            result.Should().Be(expectedValue);
        }
    }
}