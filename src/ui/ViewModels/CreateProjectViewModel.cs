using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class CreateProjectViewModel : StartActionViewModel
    {
        public CreateProjectViewModel(IStartActionClickService clickService) : base(clickService)
        {
            Moniker = KnownMonikers.AddDocument;  // AddDocumentGroup missing from KnownMonikers in SDK v15.9.3
            Name = "Create a new project";
            Description = "Choose a project template with code scaffolding to get started";
        }

        protected override void ExecuteClick()
            => ClickService.CreateNewProject();
    }
}