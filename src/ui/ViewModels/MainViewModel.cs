using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;

using Microsoft.Win32;

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

        public static RegistryKey RegistryRoot { get; set; }

        public ObservableCollection<TabViewModel> Tabs { get; }

        public int MaxWidth
            => SettingOptions.Instance.MaxWidth;
    }

}