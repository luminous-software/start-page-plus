using System.ComponentModel;

using Luminous.Code.VisualStudio.Options.Pages;

namespace StartPagePlus.Options.Models
{
    using static Constants.PageConstants;

    public class RecentItemsOptions : BaseOptionModel<RecentItemsOptions>
    {
        public const string Category = @"Start Tab\Recent Items";

        [Category(Settings)]
        [DisplayName(RecentItemsToDisplayDisplayName)]
        [Description(RecentItemsToDisplayDescription)]
        public int RecentItemsToDisplay { get; set; } = 50;

        [Category(Settings)]
        [DisplayName(ShowRecentItemExtensionsDisplayName)]
        [Description(ShowRecentItemExtensionsDescription)]
        public bool ShowRecentItemExtensions { get; set; } = false;
    }
}