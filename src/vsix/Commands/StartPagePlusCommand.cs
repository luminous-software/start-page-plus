using Luminous.Code.VisualStudio.Commands;
using Luminous.Code.VisualStudio.Packages;
namespace StartPagePlus.Commands
{
    using Options.Models;

    internal abstract class StartPagePlusCommand : AsyncDynamicCommand
    {
        protected StartPagePlusCommand(AsyncPackageBase package, int id) : base(package, id)
        { }

        protected override bool CanExecute
           => base.CanExecute && GeneralOptions.Instance.EnableStartPagePlus;
    }
}