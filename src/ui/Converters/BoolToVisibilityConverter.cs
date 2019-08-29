using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace StartPagePlus.UI.Converters
{
    //http://putridparrot.com/blog/markupextension/
    //https://www.broculos.net/2014/04/wpf-how-to-use-converters-without.html

    //usage:
    //<Button Content="Cancel" Visibility="{Binding IsCancelVisible, Converter={c:BooleanToVisibilityConverter WhenFalse=Hidden Reverse=false}}">

    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : ConverterMarkupExtension
    {
        public BoolToVisibilityConverter() : this(Visibility.Collapsed)
        { }

        public BoolToVisibilityConverter(Visibility whenFalse)
            => WhenFalse = whenFalse;

        [ConstructorArgument("WhenFalse")]
        public Visibility WhenFalse { get; set; }

        public bool Reverse { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
            {
                return value;
            }

            var result = (bool)value;

            if (Reverse)
            {
                result = !result;
            }

            return result
                ? Visibility.Visible
                : WhenFalse;
        }
    }
}