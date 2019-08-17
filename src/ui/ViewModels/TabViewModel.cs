using GalaSoft.MvvmLight;
using Luminous.Code.VisualStudio.Packages;

namespace StartPagePlus.UI.ViewModels
{
    using Options.Pages;

    public class TabViewModel : ViewModelBase
    {
        private static GeneralDialogPage generalOptions;

        public string Name { get; set; }

        public bool IsVisible { get; set; }

        public static GeneralDialogPage GeneralOptions
            => generalOptions ?? (generalOptions = AsyncPackageBase.GetDialogPage<GeneralDialogPage>());
    }
}