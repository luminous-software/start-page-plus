using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class RestartNormalViewModel : StartActionViewModel
    {
        public RestartNormalViewModel(IVisualStudioService vsService) : base(vsService)
        {
            Moniker = KnownMonikers.Restart;
            Name = "Restart Visual Studio";
            Description = "Restart Visual Studio and come back to the same project";
            ImageSize = 34;
            Margin = "11,0,0,0";
        }

        protected override void ExecuteClick()
            => VisualStudioService.RestartVisualStudio(confirm: true, elevated: false);
    }
}