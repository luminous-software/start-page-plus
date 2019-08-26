using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.Converters
{
    // usage:
    // xmlns:c="clr-namespace:StartPagePlus.UI.Converters"

    //<Image Moniker="{Binding Pinned, Converter={c:BoolToPinConverter}">

    [ValueConversion(typeof(bool), typeof(ImageMoniker))]
    public class BoolToPinConverter : ConverterMarkupExtension
    {
        public bool Reversed { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
            {
                return KnownMonikers.ExclamationPoint;
            }

            var result = (bool)value;

            if (Reversed)
            {
                result = !result;
            }

            return result
                ? KnownMonikers.Pin
                : KnownMonikers.Unpin;
        }
    }
}