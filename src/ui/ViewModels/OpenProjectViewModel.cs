using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class OpenProjectViewModel : StartActionViewModel
    {
        public OpenProjectViewModel(IStartActionClickService clickService) : base(clickService)
        {
            Moniker = KnownMonikers.OpenTopic;  // OpenDocumentGroup missing from KnownMonikers in SDK v15.9.3
            Name = "Open a project or solution";
            Description = "Open a local Visual Studio project or a '.sln' file";
        }

        protected override void ExecuteClick()
            => ClickService.OpenProject();
    }
}