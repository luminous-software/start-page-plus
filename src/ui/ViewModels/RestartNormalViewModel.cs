using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class RestartNormalViewModel : StartActionViewModel
    {
        public RestartNormalViewModel(IVisualStudioService vsService) : base(vsService)
        {
            Moniker = KnownMonikers.VisualStudio;
            Name = "Restart Visual Studio";
            Description = "Restart Visual Studio and come back to the same project";
            ImageSize = 32;
            Margin = "10,0,0,0";
        }

        protected override void ExecuteClick()
            => VisualStudioService.RestartVisualStudio(confirm: true, elevated: false);
    }
}