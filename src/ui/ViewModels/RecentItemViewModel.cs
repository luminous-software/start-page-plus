﻿using System;
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
            PinOrUnpinItemCommand = new RelayCommand(PinOrUnpinItem, true);
            CopyItemPathCommand = new RelayCommand(CopyItemPath, true);
        }

        public ICommand SelectItemCommand { get; }

        public ICommand PinOrUnpinItemCommand { get; }

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

        private void PinOrUnpinItem()
            => MessengerInstance.Send(new RecentItemPinnedOrUnpinnedMessage(this, Pinned.ToString()));

        private void CopyItemPath()
            => MessengerInstance.Send(new RecentItemCopyPathMessage(this));
    }
}