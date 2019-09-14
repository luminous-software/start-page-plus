using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace StartPagePlus.UI.Converters
{
    //http://drwpf.com/blog/2009/03/17/tips-and-tricks-making-value-converters-more-accessible-in-markup/

    public class DummyConverter : MarkupExtension, IValueConverter
    {
        private static DummyConverter converter = null;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (converter == null)
            {
                converter = new DummyConverter();
            }
            return converter ?? (converter = new DummyConverter());
        }

        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
            => value; // set breakpoint here to debug your binding

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
            => value;
    }
}
