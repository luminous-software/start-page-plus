using System.Windows;
using System.Diagnostics;
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
        private const string VERB_OPEN = "Open";
        private const string FILE_OPEN_FOLDER = "File.OpenFolder";
        private const string FILE_OPEN_PROJECT = "File.OpenProject";
        private const string FILE_NEW_PROJECT = "File.NewProject";
        private const string FILE_CLONE_OR_CHECKOUT_CODE = "File.Cloneorcheckoutcode";
        private const uint FORCE_NEW_WINDOW = (uint)__VSWBNAVIGATEFLAGS.VSNWB_ForceNew;

        private static readonly DTE2 dte;
        private IVsWebBrowsingService browsingService;
        private ProcessStartInfo startInfo;

        protected static DTE2 Dte = dte ?? (dte = Package.GetGlobalService(typeof(_DTE)) as DTE2);

        private ProcessStartInfo StartInfo
            => startInfo
                ?? (startInfo = new Diagnostics.ProcessStartInfo
                {
                    UseShellExecute = true,
                    Verb = VERB_OPEN
                });

        private IVsWebBrowsingService BrowsingService
            => browsingService ?? (browsingService = AsyncPackageBase.GetGlobalService<SVsWebBrowsingService, IVsWebBrowsingService>());

        public void ExecuteCommand(string action)
            => Dte.ExecuteCommand(action);

        public void ExecuteCommand(string action, string args= null)
            => Dte.ExecuteCommand(action, args);

        public void ShowMessage(string message)
            => MessageBox.Show(message, Vsix.Name, MessageBoxButton.OK, MessageBoxImage.Information);

        public void OpenWebPage(string url, bool internalBrowser)
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

        public void OpenFolder(string path = "")
            => Dte?.ExecuteCommand(FILE_OPEN_FOLDER, path);

        //public void OpenSolution(string path = null)
        //{
        //    ThreadHelper.ThrowIfNotOnUIThread();

        //    Dte?.Solution.Open(path);
        //}

        public void OpenProject(string path = "")
            => Dte?.ExecuteCommand(FILE_OPEN_PROJECT, path);

        public void CreateNewProject()
            => ExecuteCommand(FILE_NEW_PROJECT);

        public void CloneOrCheckoutCode()
            => ExecuteCommand(FILE_CLONE_OR_CHECKOUT_CODE);
    }
}