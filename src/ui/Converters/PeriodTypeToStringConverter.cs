using System;
using System.Globalization;
using System.Windows.Data;

// usage:
// xmlns:dat="clr-namespace:System.Windows.Data;assembly=PresentationFramework"
// xmlns:c="clr-namespace:StartPagePlus.UI.Converters"

//<dat:PropertyGroupDescription x:Name="GroupByPeriodType" PropertyName="PeriodType" Converter="{c:PeriodTypeToStringConverter}"/>

namespace StartPagePlus.UI.Converters
{
    using Enums;
    using MarkupExtensions;


    [ValueConversion(typeof(PeriodType), typeof(string))]
    public class PeriodTypeToNameConverter : ValueConverterMarkupExtension
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (value is PeriodType periodType)
                ? periodType.ToName()
                : value;
    };
}