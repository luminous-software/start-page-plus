using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public abstract class StartActionViewModel : ViewModelBase
    {
        public StartActionViewModel(IStartActionClickService clickService)
        {
            ClickService = clickService;
            ClickCommand = new RelayCommand(ExecuteClick, true);
            ImageSize = 40;
            Margin = "5,5,0,0";
            IsEnabled = true;
        }

        public ImageMoniker Moniker { get; set; }

        public int ImageSize { get; set; }

        public string Margin { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsVisible { get; set; }

        public bool IsEnabled { get; set; }

        public ICommand ClickCommand { get; set; }

        public IStartActionClickService ClickService { get; }

        protected virtual void ExecuteClick()
        { }
    }
}