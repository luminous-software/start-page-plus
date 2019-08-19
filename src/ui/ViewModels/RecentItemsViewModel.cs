using System;
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
                    Name = "Refresh",
                    Command = new RelayCommand(ExecuteRefresh, CanExecuteRefresh)
                }
            };

        public bool FilterVisible { get; set; }

        private bool CanExecuteFilter() => FilterVisible = true;

        private void ExecuteFilter() => throw new NotImplementedException();

        private bool CanExecuteRefresh() => true;

        private void ExecuteRefresh() => throw new NotImplementedException();
    }
}