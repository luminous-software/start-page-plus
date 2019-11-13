using System;
using System.Windows;
using Luminous.Code.Extensions.ExceptionExtensions;
using Microsoft;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.Services
{
    using Enums;
    using UI.Interfaces;
    using ViewModels;

    public class RecentItemActionService : IRecentItemActionService
    {
        private const string SURROUND_WITH_QUOTES = "\"{0}\"";

        public RecentItemActionService(IVisualStudioService vsService)
            => VsService = vsService;

        public IVisualStudioService VsService { get; private set; }

        public void ExecuteAction(RecentItemViewModel viewModel)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                Assumes.Present(VsService);

                var path = viewModel.Path;
                //var folder = Path.GetDirectoryName(path);
                var itemType = viewModel.ItemType;

                switch (itemType)
                {
                    case RecentItemType.Folder:
                        VsService.ExecuteCommand("File.OpenFolder", SafePath(path));
                        break;

                    case RecentItemType.Solution:
                    //VsService.OpenSolution(path);
                    //break;

                    case RecentItemType.CSharpProject:
                        VsService.ExecuteCommand("File.OpenProject", SafePath(path));
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

        private string SafePath(string path)
            => path.Contains(" ") ? string.Format(SURROUND_WITH_QUOTES, path) : path;
    }
}