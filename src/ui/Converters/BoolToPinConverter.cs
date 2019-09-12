using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.Converters
{
    // usage:
    // xmlns:c="clr-namespace:StartPagePlus.UI.Converters"

    //<Image Moniker="{Binding Pinned, Converter={c:BoolToPinConverter Reverse=false}">

    [ValueConversion(typeof(bool), typeof(ImageMoniker))]
    public class BoolToPinMonikerConverter : ConverterMarkupExtension
    {
        public bool Reverse { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool boolValue))
                return value;

            if (Reverse)
            {
                boolValue = !boolValue;
            }

            return boolValue
                ? KnownMonikers.Pin
                : KnownMonikers.Unpin;
        }
    }
}