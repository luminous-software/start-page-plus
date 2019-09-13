using System;
using System.IO;
using System.Windows;
using EnvDTE;
using EnvDTE80;
using Luminous.Code.Extensions.ExceptionExtensions;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.Services
{
    using Enums;
    using UI.Interfaces;
    using ViewModels;

    public class RecentItemActionService : IRecentItemActionService
    {
        public void ExecuteAction(RecentItemViewModel currentViewModel)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                var dte = Package.GetGlobalService(typeof(_DTE)) as DTE2;
                var path = currentViewModel.Path;
                var folder = Path.GetDirectoryName(path);
                var itemType = currentViewModel.ItemType;

                switch (itemType)
                {
                    case RecentItemType.Folder:
                        dte?.ExecuteCommand("File.OpenFolder", path);
                        break;

                    case RecentItemType.Solution:
                        dte?.Solution.Open(path);
                        break;

                    case RecentItemType.CsProject:
                        dte?.ExecuteCommand("File.OpenProject", path);
                        break;

                    default:
                        MessageBox.Show($"Unhandled item type:'{itemType}'", Vsix.Name, MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:'{ex.ExtendedMessage()}'", Vsix.Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}