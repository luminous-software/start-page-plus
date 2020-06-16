using Luminous.Code.VisualStudio.Commands;
using Luminous.Code.VisualStudio.Packages;

using Microsoft.VisualStudio.Shell;

using Tasks = System.Threading.Tasks;

namespace StartPagePlus.Commands
{
    using Options.Models;

    using UI.ToolWindows;

    internal sealed class ViewStartPagePlus : StartPagePlusCommand
    {
        private ViewStartPagePlus(AsyncPackageBase package)
            : base(package, PackageIds.ViewStartPagePlus)
        { }

        public static async Tasks.Task InstantiateAsync(AsyncPackageBase package)
            => await InstantiateAsync(new ViewStartPagePlus(package));

        protected override bool CanExecute
          => base.CanExecute && GeneralOptions.Instance.EnableStartPagePlus;

        protected override void OnExecute(OleMenuCommand command)
            => ExecuteCommand()
                .ShowProblem();

        private CommandResult ExecuteCommand()
            => PackageClass.ShowToolWindow<StartPagePlusToolWindow>(Package.DisposalToken);
    }
}