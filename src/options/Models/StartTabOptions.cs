using System.ComponentModel;

using Luminous.Code.VisualStudio.Options.Pages;

namespace StartPagePlus.Options.Models
{
    using static Constants.PageConstants;
    using static Core.Constants.StringConstants;

    public class StartTabOptions : BaseOptionModel<StartTabOptions>
    {
        public const string Category = @"Start Tab\General";

        [Category(Settings)]
        [DisplayName(MaxWidthDisplayName)]
        [Description(MaxWidthDescription)]
        public int MaxWidth { get; set; } = 1175;

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