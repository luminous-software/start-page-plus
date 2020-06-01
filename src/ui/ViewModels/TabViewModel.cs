using GalaSoft.MvvmLight;

namespace StartPagePlus.UI.ViewModels
{
    public class TabViewModel : ViewModelBase
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public bool IsVisible { get; set; }
    }
}