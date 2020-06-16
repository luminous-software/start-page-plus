using System;
using System.Runtime.InteropServices;

using Luminous.Code.VisualStudio.Packages;

using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.ToolWindows
{
    using Views;

    using static Constants.GuidConstants;

    [Guid(StartPagePlusToolWindowGuidString)]
    public class StartPagePlusToolWindow : ToolWindowPane
    {
        public StartPagePlusToolWindow(AsyncPackageBase package) : base(null)
        {
            Caption = Vsix.Name;
            BitmapImageMoniker = KnownMonikers.Home;
            Content = new MainView(package);
        }
    }
}