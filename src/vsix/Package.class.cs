using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Tasks = System.Threading.Tasks;

namespace StartPagePlus
{
    using Luminous.Code.VisualStudio.Packages;
    using Options.Pages;
    using static Core.StringConstants;
    using static PackageGuids;
    using static Vsix;

    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]

    [InstalledProductRegistration(Name, Description, Version)]
    [Guid(PackageString)]

    [ProvideOptionPage(typeof(GeneralDialogPage), Name, General, 0, 0, supportsAutomation: true)]

    public sealed class PackageClass : AsyncPackageBase
    {
        public PackageClass() : base(PackageCommandSet, Vsix.Name, Vsix.Description)
        {
        }

        protected override async Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) => await base.InitializeAsync(cancellationToken, progress);//await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
    }
}