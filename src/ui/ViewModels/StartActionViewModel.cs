using GalaSoft.MvvmLight;
using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    public class StartActionViewModel : ViewModelBase, IStartAction
    {
        public ImageMoniker Moniker { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsVisible { get; set; }
    }
}