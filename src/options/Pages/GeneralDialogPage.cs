using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.Options.Pages
{
    using static Constants.OptionsGuids;
    using static Constants.PageConstants;
    using static Core.Constants.StringConstants;

    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    [Guid(GeneralDialogPageString)]
    public class GeneralDialogPage : DialogPage
    {
        [Category(H1 + PackageName)]
        [DisplayName(Enable + Space + Quote + PackageName + Quote)]
        [Description("Allows the whole set of '" + PackageName + "' features to be turned off together")]
        public bool EnableStartPagePlus { get; set; } = true;

        [Category(H1 + PackageName)]
        [DisplayName(Constants.PageConstants.PackageVersion)]
        [Description("Installed '" + PackageName + "' version")]
        public string PackageVersion { get; } = Vsix.Version;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + Quote + Constants.PageConstants.OpenLinksInVS + Quote)]
        [Description("Determines if links are opened in VS or in the user's default browser")]
        public bool OpenLinksInVS { get; set; } = true;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + Quote + Constants.PageConstants.EnableStartPagePlusOptions + Quote)]
        [Description("Determines if a button to open" + Space + Quote + PackageName + Quote + Space + "options is added to the" + Space + Quote + "Tools" + Quote + Space + "Menu")]
        public bool EnableStartPagePlusOptions { get; set; } = true;
    }
}