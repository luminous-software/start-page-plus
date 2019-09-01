using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class StartActionsViewModel : ColumnViewModel
    {
        private StartActionViewModel selectedItem;
        private int selectedIndex;

        public StartActionsViewModel(IStartActionDataService dataService, IStartActionActionService actionService)
        {
            DataService = dataService;
            ActionService = actionService;
            Heading = "Get Started";
            Commands = new ObservableCollection<CommandViewModel>
            {
                new CommandViewModel
                {
                    Name = "Continue With No Code",
                    Command = new RelayCommand(ExecuteContinue, CanExecuteContinue)
                }
            };
            IsVisible = true;
        }

        public IStartActionDataService DataService { get; }

        public IStartActionActionService ActionService { get; }

        public ObservableCollection<StartActionViewModel> Items { get; set; }

        public StartActionViewModel SelectedItem
        {
            get => selectedItem;
            set
            {
                if (value != null)
                {
                    ActionService.DoAction(value);
                }

                Set(ref selectedItem, value);
            }
        }

        public int SelectedIndex
        {
            get => selectedIndex;
            set => Set(ref selectedIndex, value);
        }

        private bool CanExecuteContinue()
            => true;

        private void ExecuteContinue()
        { }

    }
}