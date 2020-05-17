using System;

using GalaSoft.MvvmLight.Command;

namespace StartPagePlus.UI.Services
{
    using Interfaces;

    using Observables;

    using ViewModels;

    public class StartActionCommandService : IStartActionCommandService
    {
        public ObservableCommandList GetCommands(Action openChangelog, Action openSettings)
            => new ObservableCommandList
            {
                new CommandViewModel
                {
                    Name = "Changelog",
                    Command = new RelayCommand(openChangelog, true),
                    IsVisible = true
                },
                new CommandViewModel
                {
                    Name = "Settings",
                    Command = new RelayCommand(openSettings, true),
                    IsVisible = true
                },
            };
    }
}