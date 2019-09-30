using System;
using GalaSoft.MvvmLight.Command;

namespace StartPagePlus.UI.Services
{
    using Interfaces;
    using Observables;
    using ViewModels;

    public class StartActionCommandService : IStartActionCommandService
    {
        public ObservableCommandList GetCommands(Action openWebsite)
            => new ObservableCommandList
            {
                new CommandViewModel
                {
                    Name = $"{Vsix.Name} v{Vsix.Version}",
                    Command = new RelayCommand(openWebsite, true),
                    IsVisible = true
                }
            };
    }
}