using System.ComponentModel;

using Luminous.Code.VisualStudio.Options.Pages;

namespace StartPagePlus.Options.Models
{
    using static Constants.PageConstants;
    using static Core.Constants.StringConstants;

    public class GeneralOptions : BaseOptionModel<GeneralOptions>
    {
        [Category(General)]
        [DisplayName(EnableStartPagePlusDispayName)]
        [Description(EnableStartPagePlusDescription)]
        public bool EnableStartPagePlus { get; set; } = true;

        [Category(General)]
        [DisplayName(EnableOptionsMenuItemDispayName)]
        [Description(EnableOptionsMenuItemDescription)]
        public bool EnableStartPagePlusOptions { get; set; } = true;

        [Category(General)]
        [DisplayName(Constants.PageConstants.PackageVersion)]
        [Description("Installed '" + PackageName + "' version")]
        public string PackageVersion { get; } = Vsix.Version;
    }
}