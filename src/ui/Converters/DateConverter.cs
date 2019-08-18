using System;
using System.Globalization;
using System.Windows.Data;

namespace StartPagePlus.UI.Converters
{
    //https://www.broculos.net/2014/04/wpf-how-to-use-converters-without.html

    [ValueConversion(typeof(DateTime), typeof(String))]
    public class DateConverter : ConverterMarkupExtension<DateConverter>
    {
        public DateConverter()
        { }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => ((DateTime)value).ToShortDateString();

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var strValue = value.ToString();


            return DateTime.TryParse(strValue, out var resultDateTime)
                ? resultDateTime
                : value;
        }
    }
}