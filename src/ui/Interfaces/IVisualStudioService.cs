namespace StartPagePlus.UI.Interfaces
{
    public interface IVisualStudioService
    {
        void ExecuteCommand(string Action);

        void ShowMessage(string message);

        void NavigateTo(string url, bool internalBrowser);
    }
}