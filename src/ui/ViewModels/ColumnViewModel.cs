using GalaSoft.MvvmLight;

namespace StartPagePlus.UI.ViewModels
{
    using Observables;

    public class ColumnViewModel : ViewModelBase
    {
        private bool isVisible = true;

        public string Heading { get; set; }

        public bool IsVisible
        {
            get => isVisible;
            set => Set(ref isVisible, value);
        }

        public ObservableCommandList Commands { get; set; }
    }
}