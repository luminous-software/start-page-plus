using System;
using System.Runtime.InteropServices;

using Luminous.Code.VisualStudio.Packages;

using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI
{
    using Views;

    using static Constants.GuidConstants;

    [Guid(StartPagePlusPaneGuidString)]
    public class StartPagePlusWindow : ToolWindowPane
    {
        public StartPagePlusWindow(AsyncPackageBase package) : base(null)
        {
            Caption = Vsix.Name;
            BitmapImageMoniker = KnownMonikers.Home;
            Content = new MainView(package);
        }
    }
}