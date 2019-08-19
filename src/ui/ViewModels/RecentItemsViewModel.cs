using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;

namespace StartPagePlus.UI.ViewModels
{
    public class RecentItemsViewModel : ColumnViewModel
    {
        public RecentItemsViewModel()
            => Commands = new ObservableCollection<CommandViewModel>
            {
                new CommandViewModel
                {
                    Name = "Filter",
                    Command = new RelayCommand(ExecuteFilter, CanExecuteFilter)
                },
                new CommandViewModel
                {
                    Name = "Remove Filter",
                    Command = new RelayCommand(ExecuteRemoveFilter, CanExecuteRemoveFilter),
                    IsVisible = false
                },
                new CommandViewModel
                {
                    Name = "Refresh",
                    Command = new RelayCommand(ExecuteRefresh, CanExecuteRefresh)
                }
            };

        public bool FilterVisible { get; set; }

        private bool CanExecuteFilter()
            => !FilterVisible;

        private void ExecuteFilter()
            => FilterVisible = true;

        private bool CanExecuteRemoveFilter()
            => FilterVisible;

        private void ExecuteRemoveFilter()
            => FilterVisible = false;

        private bool CanExecuteRefresh()
            => true;

        private void ExecuteRefresh()
        { }
    }
}