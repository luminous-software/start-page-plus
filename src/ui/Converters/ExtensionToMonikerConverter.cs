using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;

// usage:
// xmlns:c="clr-namespace:StartPagePlus.UI.Converters"

//<Image Moniker="{Binding Extension, Converter={c:ExtensionToMonikerConverter}">

namespace StartPagePlus.UI.Converters
{
    [ValueConversion(typeof(string), typeof(ImageMoniker))]
    public class ExtensionToMonikerConverter : ConverterMarkupExtension
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
            {
                return value;
            }

            var ext = value.ToString().TrimStart(new char[] { '.' });

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
    };
}