using System.Windows.Input;

namespace StartPagePlus.Core.Interfaces
{
    public interface ITabPage
    {
        string Name { get; set; }
        ICommand ClickCommand { get; }
    }
}