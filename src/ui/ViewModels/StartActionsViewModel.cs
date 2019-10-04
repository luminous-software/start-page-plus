using System.Collections.ObjectModel;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class StartActionsViewModel : ColumnViewModel
    {
        private const string HEADING = "Get Started";
        private const string CHANGELOG_URL = "https://luminous-software.solutions/start-page-plus/changelog";
        private readonly bool internalBrowser = true;
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

        private void GetCommands()
            => Commands = CommandService.GetCommands(/*Continue, Refresh*/OpenWebsite);

        private void Continue()
        { }

        private void OpenWebsite()
            => VisualStudioService.OpenWebPage(CHANGELOG_URL, internalBrowser);

        private void Refresh()
        {
            Items.Clear();
            Items = DataService.GetItems();
        }
    }
}