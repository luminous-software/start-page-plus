namespace StartPagePlus.UI.Interfaces
{
    public interface IStartActionClickService
    {
        bool CloneOrCheckoutCode();

        bool CreateNewProject();

        bool OpenFolder();

        bool OpenProject();

        bool RestartVisualStudio(bool confirm, bool elevated);

        bool OpenWebPage(string url, bool openInVS);
    }
}