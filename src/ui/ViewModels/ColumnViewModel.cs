using GalaSoft.MvvmLight;
using Luminous.Code.VisualStudio.Packages;

namespace StartPagePlus.UI.ViewModels
{
    using System.Collections.ObjectModel;
    using Options.Pages;

    public class ColumnViewModel : ViewModelBase
    {
        private static GeneralDialogPage generalOptions;

        public string Heading { get; set; }

        public bool IsVisible { get; set; }

        public static GeneralDialogPage GeneralOptions
            => generalOptions ?? (generalOptions = AsyncPackageBase.GetDialogPage<GeneralDialogPage>());

        public ObservableCollection<CommandViewModel> Commands { get; set; }

    }
}