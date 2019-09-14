using System.Windows.Input;
using GalaSoft.MvvmLight;

namespace StartPagePlus.UI.ViewModels
{
    public class CommandViewModel : ViewModelBase
    {
        public string Name { get; set; }

        public ICommand Command { get; set; }

        public bool IsVisible { get; set; } = true;

        public bool Enabled { get; set; } = true;
    }
}