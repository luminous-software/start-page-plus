using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Luminous.Code.VisualStudio.Packages;
using Microsoft.Win32;

namespace StartPagePlus.UI.ViewModels.MainControl
{
    using Core.Interfaces;
    using Options.Pages;

    public class MainControlViewModel : ViewModelBase
    {
        private static GeneralDialogPage generalOptions;

        public static GeneralDialogPage GeneralOptions
            => generalOptions ?? (generalOptions = AsyncPackageBase.GetDialogPage<GeneralDialogPage>());

        public ObservableCollection<ITabPage> Pages { get; }
        public static RegistryKey RegistryRoot { get; set; }

    }
}