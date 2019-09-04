using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    public class CreateProjectViewModel : StartActionViewModel
    {
        public CreateProjectViewModel()
        {
            Moniker = KnownMonikers.AddDocumentGroup;
            Name = "Create a new project";
            Description = "Choose a project template with code scaffolding to get started";
        }
    }
}