using System.Collections.ObjectModel;

using GalaSoft.MvvmLight.Messaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class RecentItemsViewModel : ColumnViewModel
    {
        private const string HEADING = "Open a Recent Item";

        private ObservableCollection<RecentItemViewModel> items = new ObservableCollection<RecentItemViewModel>();
        private RecentItemViewModel _selectedItem;

        public RecentItemsViewModel(IRecentItemDataService dataService, IRecentItemActionService actionService, IRecentItemCommandService commandService, IItemService itemService)
            : base()
        {
            DataService = dataService;
            ActionService = actionService;
            CommandService = commandService;
            ItemService = itemService;

            Heading = HEADING;
            IsVisible = true;

            GetCommands();
            Refresh();

            MessengerInstance.Register<NotificationMessage<RecentItemViewModel>>(this, ExecuteAction);
        }

        public IItemService ItemService { get; }

        public IRecentItemDataService DataService { get; }

        public IRecentItemActionService ActionService { get; }

        public IRecentItemCommandService CommandService { get; }

        public ObservableCollection<RecentItemViewModel> Items
        {
            get => items;
            set => Set(ref items, value);
        }

        public RecentItemViewModel SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value, nameof(SelectedItem));
        }

        private void ExecuteAction(NotificationMessage<RecentItemViewModel> message)
            => ActionService.ExecuteAction(message.Content);

        private void GetCommands()
            => Commands = CommandService.GetCommands(Refresh);

        public void Refresh()
        {
            var items = DataService.GetItems();

            Items.Clear();

            foreach (var item in items)
            {
                Items.Add(item);
            }

            SelectedItem = null;
        }
    }
}