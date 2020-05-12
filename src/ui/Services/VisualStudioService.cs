using System;
using System.Security.Principal;
using System.Windows;

using EnvDTE80;

using Luminous.Code.Extensions.ExceptionExtensions;
using Luminous.Code.VisualStudio.Packages;

using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

using Diagnostics = System.Diagnostics;

namespace StartPagePlus.UI.Services
{
    using Core.Services;

    using Interfaces;

    public class VisualStudioService : IVisualStudioService
    {
        private const string VERB_OPEN = "Open";
        private const string FILE_OPEN_FOLDER = "File.OpenFolder";
        private const string FILE_OPEN_PROJECT = "File.OpenProject";
        private const string FILE_NEW_PROJECT = "File.NewProject";
        private const string FILE_CLONE_OR_CHECKOUT_CODE = "File.Cloneorcheckoutcode";
        private const uint FORCE_NEW_WINDOW = (uint)__VSWBNAVIGATEFLAGS.VSNWB_ForceNew;

        public VisualStudioService()
        { }

        private IVsWebBrowsingService BrowsingService
            => AsyncPackageBase.GetGlobalService<SVsWebBrowsingService, IVsWebBrowsingService>();

        private static DTE2 Dte
            => GlobalServices.DTE2;

        private IVsShell3 VsShell3
            => GlobalServices.VsShell3;

        private IVsShell4 VsShell4
            => GlobalServices.VsShell4;

        public void ExecuteCommand(string action)
            => Dte.ExecuteCommand(action);

        public void ExecuteCommand(string action, string args = null)
            => Dte.ExecuteCommand(action, args);

        public void ShowMessage(string message)
            => MessageBox.Show(message, Vsix.Name, MessageBoxButton.OK, MessageBoxImage.Information);

        public bool Confirmed(string message)
            => (MessageBox.Show(message, Vsix.Name, MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK);

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
                    using (var proc = new Diagnostics.Process())
                    {
                        proc.StartInfo.FileName = url;
                        proc.StartInfo.Verb = VERB_OPEN;
                        proc.Start();
                    }
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

        public void RestartVisualStudio(bool confirm = true, bool elevated = false)
        {
            try
            {
                if (IsRunningElevated)
                {
                    if (!Confirmed("Visual Studio is currently running as Administrator. To return to running normally Visual Studio will need to close"))
                    {
                        return;
                    }

                    CloseVisualStudio();
                }

                if (confirm && !RestartConfirmed(elevated))
                    return;

                switch (elevated)
                {
                    case true:
                        RestartElevated();
                        break;

                    case false:
                        RestartNormal();
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ExtendedMessage());
            }
        }

        private void CloseVisualStudio()
            => Dte.Quit();

        private bool RestartConfirmed(bool elevated)
        {
            var suffix = (elevated) ? " as Administrator" : "";

            return Confirmed($"You're about to restart Visual Studio{suffix}");
        }

        private string RestartNormal()
        {
            const uint mode = (uint)__VSRESTARTTYPE.RESTART_Normal;

            return Restart(mode);
        }

        private string RestartElevated()
        {
            const uint mode = (uint)__VSRESTARTTYPE.RESTART_Elevated;

            return Restart(mode);
        }

        private string Restart(uint mode)
        {
            try
            {
                return ErrorHandler.Failed(VsShell4.Restart(mode))
                    ? "Unable to restart Visual Studio"
                    : "";
            }
            catch (Exception ex)
            {
                return ex.ExtendedMessage();
            }
        }

        private bool IsRunningElevated
        {
            get
            {
                VsShell3.IsRunningElevated(out var elevated);

                return elevated;
            }
        }

        private bool CurrentProcessIsElevated_()
        {
            using (var identity = WindowsIdentity.GetCurrent())
            {
                if (identity != null)
                {
                    var principal = new WindowsPrincipal(identity);

                    return principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
            }

            return false;
        }
    }
}