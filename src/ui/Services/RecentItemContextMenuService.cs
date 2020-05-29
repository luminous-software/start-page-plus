using System;
using System.Linq;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

    using Interfaces;

    using ViewModels;

    public class RecentItemContextMenuService : IRecentItemContextMenuService
    {
        public RecentItemContextMenuService(IRecentItemDataService dataService, IDialogService dialogService, IClipboardService clipboardService)
        {
            DataService = dataService;
            DialogService = dialogService;
            ClipboardService = clipboardService;
        }

        public IRecentItemDataService DataService { get; }

        public IDialogService DialogService { get; }

        public IClipboardService ClipboardService { get; }

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
    }
}