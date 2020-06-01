using Luminous.Code.VisualStudio.Commands;
using Luminous.Code.VisualStudio.Packages;

using Microsoft.VisualStudio.Shell;

using Tasks = System.Threading.Tasks;

namespace StartPagePlus.Commands
{
    using Options.Models;
    using Options.Pages;

    internal sealed class StartPagePlusOptions : StartPagePlusCommand
    {
        private StartPagePlusOptions(AsyncPackageBase package)
            : base(package, PackageIds.StartPagePlusOptions)
        { }

        public static async Tasks.Task InstantiateAsync(AsyncPackageBase package)
            => await InstantiateAsync(new StartPagePlusOptions(package));

        protected override bool CanExecute
          => base.CanExecute && GeneralOptions.Instance.EnableStartPagePlusOptions;

        protected override void OnExecute(OleMenuCommand command)
            => ExecuteCommand()
                .ShowProblem();

        private CommandResult ExecuteCommand()
            => Package?.ShowOptionsPage<DialogPageProvider.General>();
    }
}