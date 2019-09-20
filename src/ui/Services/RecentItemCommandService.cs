using System;
using GalaSoft.MvvmLight.Command;

namespace StartPagePlus.UI.Services
{
    using Interfaces;
    using Observables;
    using ViewModels;

    public class RecentItemCommandService : IRecentItemCommandService
    {
        public ObservableCommandList GetCommands(/*Action showFilter, Action removeFilter, */Action refresh)
            => new ObservableCommandList
            {
                //new CommandViewModel
                //{
                //    Name = "Filter Items",
                //    Command = new RelayCommand(showFilter, true),
                //    IsVisible = true
                //},
                //new CommandViewModel
                //{
                //    Name = "Remove Filter",
                //    Command = new RelayCommand(removeFilter, true),
                //    IsVisible = false,
                //},
                new CommandViewModel
                {
                    Name = "Refresh",
                    Command = new RelayCommand(refresh, true),
                }
            };
    }
}