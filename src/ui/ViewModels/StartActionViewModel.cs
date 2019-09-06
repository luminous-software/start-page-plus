using System.Windows.Input;
using EnvDTE;
using EnvDTE80;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.VisualStudio.Imaging.Interop;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.ViewModels
{
    public abstract class StartActionViewModel : ViewModelBase
    {
        private static DTE2 dte;

        public StartActionViewModel()
            => ActionCommand = new RelayCommand(ExecuteAction, true);

        public ImageMoniker Moniker { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsVisible { get; set; }

        protected DTE2 Dte = dte ?? (dte = Package.GetGlobalService(typeof(_DTE)) as DTE2);

        public ICommand ActionCommand { get; set; }

        protected virtual void ExecuteAction()
        { }
    }
}