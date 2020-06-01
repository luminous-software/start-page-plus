using System;
using System.IO;
using System.Security.Principal;

using EnvDTE80;

using Luminous.Code.Extensions.ExceptionExtensions;
using Luminous.Code.Extensions.Strings;
using Luminous.Code.VisualStudio.Packages;

using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

using Diagnostics = System.Diagnostics;

namespace StartPagePlus.UI.Services
{
    using System.Diagnostics;

    using Core.Interfaces;
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

        public VisualStudioService(IDialogService dialogService)
            => DialogService = dialogService;

        private IDialogService DialogService { get; }

        private IVsWebBrowsingService BrowsingService
            => AsyncPackageBase.GetGlobalService<SVsWebBrowsingService, IVsWebBrowsingService>();

        private static DTE2 Dte
            => GlobalServices.DTE2;

        private IVsShell3 VsShell3
            => GlobalServices.VsShell3;

        private IVsShell4 VsShell4
            => GlobalServices.VsShell4;

        public bool ExecuteCommand(string action, string args = "")
        {
            try
            {
                Dte.ExecuteCommand(action, args);
                return true;
            }
            catch (Exception ex)
            {
                DialogService.ShowError(ex);
                return false;
            }

        }

        public bool OpenWebPage(string url, bool openInVS)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                if (openInVS == true)
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
                return true;
            }
            catch
            {
                DialogService.ShowError($"Can't open '{url}'");
                return false;
            }
        }

        public bool OpenFolder(string path)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                if (path == null)
                    return false;

                if (path == "")
                    return OpenFolder();

                if (Directory.Exists(path))
                {
                    return ExecuteCommand(FILE_OPEN_FOLDER, path.ToQuotedString());
                }
                else
                {
                    DialogService.ShowExclamation($"'{path}' doesn't exist");
                    return false;
                }
            }
            catch (ArgumentException ex)
            {
                DialogService.ShowError(ex);
                return false;
            }
        }

        public bool OpenFolder()
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                return ExecuteCommand(FILE_OPEN_FOLDER, "");
            }
            catch (ArgumentException ex)
            {
                DialogService.ShowError(ex);
                return false;
            }
        }

        public bool OpenProject(string path)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                if (!string.IsNullOrEmpty(path))
                    path = path.ToQuotedString();

                if (File.Exists(path))
                {
                    return ExecuteCommand(FILE_OPEN_PROJECT, path.ToQuotedString());
                }
                else
                {
                    DialogService.ShowExclamation($"Can't find '{path}'");
                    return false;
                }
            }
            catch (ArgumentException ex)
            {
                DialogService.ShowError(ex);
                return false;
            }
        }

        public bool OpenProject()
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                return ExecuteCommand(FILE_OPEN_PROJECT);
            }
            catch (ArgumentException ex)
            {
                DialogService.ShowError(ex);
                return false;
            }
        }

        public void CreateNewProject()
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                ExecuteCommand(FILE_NEW_PROJECT);
            }
            catch (ArgumentException ex)
            {
                DialogService.ShowError(ex);
            }
        }

        public void CloneOrCheckoutCode()
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                ExecuteCommand(FILE_CLONE_OR_CHECKOUT_CODE);
            }
            catch (ArgumentException ex)
            {
                DialogService.ShowError(ex);
            }
        }

        public void RestartVisualStudio(bool confirm = true, bool elevated = false)
        {
            try
            {
                if (IsRunningElevated)
                {
                    if (!DialogService.Confirmed("Visual Studio is currently running as Administrator. To return to running normally Visual Studio will need to close"))
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
                DialogService.ShowError(ex);
            }
        }

        private void CloseVisualStudio()
            => Dte.Quit();

        private bool RestartConfirmed(bool elevated)
        {
            var suffix = (elevated) ? " as Administrator" : "";

            return DialogService.Confirmed($"You're about to restart Visual Studio{suffix}");
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


        public bool OpenProjectOrSolutionInVS(string path)
        {
            try
            {
                using (var proc = new Process())
                {
                    proc.StartInfo.FileName = path.ToQuotedString();
                    proc.StartInfo.Verb = VERB_OPEN;
                    proc.Start();
                }
                return true;
            }
            catch (Exception ex)
            {
                DialogService.ShowError(ex);
                return false;
            }
        }

        public bool OpenFolderInVS(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    using (var process = new Process())
                    {
                        var startInfo = new ProcessStartInfo("devenv.exe", "/edit " + path.ToQuotedString());

                        process.StartInfo = startInfo;
                        process.Start();

                        return true;
                    }
                }
                else
                {
                    DialogService.ShowExclamation($"'{path}' doesn't exist");
                    return false;
                }

            }
            catch (Exception ex)
            {
                DialogService.ShowError(ex);
                return false;
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