namespace StartPagePlus.UI.Interfaces
{
    public interface IStartActionClickService
    {
        bool OpenWebPage(string url, bool openInVS);

        bool CreateNewProject();

        bool CloneOrCheckoutCode();

        bool OpenFolder();

        bool OpenProject();

        bool RestartVisualStudio(bool confirm, bool elevated);
    }
}