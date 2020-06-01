using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class RestartElevatedViewModel : StartActionViewModel
    {
        public RestartElevatedViewModel(IVisualStudioService vsService) : base(vsService)
        {
            Moniker = KnownMonikers.User;
            Name = "Restart As Administrator";
            Description = "Restart in an elevated Visual Studio session";
            ImageSize = 34;
            Margin = "11,5,0,0";
        }

        protected override void ExecuteClick()
            => VisualStudioService.RestartVisualStudio(confirm: true, elevated: true);
    }
}