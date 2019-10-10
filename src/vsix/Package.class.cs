﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using EnvDTE;
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
    using static Core.Constants.StringConstants;
    using static PackageGuids;
    using static Vsix;

    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]

    [InstalledProductRegistration(Name, Description, Version)]
    [Guid(PackageString)]

    [ProvideOptionPage(typeof(GeneralDialogPage), Name, General, 0, 0, supportsAutomation: true)]
    [ProvideToolWindow(typeof(StartPagePlusWindow), Style = VsDockStyle.Tabbed, Window = "E13EEDEF-B531-4afe-9725-28A69FA4F896", MultiInstances = false)]

    public sealed class PackageClass : AsyncPackageBase
    {
        private static GeneralDialogPage generalOptions;

        public static GeneralDialogPage GeneralOptions
                    => generalOptions ?? (generalOptions = GetDialogPage<GeneralDialogPage>());

        public PackageClass() : base(PackageCommandSet, Name, Description)
            => _ = new ViewModelLocator();

        protected override async Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);
            await ViewStartPagePlus.InstantiateAsync(this);
            await StartPagePlusOptions.InstantiateAsync(this);

            this.SolutionEvents = Dte.Events.SolutionEvents;
            SolutionEvents.Opened += OnSolutionOpened;
            SolutionEvents.AfterClosing += SolutionEventsOnAfterClosing;
        }

        public EnvDTE.SolutionEvents SolutionEvents { get; set; }

        private bool _isExiting;

        private async void OnSolutionOpened()
        {
            if (GeneralOptions.AutomaticallyCloseOnSolutionOpen)
            {
                var toolWindow = await Instance.FindToolWindowAsync(typeof(StartPagePlusWindow), 0, false, Instance.DisposalToken);
                JoinableTaskFactory.Run(async delegate
                {
                    await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
                    var windowPane = toolWindow.GetIVsWindowPane() as StartPagePlusWindow;
                    (windowPane?.Frame as IVsWindowFrame)?.Hide();
                });
            }
        }

        private async void SolutionEventsOnAfterClosing()
        {
            if (GeneralOptions.AutomaticallyCloseOnSolutionOpen)
            {
                var toolWindow = await Instance.FindToolWindowAsync(typeof(StartPagePlusWindow), 0, false, Instance.DisposalToken);
                JoinableTaskFactory.Run(async delegate
                {
                    await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
                    var windowPane = toolWindow.GetIVsWindowPane() as StartPagePlusWindow;
                    (windowPane?.Frame as IVsWindowFrame)?.ShowNoActivate();
                });
            }
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
