using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    public class OpenProjectViewModel : StartActionViewModel
    {
        public OpenProjectViewModel()
        {
            Moniker = KnownMonikers.OpenDocumentGroup;
            Name = "Open a project or solution";
            Description = "Open a local Visual Studio project or a .sln file";
        }

        protected override void ExecuteClick()
            => Dte?.ExecuteCommand("File.OpenProject");
    }
}