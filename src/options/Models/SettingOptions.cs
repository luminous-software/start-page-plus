using System.ComponentModel;

using Luminous.Code.VisualStudio.Options.Pages;

namespace StartPagePlus.Options.Models
{
    using static Constants.PageConstants;

    public class SettingOptions : BaseOptionModel<SettingOptions>
    {
        [Category(Settings)]
        [DisplayName(Constants.PageConstants.MaxWidth)]
        [Description("Sets the max width of the window's contents")]
        public int MaxWidth { get; set; } = 1175;

        [Category(Settings)]
        [DisplayName(Constants.PageConstants.NewsItemsToDisplay)]
        [Description("Sets the number of items to display in the 'Developer News' list")]
        public int NewsItemsToDisplay { get; set; } = 10;

        [Category(Settings)]
        [DisplayName(Constants.PageConstants.RecentItemsToDisplay)]
        [Description("Sets the number of items to display in the 'Recent Items' list")]
        public int RecentItemsToDisplay { get; set; } = 50;

        [Category(Settings)]
        [DisplayName(Constants.PageConstants.ShowRecentItemExtensions)]
        [Description("Hide a project/solution's extension in the 'Recent Items' list")]
        public bool ShowRecentItemExtensions { get; set; } = true;

        [Category(Settings)]
        [DisplayName(Constants.PageConstants.ShowStartTabTitle)]
        [Description("Allow the title displayed in the Start Tab title to be shown or hidden")]
        public bool ShowStartTabTitle { get; set; } = true;
    }
}