using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace StartPagePlus.UI.Interfaces
{
    using ViewModels;

    public interface INewsItemDataService
    {
        Task<ObservableCollection<NewsItemViewModel>> GetItemsAsync(string url);
    }
}