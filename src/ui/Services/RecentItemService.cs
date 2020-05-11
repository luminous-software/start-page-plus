namespace StartPagePlus.UI.Services
{
    using Interfaces;

    using ViewModels;

    public class RecentItemService : IItemService
    {
        public bool RemoveItem(RecentItemViewModel viewModel) { return true; }

        public bool PinItem(RecentItemViewModel viewModel) { return true; }

        public bool UnpinItem(RecentItemViewModel viewModel) { return true; }

        public bool CopyItemPath(RecentItemViewModel viewModel) { return true; }
    }
}