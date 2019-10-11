using System;
using System.Globalization;

namespace Luminous.Code.Dates
{
    public static class DateMethods
    {
        public static string DateToString(DateTime dateValue, string format, CultureInfo culture = null)
            => dateValue.ToString(format, culture ?? CultureInfo.CurrentCulture);
    }
}