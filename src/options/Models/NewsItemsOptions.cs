using System.ComponentModel;

using Luminous.Code.VisualStudio.Options.Pages;

namespace StartPagePlus.Options.Models
{
    using static Constants.PageConstants;

    public class NewsItemsOptions : BaseOptionModel<NewsItemsOptions>
    {
        public const string Category = @"Start Tab\News Items";

        [Category(Settings)]
        [DisplayName(DeveloperNewsUrlDisplayName)]
        [Description(DeveloperNewsUrlDescription)]
        public string DeveloperNewsUrl { get; set; } = "https://vsstartpage.blob.core.windows.net/news/vs";

        [Category(Settings)]
        [DisplayName(NewsItemsToDisplayDisplayName)]
        [Description(NewsItemsToDisplayDescription)]
        public int NewsItemsToDisplay { get; set; } = 10;
    }
}