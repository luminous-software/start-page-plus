using System.ComponentModel;

using Luminous.Code.VisualStudio.Options.Pages;

namespace StartPagePlus.Options.Models
{
    using static Constants.PageConstants;
    using static Core.Constants.StringConstants;

    public class FeatureOptions : BaseOptionModel<FeatureOptions>
    {
        [Category(Features)]
        [DisplayName(Enable + Space + Quote + Constants.PageConstants.OpenLinksInVS + Quote)]
        [Description("Determines if links are opened in VS or in the user's default browser")]
        public bool OpenLinksInVS { get; set; } = true;

        [Category(Features)]
        [DisplayName(Enable + Space + Quote + Constants.PageConstants.EnableStartPagePlusOptions + Quote)]
        [Description("Determines if a button to open" + Space + Quote + PackageName + Quote + Space + "options is added to the" + Space + Quote + "Tools" + Quote + Space + "Menu")]
        public bool EnableStartPagePlusOptions { get; set; } = true;
    }
}