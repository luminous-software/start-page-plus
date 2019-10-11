using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class OpenProjectViewModel : StartActionViewModel
    {
        public OpenProjectViewModel(IVisualStudioService vsService) : base(vsService)
        {
            Moniker = KnownMonikers.OpenTopic;  // OpenDocumentGroup missing from KnownMonikers in SDK v15.9.3
            Name = "Open a project or solution";
            Description = "Open a local Visual Studio project or a .sln file";
        }

        protected override void ExecuteClick()
            => VisualStudioService.OpenProject();
    }
}