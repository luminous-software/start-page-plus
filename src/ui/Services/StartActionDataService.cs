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
                ViewModelLocator.CloneOrCheckoutCodeViewModel,
                ViewModelLocator.OpenFolderViewModel,
                ViewModelLocator.OpenProjectViewModel,
                ViewModelLocator.CreateProjectViewModel,
                ViewModelLocator.RestartNormalViewModel,
                ViewModelLocator.RestartElevatedViewModel,
            };

            return items;
        }
    }
}