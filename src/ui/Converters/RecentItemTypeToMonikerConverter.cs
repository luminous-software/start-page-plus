using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.VisualStudio.Imaging.Interop;

// usage:
// xmlns:c="clr-namespace:StartPagePlus.UI.Converters"

//<Image Moniker="{Binding RecentItemType, Converter={c:RecentItemTypeToImageMonikerConverter}">

namespace StartPagePlus.UI.Converters
{
    using StartPagePlus.UI.Enums;

    [Obsolete]
    [ValueConversion(typeof(RecentItemType), typeof(ImageMoniker))]
    public class RecentItemTypeToImageMonikerConverter : ConverterMarkupExtension
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (value is RecentItemType itemType)
                ? itemType.ToImageMoniker()
                : value;
    };
}