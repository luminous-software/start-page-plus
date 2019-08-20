using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    public class StartActionsViewModel : ColumnViewModel
    {
        public StartActionsViewModel()
        {
            Heading = "Get Started";
            IsVisible = true;
            StartActions = new ObservableCollection<StartActionViewModel>
            {
                new StartActionViewModel
                {
                    Moniker=KnownMonikers.DownloadNoColor,
                    Name = "Clone or checkout code",
                    Description = "Get code from an online repository like GitHub or Azure DevOps"
                },
                new StartActionViewModel
                {
                    Moniker=KnownMonikers.OpenFolder,
                    Name = "Open a local folder",
                    Description = "Navigate and edit code within any folder"
                },
                new StartActionViewModel
                {
                    Moniker=KnownMonikers.OpenDocumentGroup,
                    Name = "Open a project or solution",
                    Description = "Open a local Visual Studio project or a .sln file"
                },
                new StartActionViewModel
                {
                    Moniker=KnownMonikers.AddDocumentGroup,
                    Name = "Create a new project",
                    Description = "Choose a project template with code scaffolding to get started"
                },
                //new StartActionViewModel
                //{
                //    Moniker=KnownMonikers.GoToNext,
                //    Name = "Continue without code",
                //    Description = "Close the Start Page and continue without any code"
                //}
            };

            Commands = new ObservableCollection<CommandViewModel>
            {
                new CommandViewModel
                {
                    Name = "Continue With No Code",
                    Command = new RelayCommand(ExecuteContinue, CanExecuteContinue)
                }
            };
        }

        public ObservableCollection<StartActionViewModel> StartActions { get; set; }

        private bool CanExecuteContinue()
            => true;

        private void ExecuteContinue()
        { }

    }
}