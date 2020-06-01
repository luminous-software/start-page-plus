using System.ComponentModel;

using Luminous.Code.VisualStudio.Options.Pages;

namespace StartPagePlus.Options.Models
{
    using static Constants.PageConstants;
    using static Core.Constants.StringConstants;

    public class RecentItemsOptions : BaseOptionModel<RecentItemsOptions>
    {
        public const string Category = @"Start Tab\Recent Items";

        [Category(Settings)]
        [DisplayName(RecentItemsToDisplayDisplayName)]
        [Description(RecentItemsToDisplayDescription)]
        public int ItemsToDisplay { get; set; } = 50;

        [Category(Settings)]
        [DisplayName(ShowFileExtensionsDisplayName)]
        [Description(ShowFileExtensionsDescription)]
        public bool ShowFileExtensions { get; set; } = false;
    }
}