using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Luminous.Code.VisualStudio.Packages;
using Microsoft.Win32;

namespace StartPagePlus.UI.ViewModels
{
    using Options.Pages;

    public class MainViewModel : ViewModelBase
    {
        private static GeneralDialogPage generalOptions;

        public MainViewModel()
        {
            Company = "Luminous Software Solutions";
            IsVisible = false;
            Models = new ObservableCollection<TabViewModel>
            {
                new StartViewModel(),
                new FavoritesViewModel(),
                new CreateViewModel(),
                new NewsViewModel()
            };
        }

        public static GeneralDialogPage GeneralOptions
            => generalOptions ?? (generalOptions = AsyncPackageBase.GetDialogPage<GeneralDialogPage>());

        public string Company { get; }

        public bool IsVisible { get; }

        public ObservableCollection<TabViewModel> Models { get; }

        public static RegistryKey RegistryRoot { get; set; }
    }

}