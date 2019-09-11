using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    public class OpenFolderViewModel : StartActionViewModel
    {
        public OpenFolderViewModel()
        {
            Moniker = KnownMonikers.OpenFolder;
            Name = "Open a local folder";
            Description = "Navigate and edit code within any folder";
        }

        protected override void ExecuteClick()
            => Dte?.ExecuteCommand("File.OpenFolder");
    }
}