using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.Services
{
    using Interfaces;
    using ViewModels;

    public class StartActionActionService : IStartActionActionService
    {
        public void DoAction(StartActionViewModel currentViewModel)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            switch (currentViewModel.Name)
            {
                default:
                    break;
            }
        }
    }
}