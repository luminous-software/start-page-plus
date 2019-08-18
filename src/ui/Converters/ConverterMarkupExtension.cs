using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace StartPagePlus.UI.Converters
{
    //https://www.broculos.net/2014/04/wpf-how-to-use-converters-without.html

    public abstract class ConverterMarkupExtension : MarkupExtension, IValueConverter
    {
        public ConverterMarkupExtension()
        { }

        public override object ProvideValue(IServiceProvider serviceProvider)
            => this;

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
