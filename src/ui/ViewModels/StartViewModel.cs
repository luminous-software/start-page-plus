using Luminous.Code.VisualStudio.Packages;

namespace StartPagePlus.UI.ViewModels
{
    using Options.Pages;

    public class StartViewModel : TabViewModel
    {
        private static GeneralDialogPage generalOptions;

        public StartViewModel()
        {
            Name = "Start";
            IsVisible = true;
            //Models = new ObservableCollection<IModel>
            //{
            //    new StartModel
            //    {
            //        Name ="Start",
            //        IsVisible =true
            //    },
            //    new FavoritesModel{
            //        Name ="Favorites",
            //        IsVisible =true
            //    },
            //    new CreateModel{
            //        Name ="Create",
            //        IsVisible =true
            //    },
            //    new NewsModel{
            //        Name ="News",
            //        IsVisible =true
            //    }
            //};
        }

        public static GeneralDialogPage GeneralOptions
            => generalOptions ?? (generalOptions = AsyncPackageBase.GetDialogPage<GeneralDialogPage>());

        //public ObservableCollection<IModel> Models { get; }
    }

}