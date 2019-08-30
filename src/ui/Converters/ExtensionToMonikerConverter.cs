using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.VisualStudio.Imaging.Interop;

// usage:
// xmlns:c="clr-namespace:StartPagePlus.UI.Converters"

//<Image Moniker="{Binding Extension, Converter={c:ExtensionToMonikerConverter}">

namespace StartPagePlus.UI.Converters
{
    using static StartPagePlus.UI.Strings.StringMethods;

    [ValueConversion(typeof(string), typeof(ImageMoniker))]
    public class ExtensionToMonikerConverter : ConverterMarkupExtension
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (value is string stringValue)
                ? ExtensionToMoniker(stringValue)
                : value;
    };
}