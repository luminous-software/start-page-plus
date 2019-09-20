using System;
using GalaSoft.MvvmLight.Command;

namespace StartPagePlus.UI.Services
{
    using Interfaces;
    using Observables;
    using ViewModels;

    public class StartActionCommandService : IStartActionCommandService
    {
        public ObservableCommandList GetCommands(/*Action continueWithNoCode,*/ Action refresh)
            => new ObservableCommandList
            {
                //new CommandViewModel
                //{
                //    Name = "Continue With No Code",
                //    Command = new RelayCommand(continueWithNoCode, true),
                //    IsVisible = true
                //},
                new CommandViewModel
                {
                    Name = "Refresh",
                    Command = new RelayCommand(refresh, true),
                    IsVisible = false
                }
            };
    }
}