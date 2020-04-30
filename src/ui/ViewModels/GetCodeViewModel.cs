using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class GetCodeViewModel : StartActionViewModel
    {
        public GetCodeViewModel(IVisualStudioService vsService) : base(vsService)
        {
            Moniker = KnownMonikers.DownloadNoColor; // SourceControl
            Name = "Clone or checkout code";
            Description = "Get code from an online repository like GitHub or Azure DevOps";
        }

        protected override void ExecuteClick()
            => VisualStudioService.CloneOrCheckoutCode();
    }
}