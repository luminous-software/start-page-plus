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

        [Guid(SettingsPageGuidString)]
        public class Settings : BaseOptionPage<SettingsOptions> { }
    }
}