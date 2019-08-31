using System.Diagnostics;
using System.Windows;
using Luminous.Code.VisualStudio.Packages;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace StartPagePlus.UI.Services
{
    using StartPagePlus.Core.Interfaces;

    public class NewsItemActionService : INewsItemActionService
    {
        private const uint navigation = (uint)__VSWBNAVIGATEFLAGS.VSNWB_ForceNew;
        private IVsWebBrowsingService browsingService;
        private ProcessStartInfo startInfo;

        public NewsItemActionService()
        { }

        private IVsWebBrowsingService BrowsingService
            => browsingService ?? (browsingService = AsyncPackageBase.GetGlobalService<SVsWebBrowsingService, IVsWebBrowsingService>());

        private ProcessStartInfo StartInfo
            => startInfo ?? (startInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                Verb = "Open"
            });

        public void OpenItem(string url, bool internalBrowser = true)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                if (internalBrowser == true)
                {
                    BrowsingService.Navigate(url, navigation, out var ppFrame);
                }
                else
                {
                    StartInfo.FileName = url;
                    Process.Start(StartInfo);
                }
            }
            catch
            {
                MessageBox.Show("Can't launch this url", "Extension Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
