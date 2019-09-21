using System.Collections.ObjectModel;

namespace StartPagePlus.UI.Interfaces
{
    using ViewModels;


    public interface IStartActionDataService
    {
        ObservableCollection<StartActionViewModel> GetItems();
    }
}