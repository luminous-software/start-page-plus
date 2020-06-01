using System;
using System.Globalization;
using System.Windows.Data;

using Luminous.Code.Extensions.Strings;

// usage:
// xmlns:dat="clr-namespace:System.Windows.Data;assembly=PresentationFramework"
// xmlns:c="clr-namespace:StartPagePlus.UI.Converters"

//Text="{Binding ItemCount, Converter={c:IntToPluralStringConverter, Text=item}}"/>

namespace StartPagePlus.UI.Converters
{
    using MarkupExtensions;

    [ValueConversion(typeof(int), typeof(string))]
    public class IntToPluralStringConverter : ValueConverterMarkupExtension
    {
        public string Text { get; set; } = "item";

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (value is int count)
                ? $"({count} {Text.ToPlural(count)})"
                : value;
    };
}