using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace StartPagePlus.UI.MarkupExtensions
{
    // http://putridparrot.com/blog/markupextension/
    // https://www.broculos.net/2014/04/wpf-how-to-use-converters-without.html

    public abstract class MultiValueConverterMarkupExtension : MarkupExtension, IMultiValueConverter
    {
        public MultiValueConverterMarkupExtension()
        { }

        public override object ProvideValue(IServiceProvider serviceProvider)
            => this;

        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

        public virtual object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}