using GalaSoft.MvvmLight;
using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.ViewModels
{
    public class StartActionViewModel : ViewModelBase
    {
        public ImageMoniker Moniker { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsVisible { get; set; }
    }
}