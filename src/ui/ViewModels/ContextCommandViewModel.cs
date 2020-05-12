using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.ViewModels
{
    public class ContextCommandViewModel : CommandViewModel
    {
        private ImageMoniker moniker;

        public ImageMoniker Moniker
        {
            get => moniker;
            set => Set(ref moniker, value);
        }
    }
}