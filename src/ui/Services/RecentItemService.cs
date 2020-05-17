using System;
using System.Linq;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

    using Interfaces;

    using ViewModels;

    public class RecentItemService : IRecentItemService
    {
        public RecentItemService(IRecentItemDataService dataService, IDialogService dialogService)
        {
            DataService = dataService;
            DialogService = dialogService;
        }
        public IRecentItemDataService DataService { get; }

        public IDialogService DialogService { get; }

        public bool RemoveItem(RecentItemViewModel viewModel) { return true; }

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

        public bool CopyItemPath(RecentItemViewModel viewModel) { return true; }
    }
}