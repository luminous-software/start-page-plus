using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StartPagePlus.UI.Converters
{
    using MarkupExtensions;

    //http://putridparrot.com/blog/markupextension/
    //https://www.broculos.net/2014/04/wpf-how-to-use-converters-without.html

    //usage:
    //<Button Content="Cancel" Visibility="{Binding IsCancelVisible, Converter={c:BooleanToVisibilityConverter WhenFalse=Hidden Reverse=false}}">

    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : ValueConverterMarkupExtension
    {
        public Visibility WhenFalse { get; set; } = Visibility.Collapsed;

        public bool Reverse { get; set; } = false;

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //=> (value is bool boolValue)
        //    ? Reverse
        //        ? !boolValue
        //        : boolValue
        //    : value;
        {
            if (!(value is bool boolValue))
                return value;

            if (Reverse)
            {
                boolValue = !boolValue;
            }

            return boolValue
                ? Visibility.Visible
                : WhenFalse;
        }
    }
}