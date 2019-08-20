using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.Converters
{
    [ValueConversion(typeof(string), typeof(ImageMoniker))]
    public class ExtensionToMonikerConverter : ConverterMarkupExtension
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ext = value.ToString().Trim(new char[] { '.' });

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