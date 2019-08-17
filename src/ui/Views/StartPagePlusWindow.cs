using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.Views
{
    using static UI.Constants.GuidConstants;

    [Guid(StartPagePlusPaneGuidString)]
    public class StartPagePlusWindow : ToolWindowPane
    {
        public StartPagePlusWindow() : base(null)
        {
            Caption = Vsix.Name;
            BitmapImageMoniker = KnownMonikers.Home;
            Content = new MainView();
        }
    }
}