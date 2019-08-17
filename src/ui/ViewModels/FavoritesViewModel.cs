using Luminous.Code.VisualStudio.Packages;

namespace StartPagePlus.UI.ViewModels
{
    using Options.Pages;

    public class FavoritesViewModel : TabViewModel
    {
        private static GeneralDialogPage generalOptions;

        public FavoritesViewModel()
        {
            Name = "Favorites";
            IsVisible = true;
        }

        public static GeneralDialogPage GeneralOptions
            => generalOptions ?? (generalOptions = AsyncPackageBase.GetDialogPage<GeneralDialogPage>());
    }

}