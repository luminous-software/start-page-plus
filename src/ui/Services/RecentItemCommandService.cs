using System;

using GalaSoft.MvvmLight.Command;

namespace StartPagePlus.UI.Services
{
    using Interfaces;

    using Observables;

    using ViewModels;

    public class RecentItemCommandService : IRecentItemCommandService
    {
        public ObservableCommandList GetCommands(Action refresh)
            => new ObservableCommandList
            {
                new CommandViewModel
                {
                    Name = "Refresh",
                    Command = new RelayCommand(refresh, true),
                }
            };
    }
}