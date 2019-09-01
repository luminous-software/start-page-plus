namespace StartPagePlus.UI.Interfaces
{
    using System.Collections.ObjectModel;
    using ViewModels;

    public interface IStartActionDataService
    {
        ObservableCollection<StartActionViewModel> GetItems();
    }
}