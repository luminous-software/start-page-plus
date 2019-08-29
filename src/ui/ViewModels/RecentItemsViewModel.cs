using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class RecentItemsViewModel : ColumnViewModel
    {
        private RecentItemViewModel selectedItem;
        private int selectedIndex;


        public RecentItemsViewModel(IRecentItemDataService dataService, IRecentItemActionService actionService)
        {
            DataService = dataService;
            ActionService = actionService;
            Heading = "Open a Recent Item";
            IsVisible = true;
            Commands = new ObservableCollection<CommandViewModel>
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

        public bool Filtered { get; set; }

        public ObservableCollection<RecentItemViewModel> Items { get; set; }

        public RecentItemViewModel SelectedItem
        {
            get => selectedItem;
            set
            {
                Set(ref selectedItem, value);

                if (value != null)
                {
                    ActionService.OpenItem(value.Path);
                    SelectedItem = null;
                }
            }
        }

        public int SelectedIndex
        {
            get => selectedIndex;
            set => Set(ref selectedIndex, value);
        }

        public IRecentItemDataService DataService { get; }

        public IRecentItemActionService ActionService { get; }

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
            => Items = DataService.GetItems();
    }
}