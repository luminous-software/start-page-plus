using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;

using Luminous.Code.VisualStudio.Packages;

namespace StartPagePlus.UI.ViewModels
{
    using Options.Models;

    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Company = "Luminous Software Solutions";
            IsVisible = false;
            Tabs = new ObservableCollection<TabViewModel>
            {
                new StartViewModel(),
                new FavoritesViewModel(),
                new CreateViewModel(),
                new NewsViewModel()
            };
        }

        public string Company { get; }

        public bool IsVisible { get; }

        public static AsyncPackageBase Package { get; set; }

        public ObservableCollection<TabViewModel> Tabs { get; }

        public int MaxWidth
            => GeneralOptions.Instance.MaxWidth;
    }

}