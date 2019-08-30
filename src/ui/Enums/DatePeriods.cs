using System.ComponentModel;

namespace StartPagePlus.UI.Enums
{
    using Converters;

    [TypeConverter(typeof(EnumToStringConverter<DatePeriods>))]
    public enum DatePeriods
    {

        Pinned = 0,
        Today = 1,
        Yesterday = 2,
        ThisWeek = 3,
        ThisMonth = 4,
        Older = 5
    }

}