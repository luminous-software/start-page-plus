using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;

namespace StartPagePlus.UI.ViewModels
{
    using GalaSoft.MvvmLight.Messaging;
    using Interfaces;

    public class RecentItemsViewModel : ColumnViewModel
    {
        private const string HEADING = "Open a Recent Item";

        private ObservableCollection<RecentItemViewModel> items;
        private bool filtered;

        public RecentItemsViewModel(IRecentItemDataService dataService, IRecentItemActionService actionService)
        {
            DataService = dataService;
            ActionService = actionService;
            Heading = HEADING;
            Commands = GetCommands();
            IsVisible = true;

            MessengerInstance.Register<NotificationMessage<RecentItemViewModel>>(this, ExecuteAction);
        }

        public IRecentItemDataService DataService { get; }

        public IRecentItemActionService ActionService { get; }

        public ObservableCollection<RecentItemViewModel> Items
        {
            get => items;
            set => Set(ref items, value);
        }

        private ObservableCollection<CommandViewModel> GetCommands()
            => new ObservableCollection<CommandViewModel>
            {
                new CommandViewModel
                {
                    Name = "Filter Items",
                    Command = new RelayCommand(ExecuteFilterItems, !Filtered)
                },
                new CommandViewModel
                {
                    Name = "Remove Filter",
                    Command = new RelayCommand(ExecuteRemoveFilter, Filtered),
                    IsVisible = false
                },
                new CommandViewModel
                {
                    Name = "Refresh",
                    Command = new RelayCommand(ExecuteRefresh, true)
                }
            };

        public bool Filtered
        {
            get => filtered;
            set => Set(ref filtered, value);
        }

        private void ExecuteAction(NotificationMessage<RecentItemViewModel> message)
            => ActionService.ExecuteAction(message.Content);

        private void ExecuteFilterItems()
            => Filtered = true;

        private void ExecuteRemoveFilter()
            => Filtered = false;

        internal void ExecuteRefresh()
        {
            Items.Clear();
            Items = DataService.GetItems();
        }
    }
}