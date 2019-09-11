using System;
using System.Windows;
using EnvDTE;
using EnvDTE80;
using Luminous.Code.Extensions.ExceptionExtensions;
using Microsoft.VisualStudio.Shell;


namespace StartPagePlus.UI.Services
{
    using System.IO;
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
                var folder = Path.GetDirectoryName(path);
                var ext = Path.GetExtension(path);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:'{ex.ExtendedMessage()}'");
            }
        }
    }
}