using System.Collections.ObjectModel;

namespace StartPagePlus.UI.Services
{
    using ViewModels;

    public interface IRecentItemDataService
    {
        ObservableCollection<RecentItemViewModel> GetItems();
    }
}