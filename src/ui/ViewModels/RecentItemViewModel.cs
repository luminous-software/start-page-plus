using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.ViewModels
{
    using Enums;

    public class RecentItemViewModel : ViewModelBase
    {
        public RecentItemViewModel()
            => ClickCommand = new RelayCommand(ExecuteClick, true);

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public PeriodType PeriodType { get; set; }

        internal RecentItemType ItemType { get; set; }

        public string Path { get; set; }

        public ImageMoniker Moniker { get; set; }

        public bool Pinned { get; set; }

        public ICommand ClickCommand { get; set; }

        private void ExecuteClick()
            => MessengerInstance.Send(new NotificationMessage<RecentItemViewModel>(this, Path));
    }
}