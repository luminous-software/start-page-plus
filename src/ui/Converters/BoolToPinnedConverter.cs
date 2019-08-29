using System;
using System.Globalization;
using System.Windows.Data;

namespace StartPagePlus.UI.Converters
{
    //TODO: BoolToPinnedConverter is temporary

    // usage:
    // xmlns:c="clr-namespace:StartPagePlus.UI.Converters"

    //<Image Moniker="{Binding Pinned, Converter={c:BoolToPinConverter}">

    [ValueConversion(typeof(bool), typeof(string))]
    public class BoolToPinnedConverter : ConverterMarkupExtension
    {
        public bool Reversed { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
            {
                return "!";
            }

            var result = (bool)value;

            if (Reversed)
            {
                result = !result;
            }

            return result
                ? "Pinned"
                : "Not Pinned";
        }
    }
}