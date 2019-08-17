using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Luminous.Code.VisualStudio.Packages;
using Microsoft.Win32;

namespace StartPagePlus.UI.ViewModels
{
    using Core.Interfaces;
    using Models;
    using Options.Pages;

    public class MainViewModel : ViewModelBase
    {
        private static GeneralDialogPage generalOptions;

        public MainViewModel()
        {
            Company = "Luminous Software Solutions";
            IsVisible = true;
            Models = new ObservableCollection<IModel>
            {
                new StartModel
                {
                    Name ="Start",
                    IsVisible =true
                },
                new FavoritesModel{
                    Name ="Favorites",
                    IsVisible =true
                },
                new CreateModel{
                    Name ="Create",
                    IsVisible =true
                },
                new NewsModel{
                    Name ="News",
                    IsVisible =true
                }
            };
        }

        public static GeneralDialogPage GeneralOptions
            => generalOptions ?? (generalOptions = AsyncPackageBase.GetDialogPage<GeneralDialogPage>());

        public string Company { get; }
        public bool IsVisible { get; }
        public ObservableCollection<IModel> Models { get; }
        public static RegistryKey RegistryRoot { get; set; }
    }

}