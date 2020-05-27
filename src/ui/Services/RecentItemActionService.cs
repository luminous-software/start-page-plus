using System;
using System.Windows;

using Luminous.Code.Extensions.ExceptionExtensions;

using Microsoft;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

    using Enums;

    using Interfaces;

    using ViewModels;

    public class RecentItemActionService : IRecentItemActionService
    {
        private const string SURROUND_WITH_QUOTES = "\"{0}\"";

        public RecentItemActionService(IRecentItemDataService dataService, IVisualStudioService vsService, IDialogService dialogService, IDateTimeService dateTimeService)
        {
            DataService = dataService;
            VsService = vsService;
            DialogService = dialogService;
            DateTimeService = dateTimeService;
        }

        public IRecentItemDataService DataService { get; }

        public IVisualStudioService VsService { get; }

        private IDialogService DialogService { get; }

        private IDateTimeService DateTimeService { get; }

        public void ExecuteAction(RecentItemViewModel viewModel)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                Assumes.Present(VsService);

                var path = SafePath(viewModel.Path);
                var itemType = viewModel.ItemType;

                switch (itemType)
                {
                    case RecentItemType.Folder:
                        if (VsService.OpenFolder(path))
                        {
                            SetLastAccessed(path);
                        };
                        break;

                    case RecentItemType.Solution:
                        if (VsService.OpenSolution(path))
                        {
                            SetLastAccessed(path);
                        }
                        break;

                    case RecentItemType.CSharpProject:
                    case RecentItemType.VisualBasicProject:
                        if (VsService.OpenProject(path))
                        {
                            SetLastAccessed(path);
                        }
                        break;

                    default:
                        DialogService.ShowMessage($"Unhandled item type:'{itemType}'");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:'{ex.ExtendedMessage()}'", Vsix.Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetLastAccessed(string path)
            => DataService.SetLastAccessed(path, DateTimeService.Today.Date);

        private string SafePath(string path)
            => path.Contains(" ")
                ? string.Format(SURROUND_WITH_QUOTES, path)
                : path;
    }
}