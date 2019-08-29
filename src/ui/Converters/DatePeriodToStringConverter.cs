using System;
using System.Globalization;
using System.Windows.Data;
using static Luminous.Code.Dates.DateMethods;

// usage:
//xmlns:dat="clr-namespace:System.Windows.Data;assembly=PresentationFramework"
// xmlns:c="clr-namespace:StartPagePlus.UI.Converters"

//<dat:PropertyGroupDescription x:Name="GroupByDatePeriod" PropertyName="DatePeriod" Converter="{c:DatePeriodToStringConverter}"/>

namespace StartPagePlus.UI.Converters
{
    [ValueConversion(typeof(DatePeriods), typeof(string))]
    public class DatePeriodToStringConverter : ConverterMarkupExtension
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DatePeriods))
            {
                return value;
            }

            return null;
        }
    };
}