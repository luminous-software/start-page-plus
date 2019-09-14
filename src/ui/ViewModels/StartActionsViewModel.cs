using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class StartActionsViewModel : ColumnViewModel
    {
        private const string HEADING = "Get Started";

        private ObservableCollection<StartActionViewModel> items;

        public StartActionsViewModel(IStartActionDataService dataService)
        {
            DataService = dataService;
            Heading = HEADING;
            Items = DataService.GetItems();
            Commands = GetCommands();
            IsVisible = true;
        }
        public IStartActionDataService DataService { get; }

        public ObservableCollection<StartActionViewModel> Items
        {
            get => items;
            set => Set(ref items, value);
        }

        private ObservableCollection<CommandViewModel> GetCommands()
            => new ObservableCollection<CommandViewModel>
            {
                new CommandViewModel
                {
                    Name = "Continue With No Code",
                    Command = new RelayCommand(ExecuteContinue, true),
                    Enabled = false
                }
            };

        private void ExecuteContinue()
        { }
    }
}