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
        private bool pinned;
        public RecentItemViewModel(/*IItemService itemService*/)
        {
            ClickCommand = new RelayCommand(ExecuteClick, true);
            //ItemService = itemService;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public PeriodType PeriodType { get; set; }

        internal RecentItemType ItemType { get; set; }

        public string Path { get; set; }

        public ImageMoniker Moniker { get; set; }

        public bool Pinned
        {
            get => pinned;
            set => Set(ref pinned, value, nameof(Pinned));
        }

        //public IItemService ItemService { get; }

        public ICommand ClickCommand { get; }

        private void ExecuteClick()
            => MessengerInstance.Send(new RecentItemClickMessage(this, Path));
    }
}