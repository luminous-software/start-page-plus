using System.Collections.ObjectModel;

using GalaSoft.MvvmLight.Messaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class RecentItemsViewModel : ColumnViewModel
    {
        private const string HEADING = "Open a Recent Item";

        private ObservableCollection<RecentItemViewModel> items = new ObservableCollection<RecentItemViewModel>();

        public RecentItemsViewModel(IRecentItemDataService dataService, IRecentItemActionService actionService, IRecentItemCommandService commandService)
            : base()
        {
            DataService = dataService;
            ActionService = actionService;
            CommandService = commandService;

            Heading = HEADING;
            IsVisible = true;

            GetCommands();
            Refresh();

            MessengerInstance.Register<NotificationMessage<RecentItemViewModel>>(this, ExecuteAction);
        }

        public IRecentItemDataService DataService { get; }

        public IRecentItemActionService ActionService { get; }

        public IRecentItemCommandService CommandService { get; }

        public ObservableCollection<RecentItemViewModel> Items
        {
            get => items;
            set => Set(ref items, value);
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
        }
    }
}