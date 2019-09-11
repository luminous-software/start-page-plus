using System;
using System.Globalization;
using System.Windows.Data;

// usage:
// xmlns:dat="clr-namespace:System.Windows.Data;assembly=PresentationFramework"
// xmlns:c="clr-namespace:StartPagePlus.UI.Converters"

//<dat:PropertyGroupDescription x:Name="GroupByPeriodType" PropertyName="PeriodType" Converter="{c:PeriodTypeToStringConverter}"/>

namespace StartPagePlus.UI.Converters
{
    using static StartPagePlus.UI.Enums.PeriodTypes;


    [ValueConversion(typeof(int), typeof(string))]
    public class PeriodTypeIdToPeriodTypeStringConverter : ConverterMarkupExtension
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (value is int id)
                ? IdToString(id)
                : value;
    };
}