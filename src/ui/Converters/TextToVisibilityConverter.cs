using System;
using System.Windows;
using System.Globalization;

namespace StartPagePlus.UI.Converters
{
    using MarkupExtensions;

    public class TextInputToVisibilityConverter : MultiValueConverterMarkupExtension
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is bool v1 && values[1] is bool v2)
            {
                bool hasText = !(bool)v1;
                bool hasFocus = (bool)v2;

                if (hasFocus || hasText)
                    return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }
    }
}