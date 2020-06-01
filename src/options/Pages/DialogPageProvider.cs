using System;
using System.Runtime.InteropServices;

using Luminous.Code.VisualStudio.Options.Pages;

namespace StartPagePlus.Options.Pages
{
    using Models;

    using static StartPagePlus.Options.Constants.OptionsGuids;

    // A provider for custom DialogPage implementations
    public class DialogPageProvider
    {
        [Guid(GeneralPageGuidString)]
        public class General : BaseOptionPage<GeneralOptions> { }

        [Guid(StartTabPageGuidString)]
        public class StartTab : BaseOptionPage<StartTabOptions> { }

        [Guid(RecentItemsPageGuidString)]
        public class RecentItems : BaseOptionPage<RecentItemsOptions> { }

        [Guid(NewsItemsPageGuidString)]
        public class NewsItems : BaseOptionPage<NewsItemsOptions> { }
    }
}