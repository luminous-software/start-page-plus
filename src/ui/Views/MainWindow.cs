using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.Views
{
    using static UI.Constants.GuidConstants;

    [Guid(StartPagePlusPaneGuidString)]
    public class MainWindow : ToolWindowPane
    {
        public MainWindow() : base(null)
        {
            Caption = Vsix.Name;
            BitmapImageMoniker = KnownMonikers.Home;
            Content = new MainControl();
        }
    }
}