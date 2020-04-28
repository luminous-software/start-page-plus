using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

using Luminous.Code.Extensions.ExceptionExtensions;
using Luminous.Code.VisualStudio.Commands;
using Luminous.Code.VisualStudio.Packages;

using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

using Tasks = System.Threading.Tasks;

namespace StartPagePlus
{
    using Commands;

    using Options.Pages;

    using UI;
    using UI.ViewModels;

    using static PackageGuids;
    using static Vsix;

    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]

    [InstalledProductRegistration(Name, Description, Version)]
    [Guid(PackageString)]
    [DisplayName("Start Page+")]

    [ProvideOptionPage(typeof(DialogPageProvider.General), Name, nameof(DialogPageProvider.General), 0, 0, supportsAutomation: true)]
    [ProvideOptionPage(typeof(DialogPageProvider.Features), Name, nameof(DialogPageProvider.Features), 0, 0, supportsAutomation: true)]
    [ProvideOptionPage(typeof(DialogPageProvider.Settings), Name, nameof(DialogPageProvider.Settings), 0, 0, supportsAutomation: true)]
    [ProvideToolWindow(typeof(StartPagePlusWindow), Style = VsDockStyle.Tabbed, Window = "DocumentWell", MultiInstances = false)]

    public sealed class PackageClass : AsyncPackageBase
    {
        public PackageClass() : base(PackageCommandSet, Name, Description)
            => _ = new ViewModelLocator();

        protected override async Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);
            await ViewStartPagePlus.InstantiateAsync(this);
            await StartPagePlusOptions.InstantiateAsync(this);

            //await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
        }

        protected override async Tasks.Task<object> InitializeToolWindowAsync(Type toolWindowType, int id, CancellationToken cancellationToken)
        {
            await base.InitializeToolWindowAsync(toolWindowType, id, cancellationToken);

            // any potentially expensive work, preferably done on a background thread where possible

            return UserRegistryRoot; // this is passed to the tool window constructor
        }

        public override IVsAsyncToolWindowFactory GetAsyncToolWindowFactory(Guid toolWindowType)
            => (toolWindowType == typeof(StartPagePlusWindow).GUID)
                ? this
                : null; //base.GetAsyncToolWindowFactory(toolWindowType);

        //TODO: is GetToolWindowTitle REALLY necessary?
        protected override string GetToolWindowTitle(Type toolWindowType, int id)
            => (toolWindowType == typeof(StartPagePlusWindow))
                ? $"{Vsix.Name}"
                : base.GetToolWindowTitle(toolWindowType, id);

        public static CommandResult ShowToolWindow<T>(CancellationToken cancellationToken, string problem = null)
            where T : ToolWindowPane
        {
            try
            {
                Instance.JoinableTaskFactory.RunAsync(async delegate
                {
                    var window = await Instance.ShowToolWindowAsync(typeof(T), 0, true, cancellationToken);
                    if ((null == window) || (null == window.Frame))
                    {
                        throw new NotSupportedException("Cannot create tool window");
                    }

                    await Instance.JoinableTaskFactory.SwitchToMainThreadAsync();

                    var windowFrame = (IVsWindowFrame)window.Frame;
                    ErrorHandler.ThrowOnFailure(windowFrame.Show());
                });

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ProblemResult(problem ?? ex.ExtendedMessage());
            }
        }

        public static CommandResult ShowToolWindow(Type type, string problem = null)
        {
            try
            {
                Instance.JoinableTaskFactory.RunAsync(async delegate
                {
                    var window = await Instance.ShowToolWindowAsync(type, 0, true, Instance.DisposalToken);
                    if ((null == window) || (null == window.Frame))
                    {
                        throw new NotSupportedException("Cannot create tool window");
                    }

                    await Instance.JoinableTaskFactory.SwitchToMainThreadAsync();

                    var windowFrame = (IVsWindowFrame)window.Frame;
                    ErrorHandler.ThrowOnFailure(windowFrame.Show());
                });

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ProblemResult(problem ?? ex.ExtendedMessage());
            }
        }
    }
}
