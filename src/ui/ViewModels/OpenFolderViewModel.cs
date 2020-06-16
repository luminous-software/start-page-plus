using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class OpenFolderViewModel : StartActionViewModel
    {
        public OpenFolderViewModel(IStartActionClickService clickService) : base(clickService)
        {
            Moniker = KnownMonikers.OpenFolder;
            Name = "Open a local folder";
            Description = "Navigate and edit code within any folder on your machine or network";
        }

        protected override void ExecuteClick()
            => ClickService.OpenFolder();
    }
}