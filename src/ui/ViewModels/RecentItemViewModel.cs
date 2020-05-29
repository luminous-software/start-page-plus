using System;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.ViewModels
{
    using Enums;

    using Messages;

    public class RecentItemViewModel : ViewModelBase
    {
        public RecentItemViewModel()
        {
            SelectItemCommand = new RelayCommand(SelectItem, true);
            TogglePinnedCommand = new RelayCommand(TogglePinned, true);
            RemoveItemCommand = new RelayCommand(RemoveItem, true);
            CopyItemPathCommand = new RelayCommand(CopyItemPath, true);
        }

        public ICommand SelectItemCommand { get; }

        public ICommand TogglePinnedCommand { get; }

        public ICommand RemoveItemCommand { get; }

        public ICommand CopyItemPathCommand { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public PeriodType PeriodType { get; set; }

        internal RecentItemType ItemType { get; set; }

        public string Path { get; set; }

        public ImageMoniker Moniker { get; set; }

        public bool Pinned { get; set; }

        private void SelectItem()
            => MessengerInstance.Send(new RecentItemSelectedMessage(this));

        private void TogglePinned()
            => MessengerInstance.Send(new RecentItemPinnedOrUnpinnedMessage(this));

        private void RemoveItem()
            => MessengerInstance.Send(new RecentItemRemovedMessage(this));

        private void CopyItemPath()
            => MessengerInstance.Send(new RecentItemCopyPathMessage(this));
    }
}