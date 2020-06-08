namespace StartPagePlus.UI.Interfaces
{
    public interface IVisualStudioService
    {
        bool ExecuteCommand(string action);

        bool ExecuteCommand(string action, string path);

        bool OpenWebPage(string url, bool internalBrowser);

        bool CloneRepository();

        bool OpenFolder(string path);

        bool OpenFolder();

        bool OpenProject(string path);

        bool OpenProject();

        bool CreateNewProject();

        bool RestartVisualStudio(bool confirm = true, bool elevated = false);

        bool OpenProjectOrSolutionInVS(string path);

        bool OpenFolderInVS(string path);
    }
}