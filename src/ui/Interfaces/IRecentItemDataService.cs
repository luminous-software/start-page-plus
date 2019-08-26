using System.Collections.ObjectModel;

namespace StartPagePlus.UI.Interfaces
{
    using ViewModels;

    public interface IRecentItemDataService
    {
        ObservableCollection<RecentItemViewModel> GetItems();
    }
}