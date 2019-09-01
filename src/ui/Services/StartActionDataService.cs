using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.Services
{
    using Interfaces;
    using ViewModels;

    public class StartActionDataService : IStartActionDataService
    {
        public StartActionDataService()
        { }

        public ObservableCollection<StartActionViewModel> GetItems()
        {
            var items = new ObservableCollection<StartActionViewModel>
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
                }
            };

            return items;
        }
    }
}