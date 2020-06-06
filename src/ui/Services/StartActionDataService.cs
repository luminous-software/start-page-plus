using System.Collections.ObjectModel;

namespace StartPagePlus.UI.Services
{
    using Interfaces;

    using ViewModels;


    public class StartActionDataService : IStartActionDataService
    {
        public StartActionDataService(IVisualStudioService vsService)
            => VsService = vsService;

        public IVisualStudioService VsService { get; }

        public ObservableCollection<StartActionViewModel> GetItems()
        {
            var items = new ObservableCollection<StartActionViewModel>
            {
                new GetCodeViewModel(VsService),
                new OpenFolderViewModel(VsService),
                new OpenProjectViewModel(VsService),
                new CreateProjectViewModel(VsService),
                new RestartNormalViewModel(VsService),
                new RestartElevatedViewModel(VsService),
            };

            return items;
        }
    }
}