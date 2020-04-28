using System.ComponentModel;

using Luminous.Code.VisualStudio.Options.Pages;

namespace StartPagePlus.Options.Models
{
    using static Constants.PageConstants;
    using static Core.Constants.StringConstants;

    public class GeneralOptions : BaseOptionModel<GeneralOptions>
    {
        [Category(General)]
        [DisplayName(Enable + Space + Quote + PackageName + Quote)]
        [Description("Allows the whole set of '" + PackageName + "' features to be turned off together")]
        public bool EnableStartPagePlus { get; set; } = true;

        [Category(General)]
        [DisplayName(Constants.PageConstants.PackageVersion)]
        [Description("Installed '" + PackageName + "' version")]
        public string PackageVersion { get; } = Vsix.Version;
    }
}