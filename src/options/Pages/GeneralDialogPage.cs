using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.Options.Pages
{
    using static Constants.OptionsGuids;
    using static Constants.PageConstants;
    using static Core.StringConstants;

    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    [Guid(GeneralDialogPageString)]
    public class GeneralDialogPage : DialogPage
    {
        [Category(H1 + PackageName)]
        [DisplayName(Enable + Space + PackageName)]
        [Description("Allows the whole set of " + Quote + PackageName + Quote + " features to be turned off together")]
        public bool PackageNameEnabled { get; set; } = true;

        [Category(H1 + PackageName)]
        [DisplayName(Constants.PageConstants.PackageVersion)]
        [Description("Currently installed version of " + Quote + PackageName + Quote)]
        public string VersionNumber { get; } = Vsix.Version;
    }
}