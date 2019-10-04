using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class OpenFolderViewModel : StartActionViewModel
    {
        public OpenFolderViewModel(IVisualStudioService vsService) : base(vsService)
        {
            Moniker = KnownMonikers.OpenFolder;
            Name = "Open a local folder";
            Description = "Navigate and edit code within any folder";
        }

        protected override void ExecuteClick()
            => VisualStudioService.OpenFolder();
    }
}