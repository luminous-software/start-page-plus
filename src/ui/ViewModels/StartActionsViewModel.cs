using System.Collections.ObjectModel;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class StartActionsViewModel : ColumnViewModel
    {
        private const string HEADING = "Get Started";

        private ObservableCollection<StartActionViewModel> items = new ObservableCollection<StartActionViewModel>();

        public StartActionsViewModel(IStartActionDataService dataService, IStartActionCommandService commandService)
        {
            DataService = dataService;
            CommandService = commandService;

            Heading = HEADING;
            IsVisible = true;

            GetCommands();
            Refresh();
        }

        public IStartActionDataService DataService { get; }

        public IStartActionCommandService CommandService { get; }

        public ObservableCollection<StartActionViewModel> Items
        {
            get => items;
            set => Set(ref items, value);
        }

        private void GetCommands()
            => Commands = CommandService.GetCommands(/*Continue,*/ Refresh);

        private void Continue()
        { }

        private void Refresh()
        {
            Items.Clear();
            Items = DataService.GetItems();
        }
    }
}