using System;

using GalaSoft.MvvmLight.Messaging;

using Microsoft;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

    using Enums;

    using Interfaces;

    using Messages;

    using ViewModels;

    public class RecentItemActionService : IRecentItemActionService
    {
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

                var path = viewModel.Path;
                var itemType = viewModel.ItemType;

                switch (itemType)
                {
                    case RecentItemType.Folder:
                        if (VsService.OpenFolder(path))
                        {
                            SetLastAccessed(path);
                            SendRefreshMessage();
                        };
                        break;

                    case RecentItemType.Solution:
                    case RecentItemType.CSharpProject:
                    case RecentItemType.VisualBasicProject:
                        if (VsService.OpenProject(path))
                        {
                            SetLastAccessed(path);
                            SendRefreshMessage();
                        }
                        break;

                    default:
                        DialogService.ShowMessage($"Unhandled item type:'{itemType}'");
                        break;
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowError(ex);
            }
        }

        private void SetLastAccessed(string path)
            => DataService.SetLastAccessed(path, DateTimeService.Today.Date);

        private void SendRefreshMessage()
            => Messenger.Default.Send(new RecentItemsRefreshMessage());
    }
}