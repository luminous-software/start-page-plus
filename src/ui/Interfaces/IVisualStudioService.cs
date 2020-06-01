namespace StartPagePlus.UI.Interfaces
{
    public interface IVisualStudioService
    {
        bool ExecuteCommand(string action, string path);

        bool OpenWebPage(string url, bool internalBrowser);

        bool OpenFolder(string path);

        bool OpenFolder();

        bool OpenProject(string path);

        bool OpenProject();

        void CreateNewProject();

        void CloneOrCheckoutCode();

        void RestartVisualStudio(bool confirm = true, bool elevated = false);

        public bool OpenProjectOrSolutionInVS(string path);
        bool OpenFolderInVS(string path);
    }
}