namespace StartPagePlus.UI.Services
{
    using Interfaces;

    public class StartActionClickService : IStartActionClickService
    {
        public StartActionClickService(IVisualStudioService visualStudioService)
            => VisualStudioService = visualStudioService;

        private IVisualStudioService VisualStudioService { get; }

        public bool CloneOrCheckoutCode()
            => VisualStudioService.CloneOrCheckoutCode();

        public bool CreateNewProject()
            => VisualStudioService.CreateNewProject();

        public bool OpenFolder()
            => VisualStudioService.OpenFolder();

        public bool OpenProject()
            => VisualStudioService.OpenProject();

        public bool RestartVisualStudio(bool confirm, bool elevated)
            => VisualStudioService.RestartVisualStudio(confirm, elevated);

        public bool OpenWebPage(string url, bool openInVS)
            => VisualStudioService.OpenWebPage(url, openInVS);
    }
}