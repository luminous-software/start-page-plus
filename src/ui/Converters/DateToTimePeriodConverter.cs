using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class DateToTimePeriodConverter : ConverterMarkupExtension
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
            {
                return "Unknown";
            }

            var ext = value.ToString();

            switch (ext)
            {
                case "sln":
                    return KnownMonikers.Solution;

                case "csproj":
                    return KnownMonikers.CSProjectNode;

                case "":
                    return KnownMonikers.FolderOpened;

                default:
                    return KnownMonikers.ExclamationPoint;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    };
}