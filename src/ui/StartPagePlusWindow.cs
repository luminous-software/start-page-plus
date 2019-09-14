using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Shell;
using Microsoft.Win32;

namespace StartPagePlus.UI
{
    using Views;
    using static Constants.GuidConstants;

    [Guid(StartPagePlusPaneGuidString)]
    public class StartPagePlusWindow : ToolWindowPane
    {
        public StartPagePlusWindow(RegistryKey registryRoot) : base(null)
        {
            Caption = Vsix.Name;
            BitmapImageMoniker = KnownMonikers.Home;
            Content = new MainView(registryRoot);
        }
    }
}