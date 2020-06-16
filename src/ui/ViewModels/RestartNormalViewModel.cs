using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class RestartNormalViewModel : StartActionViewModel
    {
        public RestartNormalViewModel(IStartActionClickService clickService) : base(clickService)
        {
            Moniker = KnownMonikers.Restart;
            Name = "Restart Visual Studio";
            Description = "Restart Visual Studio with one click";
            ImageSize = 34;
            Margin = "11,5,0,0";
        }

        protected override void ExecuteClick()
            => ClickService.RestartVisualStudio(confirm: true, elevated: false);
    }
}