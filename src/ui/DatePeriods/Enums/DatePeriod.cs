using System.ComponentModel;

namespace StartPagePlus.UI.DatePeriods.Enums
{
    //https://stackoverflow.com/questions/424366/string-representation-of-an-enum/8353191#8353191

    public enum DatePeriod
    {

        Pinned = 0,
        Today = 1,
        Yesterday = 2,
        [Description("This Week")]
        ThisWeek = 3,
        [Description("This Month")]
        ThisMonth = 4,
        Older = 5
    }

}