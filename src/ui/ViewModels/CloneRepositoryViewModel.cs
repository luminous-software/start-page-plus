using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class CloneRepositoryViewModel : StartActionViewModel
    {
        public CloneRepositoryViewModel(IStartActionClickService clickService) : base(clickService)
        {
            Moniker = KnownMonikers.DownloadNoColor; // SourceControl
            Name = "Clone a repository";
            Description = "Get code from an online repository like GitHub or Azure DevOps etc";
        }

        protected override void ExecuteClick()
            => ClickService.CloneRepository();
    }
}