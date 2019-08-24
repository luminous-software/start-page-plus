using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace StartPagePlus.UI.Services
{
    using ViewModels;

    public interface INewsItemDataService
    {
        Task<ObservableCollection<NewsItemViewModel>> GetItemsAsync(string url);
    }
}