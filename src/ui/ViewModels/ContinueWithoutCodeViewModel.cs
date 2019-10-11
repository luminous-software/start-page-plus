using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class ContinueWithoutCodeViewModel : StartActionViewModel
    {
        public ContinueWithoutCodeViewModel(IVisualStudioService service) : base(service)
        {
            Moniker = KnownMonikers.GoToNext;
            Name = "Continue without code";
            Description = "Close this page, and continue without code";
        }

        protected override void ExecuteClick()
            => VisualStudioService.ShowMessage("This will close the start page in a future version of Start Page+");
    }
}