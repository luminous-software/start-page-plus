using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.Converters
{
    //TODO: BoolToMonikerConverter doesn't work

    // usage:
    // xmlns:c="clr-namespace:StartPagePlus.UI.Converters"

    //<Image Moniker="{Binding Pinned, Converter={c:BoolToMonikerConverter WhenTrue=KnownMonikers.Pin WhenFalse=KnowMonikers.Unpin}">

    [ValueConversion(typeof(bool), typeof(ImageMoniker))]
    public class BoolToMonikerConverter : ConverterMarkupExtension
    {
        private string trueMonikerName;

        public BoolToMonikerConverter(ImageMoniker whenTrue, ImageMoniker whenFalse, bool reverse = false)
        {
            WhenTrue = whenTrue;
            WhenFalse = whenFalse;
            Reversed = reverse;
        }

        public object WhenTrue
        {
            get => KnownMonikers.Pin;

            set => trueMonikerName = value.ToString();
        }

        [ConstructorArgument("WhenFalse")]
        public object WhenFalse { get; set; }

        [ConstructorArgument("Reverse")]
        public bool Reversed { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
            {
                return value;
            }

            var result = (bool)value;

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