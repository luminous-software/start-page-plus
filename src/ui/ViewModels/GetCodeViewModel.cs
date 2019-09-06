using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    public class GetCodeViewModel : StartActionViewModel
    {
        public GetCodeViewModel()
        {
            Moniker = KnownMonikers.DownloadNoColor;
            Name = "Clone or checkout code";
            Description = "Get code from an online repository like GitHub or Azure DevOps";

        }

        protected override void ExecuteAction()
            => Dte?.ExecuteCommand("File.Cloneorcheckoutcode");
    }
}