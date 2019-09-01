using System;
using System.IO;
using System.Windows;
using EnvDTE;
using EnvDTE80;
using Luminous.Code.Extensions.ExceptionExtensions;
using Microsoft.VisualStudio.Shell;


namespace StartPagePlus.UI.Services
{
    using UI.Interfaces;
    using ViewModels;

    public class RecentItemActionService : IRecentItemActionService
    {
        public void DoAction(RecentItemViewModel currentViewModel)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                var dte = Package.GetGlobalService(typeof(_DTE)) as DTE2;
                var path = currentViewModel.Path;
                var ext = Path.GetExtension(path).Substring(1);

                switch (ext)
                {
                    case "sln":
                        dte?.Solution.Open(path);
                        break;

                    case "csproj":
                        dte?.Solution.Open(path);
                        break;

                    case "":
                    default:
                        MessageBox.Show($"Unhandled extension:'{ext}'");
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:'{ex.ExtendedMessage()}'");
            }
        }
    }
}