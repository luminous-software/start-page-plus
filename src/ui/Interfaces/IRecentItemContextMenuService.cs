﻿
namespace StartPagePlus.UI.Interfaces
{
    using ViewModels;

    public interface IRecentItemContextMenuService
    {
        bool RemoveItem(RecentItemViewModel viewModel);

        bool PinItem(RecentItemViewModel viewModel);

        bool UnpinItem(RecentItemViewModel viewModel);

        bool CopyItemPath(RecentItemViewModel viewModel);

        bool OpenInVS(RecentItemViewModel viewModel);
    }
}