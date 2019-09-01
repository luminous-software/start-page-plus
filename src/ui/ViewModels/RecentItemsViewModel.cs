using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class RecentItemsViewModel : ColumnViewModel
    {
        private const string HEADING = "Open a Recent Item";
        private RecentItemViewModel selectedItem;
        private int selectedIndex;


        public RecentItemsViewModel(IRecentItemDataService dataService, IRecentItemActionService actionService)
        {
            DataService = dataService;
            ActionService = actionService;
            Heading = HEADING;
            Commands = GetCommands();
            IsVisible = true;
        }

        public IRecentItemDataService DataService { get; }

        public IRecentItemActionService ActionService { get; }

        public ObservableCollection<RecentItemViewModel> Items { get; set; }

        public RecentItemViewModel SelectedItem
        {
            get => selectedItem;
            set
            {
                if (value != null)
                {
                    ActionService.DoAction(value);
                }

                Set(ref selectedItem, value);
            }
        }

        public int SelectedIndex
        {
            get => selectedIndex;
            set => Set(ref selectedIndex, value);
        }

        public bool Filtered { get; set; }
        private bool CanExecuteShowFilter()
            => !Filtered;

        private void ExecuteShowFilter()
            => Filtered = true;

        private bool CanExecuteHideFilter()
            => Filtered;

        private void ExecuteHideFilter()
            => Filtered = false;

        private bool CanExecuteRefresh()
            => true;

        public void ExecuteRefresh()
        {
            Items = null;
            Items = DataService.GetItems();
        }

        private ObservableCollection<CommandViewModel> GetCommands()
            => new ObservableCollection<CommandViewModel>
            {
                //new CommandViewModel
                //{
                //    Name = "Filter",
                //    Command = new RelayCommand(ExecuteFilter, CanExecuteFilter)
                //},
                //new CommandViewModel
                //{
                //    Name = "Remove Filter",
                //    Command = new RelayCommand(ExecuteRemoveFilter, CanExecuteRemoveFilter),
                //    IsVisible = false
                //},
                new CommandViewModel
                {
                    Name = "Refresh",
                    Command = new RelayCommand(ExecuteRefresh, CanExecuteRefresh)
                }
            };
    }
}