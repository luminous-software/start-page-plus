using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class RestartElevatedViewModel : StartActionViewModel
    {
        public RestartElevatedViewModel(IVisualStudioService vsService) : base(vsService)
        {
            Moniker = KnownMonikers.VisualStudioExpressWindowsPhone;
            Name = "Restart As Administrator";
            Description = "Restart an elevated Visual Studio session";
            ImageSize = 36;
            Margin = "10,0,0,0";
        }

        protected override void ExecuteClick()
            => VisualStudioService.RestartVisualStudio(confirm: true, elevated: true);
    }
}