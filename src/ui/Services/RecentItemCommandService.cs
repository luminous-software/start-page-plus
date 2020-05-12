using System;

using GalaSoft.MvvmLight.Command;

using Microsoft.VisualStudio.Imaging;

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

        public ObservableContextCommandList GetContextCommands(
            bool canRemove, Action remove,
            bool canPin, Action pin,
            bool canUnpin, Action unpin,
            bool canCopyPath, Action copyPath)
            => new ObservableContextCommandList
            {
                new ContextCommandViewModel
                {
                    Name = "Remove item",
                    Moniker = KnownMonikers.DeleteListItem,
                    Command = new RelayCommand(remove, canRemove),
                    IsVisible = canRemove,
                },
                new ContextCommandViewModel
                {
                    Name = "Pin item",
                    Moniker = KnownMonikers.Pin,
                    Command = new RelayCommand(pin, canPin),
                    IsVisible = canPin,
                },
                new ContextCommandViewModel
                {
                    Name = "Unpin item",
                    Moniker = KnownMonikers.Unpin,
                    Command = new RelayCommand(unpin, canUnpin),
                    IsVisible = canUnpin,
                },
                new ContextCommandViewModel
                {
                    Name = "Copy item path",
                    Moniker = KnownMonikers.Copy,
                    Command = new RelayCommand(copyPath, canCopyPath),
                    IsVisible = canCopyPath,
                },
            };
    }
}