using System.Collections.ObjectModel;

using Luminous.Code.VisualStudio.Packages;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    using Options.Models;
    using Options.Pages;

    public class StartActionsViewModel : ColumnViewModel
    {
        private const string HEADING = "Get Started";
        private const string WEBSITE_URL = "https://luminous-software.solutions/start-page-plus";
        private const string CHANGELOG_URL = WEBSITE_URL + "/changelog";
        private ObservableCollection<StartActionViewModel> items = new ObservableCollection<StartActionViewModel>();

        public StartActionsViewModel(IStartActionDataService dataService, IStartActionCommandService commandService, IVisualStudioService vsService)
        {
            DataService = dataService;
            CommandService = commandService;
            VisualStudioService = vsService;
            Heading = HEADING;
            IsVisible = true;
            GetCommands();
            Refresh();
        }

        public IStartActionDataService DataService { get; }

        public IStartActionCommandService CommandService { get; }

        public IVisualStudioService VisualStudioService { get; }

        public ObservableCollection<StartActionViewModel> Items
        {
            get => items;
            set => Set(ref items, value);
        }

        private bool OpenLinksInVS
            => NewsItemsOptions.Instance.OpenLinksInVS;

        private void GetCommands()
            => Commands = CommandService.GetCommands(OpenChangelog, OpenWebsite, OpenOptions);

        private void OpenChangelog()
            => VisualStudioService.OpenWebPage(CHANGELOG_URL, OpenLinksInVS);

        private void OpenWebsite()
            => VisualStudioService.OpenWebPage(WEBSITE_URL, OpenLinksInVS);

        private void OpenOptions()
            => AsyncPackageBase.Instance.ShowOptionsPage<DialogPageProvider.General>();

        private void Refresh()
        {
            Items.Clear();
            Items = DataService.GetItems();
        }
    }
}