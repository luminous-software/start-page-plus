using System.Collections.ObjectModel;

namespace StartPagePlus.UI.Services
{
    using Interfaces;
    using ViewModels;

    public class StartActionDataService : IStartActionDataService
    {
        public StartActionDataService()
        { }

        public ObservableCollection<StartActionViewModel> GetItems()
        {
            var items = new ObservableCollection<StartActionViewModel>
            {
                new GetCodeViewModel(),
                new OpenFolderViewModel(),
                new OpenProjectViewModel(),
                new CreateProjectViewModel()
            };

            return items;
        }
    }
}