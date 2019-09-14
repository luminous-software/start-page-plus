using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.Interfaces
{
    public interface IStartAction
    {
        ImageMoniker Moniker { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        bool IsVisible { get; set; }

        bool DoAction();
    }
}