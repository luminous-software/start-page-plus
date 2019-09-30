using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public abstract class StartActionViewModel : ViewModelBase
    {
        public StartActionViewModel(IVisualStudioService vsService)
        {
            ClickCommand = new RelayCommand(ExecuteClick, true);
            VisualStudioService = vsService;
        }

        public ImageMoniker Moniker { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsVisible { get; set; }

        public ICommand ClickCommand { get; set; }

        public IVisualStudioService VisualStudioService { get; }

        protected virtual void ExecuteClick()
        { }
    }
}