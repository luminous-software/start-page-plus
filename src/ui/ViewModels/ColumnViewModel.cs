using GalaSoft.MvvmLight;

namespace StartPagePlus.UI.ViewModels
{
    using Observables;

    public class ColumnViewModel : ViewModelBase
    {
        private bool isVisible = true;
        private ObservableContextCommandList contextCommands;

        public string Heading { get; set; }

        public bool IsVisible
        {
            get => isVisible;
            set => Set(ref isVisible, value);
        }

        public ObservableCommandList Commands { get; set; }

        public ObservableContextCommandList ContextCommands
        {
            get => contextCommands;
            set
            {
                if (Set(ref contextCommands, value, nameof(ContextCommands)))
                {
                    RaiseCanExecuteChanged();
                };
            }
        }

        protected virtual void RaiseCanExecuteChanged()
        { }
    }
}