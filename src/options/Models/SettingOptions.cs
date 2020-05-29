using System.ComponentModel;

using Luminous.Code.VisualStudio.Options.Pages;

namespace StartPagePlus.Options.Models
{
    using static Constants.PageConstants;

    public class SettingOptions : BaseOptionModel<SettingOptions>
    {

        [Category(Settings)]
        [DisplayName(DeveloperNewsUrlDisplayName)]
        [Description(DeveloperNewsUrlDescription)]
        public string DeveloperNewsUrl { get; set; } = "";

        [Category(Settings)]
        [DisplayName(MaxWidthDisplayName)]
        [Description(MaxWidthDescription)]
        public int MaxWidth { get; set; } = 1175;

        [Category(Settings)]
        [DisplayName(NewsItemsToDisplayDisplayName)]
        [Description(NewsItemsToDisplayDescription)]
        public int NewsItemsToDisplay { get; set; } = 10;

        [Category(Settings)]
        [DisplayName(RecentItemsToDisplayDisplayName)]
        [Description(RecentItemsToDisplayDescription)]
        public int RecentItemsToDisplay { get; set; } = 50;

        [Category(Settings)]
        [DisplayName(ShowRecentItemExtensionsDisplayName)]
        [Description(ShowRecentItemExtensionsDescription)]
        public bool ShowRecentItemExtensions { get; set; } = false;

        [Category(Settings)]
        [DisplayName(ShowStartTabTitleDisplayName)]
        [Description(ShowStartTabTitleDescription)]
        public bool ShowStartTabTitle { get; set; } = true;

        [Category(Settings)]
        [DisplayName(StartTabTitleTextDisplayName)]
        [Description(StartTabTitleTextDescription)]
        public string StartTabTitleText { get; set; } = "What would you like to do today?";
    }
}