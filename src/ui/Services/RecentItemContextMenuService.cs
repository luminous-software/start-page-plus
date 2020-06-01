using System;
using System.Linq;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

    using Interfaces;

    using ViewModels;

    public class RecentItemContextMenuService : IRecentItemContextMenuService
    {
        private readonly IDateTimeService dateTimeService;

        public RecentItemContextMenuService(IRecentItemDataService dataService, IDialogService dialogService, IClipboardService clipboardService, IDateTimeService dateTimeService, IVisualStudioService visualStudioService)
        {
            DataService = dataService;
            DialogService = dialogService;
            ClipboardService = clipboardService;
            this.dateTimeService = dateTimeService;
            VisualStudioService = visualStudioService;
        }

        private IRecentItemDataService DataService { get; }

        private IDialogService DialogService { get; }

        private IClipboardService ClipboardService { get; }

        public IVisualStudioService VisualStudioService { get; }

        public bool RemoveItem(RecentItemViewModel viewModel)
        {
            try
            {
                var recentItems = DataService.GetRecentItems();
                var itemToRemove = recentItems.FirstOrDefault(x => x.Key == viewModel.Path);

                recentItems.Remove(itemToRemove);

                DataService.UpdateRecentItems(recentItems);
            }
            catch (Exception ex)
            {
                DialogService.ShowError(ex);
            }

            return true;
        }

        public bool PinItem(RecentItemViewModel viewModel)
        {
            try
            {
                var recentItems = DataService.GetRecentItems();
                var itemToPin = recentItems.FirstOrDefault(x => x.Key == viewModel.Path);

                itemToPin.Value.IsFavorite = true;

                DataService.UpdateRecentItems(recentItems);
            }
            catch (Exception ex)
            {
                DialogService.ShowError(ex);
            }

            return true;
        }

        public bool UnpinItem(RecentItemViewModel viewModel)
        {
            try
            {
                var recentItems = DataService.GetRecentItems();
                var itemToPin = recentItems.FirstOrDefault(x => x.Key == viewModel.Path);

                itemToPin.Value.IsFavorite = false;

                DataService.UpdateRecentItems(recentItems);
            }
            catch (Exception ex)
            {
                DialogService.ShowError(ex);
            }

            return true;
        }

        public bool CopyItemPath(RecentItemViewModel viewModel)
        {
            ClipboardService.CopyToClipboard(viewModel.Path);

            return true;
        }

        public bool OpenInVS(RecentItemViewModel viewModel)
        {
            var path = viewModel.Path;
            var result = (viewModel.ItemType == (Enums.RecentItemType.Folder)
                ? VisualStudioService.OpenFolderInVS(path)
                : VisualStudioService.OpenProjectOrSolutionInVS(path));

            if (result)
            {
                DataService.SetLastAccessed(path, dateTimeService.Today.Date);
            }

            return result;
        }
    }
}