using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace StartPagePlus.UI.Converters
{
    public abstract class ConverterMarkupExtension<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        private static T converter = null;

        public ConverterMarkupExtension()
        { }

        public override object ProvideValue(IServiceProvider serviceProvider)
            => converter ?? (converter = new T());

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
