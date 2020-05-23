using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StartPagePlus.UI.Interfaces
{
    using Models;

    using ViewModels;

    public interface IRecentItemDataService
    {
        ObservableCollection<RecentItemViewModel> GetItems(int itemsToDisplay, bool hideExtensions);

        List<RecentItem> GetRecentItems();
        bool UpdateRecentItems(List<RecentItem> recentItems);
    }
}