using System.Windows;
using EnvDTE;
using EnvDTE80;
using Luminous.Code.VisualStudio.Packages;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Diagnostics = System.Diagnostics;

namespace StartPagePlus.UI.Services
{
    using Interfaces;

    public class VisualStudioService : IVisualStudioService
    {
        private static readonly DTE2 dte;
        private const uint FORCE_NEW_WINDOW = (uint)__VSWBNAVIGATEFLAGS.VSNWB_ForceNew;
        private IVsWebBrowsingService browsingService;
        private Diagnostics.ProcessStartInfo startInfo;
        protected static DTE2 Dte = dte ?? (dte = Package.GetGlobalService(typeof(_DTE)) as DTE2);

        private Diagnostics.ProcessStartInfo StartInfo
            => startInfo
                ?? (startInfo = new Diagnostics.ProcessStartInfo
                {
                    UseShellExecute = true,
                    Verb = "Open"
                });

        private IVsWebBrowsingService BrowsingService
            => browsingService ?? (browsingService = AsyncPackageBase.GetGlobalService<SVsWebBrowsingService, IVsWebBrowsingService>());

        public void ExecuteCommand(string action)
            => Dte.ExecuteCommand(action);

        public void ShowMessage(string message)
            => MessageBox.Show(message, Vsix.Name, MessageBoxButton.OK, MessageBoxImage.Information);

        public void NavigateTo(string url, bool internalBrowser)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                if (internalBrowser == true)
                {
                    BrowsingService.Navigate(url, FORCE_NEW_WINDOW, out var ppFrame);
                }
                else
                {
                    StartInfo.FileName = url;
                    Diagnostics.Process.Start(StartInfo);
                }
            }
            catch
            {
                MessageBox.Show("Can't launch this url", Vsix.Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}