using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.Converters
{
    // usage:
    // xmlns:c="clr-namespace:StartPagePlus.UI.Converters"

    //<Image Moniker="{Binding Pinned, Converter={c:BoolToMonikerConverter WhenTrue=KnownMonikers.Pin WhenFalse=KnowMonikers.Unpin}">

    [ValueConversion(typeof(bool), typeof(ImageMoniker))]
    public class BoolToMonikerConverter : ConverterMarkupExtension
    {
        public BoolToMonikerConverter() { }

        private string trueMonikerName;
        public object WhenTrue
        {
            get => KnownMonikers.Pin;

            set => trueMonikerName = value.ToString();
        }

        public object WhenFalse { get; set; }

        public bool Reversed { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = (value is bool?)
                ? ((bool?)value).GetValueOrDefault(false)
                : false;

            if (value is bool)
            {
                result = (bool)value;
            }

            if (Reversed)
            {
                result = !result;
            }

            //return result
            //    ? WhenTrue
            //    : WhenFalse;
            return null;
        }
    }
}