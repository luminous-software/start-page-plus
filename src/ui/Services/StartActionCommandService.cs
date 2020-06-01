using System;

using GalaSoft.MvvmLight.Command;

namespace StartPagePlus.UI.Services
{
    using Interfaces;

    using Observables;

    using Options.Models;

    using ViewModels;

    public class StartActionCommandService : IStartActionCommandService
    {
        private string VersionNumber
            => GeneralOptions.Instance.PackageVersion;

        public ObservableCommandList GetCommands(Action openChangelog, Action openWebsite, Action openOptions)
            => new ObservableCommandList
            {
                new CommandViewModel
                {
                    Name = "Changelog",
                    Command = new RelayCommand(openChangelog, true),
                },
                new CommandViewModel
                {
                    Name = $"v{VersionNumber}",
                    Command = new RelayCommand(openWebsite, true),
                },
                new CommandViewModel
                {
                    Name = "Options",
                    Command = new RelayCommand(openOptions, true),
                },
            };
    }
}