namespace StartPagePlus.Core.Interfaces
{
    public interface INewsItemActionService
    {
        void OpenItem(string url, bool InternalBrowser = true);
    }
}