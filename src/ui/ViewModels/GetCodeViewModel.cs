using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class GetCodeViewModel : StartActionViewModel
    {
        public GetCodeViewModel(IStartActionClickService clickService) : base(clickService)
        {
            Moniker = KnownMonikers.DownloadNoColor; // SourceControl
            Name = "Clone or checkout code";
            Description = "Get code from an online repository like GitHub or Azure DevOps etc";
        }

        protected override void ExecuteClick()
            => ClickService.CloneOrCheckoutCode();
    }
}