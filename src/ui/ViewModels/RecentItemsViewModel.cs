using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;

namespace StartPagePlus.UI.ViewModels
{
    using Services;

    public class RecentItemsViewModel : ColumnViewModel
    {
        public RecentItemsViewModel(IRecentItemDataService dataService)
        {
            Heading = "Open a Recent Item";
            IsVisible = true;
            Items = dataService.GetItems();
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

        public ObservableCollection<RecentItemViewModel> Items { get; }

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

        private void ExecuteRefresh()
        { }
    }
}