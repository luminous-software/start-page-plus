using System.Diagnostics;
using System.Windows;
using Luminous.Code.VisualStudio.Packages;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;
    using ViewModels;

    public class NewsItemActionService : INewsItemActionService
    {
        private const uint FORCE_NEW_WINDOW = (uint)__VSWBNAVIGATEFLAGS.VSNWB_ForceNew;
        private IVsWebBrowsingService browsingService;
        private ProcessStartInfo startInfo;

        public NewsItemActionService()
        { }

        private IVsWebBrowsingService BrowsingService
            => browsingService ?? (browsingService = AsyncPackageBase.GetGlobalService<SVsWebBrowsingService, IVsWebBrowsingService>());

        private ProcessStartInfo StartInfo
            => startInfo
                ?? (startInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    Verb = "Open"
                });

        public void DoAction(NewsItemViewModel currentViewModel, bool internalBrowser = true)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                var url = currentViewModel.Link;

                if (internalBrowser == true)
                {
                    BrowsingService.Navigate(url, FORCE_NEW_WINDOW, out var ppFrame);
                }
                else
                {
                    StartInfo.FileName = url;
                    Process.Start(StartInfo);
                }
            }
            catch
            {
                MessageBox.Show("Can't launch this url", Vsix.Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
