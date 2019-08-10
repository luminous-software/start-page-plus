namespace StartPagePlus.Commands
{
    using Luminous.Code.VisualStudio.Commands;
    using Luminous.Code.VisualStudio.Packages;

    internal abstract class StartPagePlusCommand : AsyncDynamicCommand
    {
        protected StartPagePlusCommand(AsyncPackageBase package, int id) : base(package, id)
        { }

        protected override bool CanExecute
           => base.CanExecute && PackageClass.GeneralOptions.EnableStartPagePlus;
    }
}