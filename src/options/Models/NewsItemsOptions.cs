using System.ComponentModel;

using Luminous.Code.VisualStudio.Options.Pages;

namespace StartPagePlus.Options.Models
{
    using static Constants.PageConstants;
    using static Core.Constants.StringConstants;

    public class NewsItemsOptions : BaseOptionModel<NewsItemsOptions>
    {
        public const string Category = @"Start Tab\Developer News";

        [Category(Settings)]
        [DisplayName(ClearListBeforeRefreshDisplayName)]
        [Description(ClearListBeforeRefreshDescription)]
        public bool ClearListBeforeRefresh { get; set; } = true;

        [Category(Settings)]
        [DisplayName(NewsItemsFeedUrlDisplayName)]
        [Description(NewsItemsFeedUrlDescription)]
        public string NewsItemsFeedUrl { get; set; } = "https://vsstartpage.blob.core.windows.net/news/vs";

        [Category(Settings)]
        [DisplayName(NewsItemsToDisplayDisplayName)]
        [Description(NewsItemsToDisplayDescription)]
        public int NewsItemsToDisplay { get; set; } = 10;

        [Category(Settings)]
        [DisplayName(OpenLinksInVsDisplayName)]
        [Description(OpenLinksInVsDescription)]
        public bool OpenLinksInVS { get; set; } = true;
    }
}