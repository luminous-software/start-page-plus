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

        public class RecentItems : BaseOptionPage<RecentItemsOptions> { }

        public class NewsItems : BaseOptionPage<NewsItemsOptions> { }


        [Guid(SettingPageGuidString)]
        public class Settings : BaseOptionPage<SettingOptions> { }

        [Guid(FeaturePageGuidString)]
        public class Features : BaseOptionPage<FeatureOptions> { }
    }
}