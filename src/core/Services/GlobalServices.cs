using EnvDTE;

using EnvDTE80;

using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

using IServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace StartPagePlus.Core.Services
{
    public static class GlobalServices
    {
        public static IVsActivityLog ActivityLog
            => GetGlobalService<SVsActivityLog, IVsActivityLog>();

        public static IComponentModel ComponentModel
            => GetGlobalService<SComponentModel, IComponentModel>();

        public static DTE DTE
            => GetGlobalService<SDTE, DTE>();

        public static DTE2 DTE2
            => (DTE2)DTE;

        public static IVsFontAndColorStorage3 FontAndColorStorage3
            => GetGlobalService<SVsFontAndColorStorage, IVsFontAndColorStorage3>();

        public static IVsFontAndColorUtilities FontAndColorUtilities
            => GetGlobalService<SVsFontAndColorStorage, IVsFontAndColorUtilities>();

        public static IVsGlobalSearch GlobalSearch
            => GetGlobalService<SVsGlobalSearch, IVsGlobalSearch>();

        public static IVsImageService ImageService
            => GetGlobalService<SVsImageService, IVsImageService>();

        public static IVsMonitorSelection MonitorSelection
            => GetGlobalService<SVsShellMonitorSelection, IVsMonitorSelection>();

        public static IVsMonitorUserContext MonitorUserContext
            => GetGlobalService<SVsMonitorUserContext, IVsMonitorUserContext>();

        public static IVsMRUItemsStore MRUItemsStore
            => GetGlobalService<SVsMRUItemsStore, IVsMRUItemsStore>();

        public static IVsNavigateToService NavigateToService
            => GetGlobalService<SVsNavigateToService, IVsNavigateToService>();

        public static IVsProfileDataManager ProfileDataManager
            => GetGlobalService<SVsProfileDataManager, IVsProfileDataManager>();

        public static IVsRunningDocumentTable RunningDocumentTable
            => GetGlobalService<SVsRunningDocumentTable, IVsRunningDocumentTable>();

        public static IServiceProvider ServiceProvider
            => GetGlobalService<IServiceProvider, IServiceProvider>();

        public static IVsSettingsManager SettingsManager
            => GetGlobalService<SVsSettingsManager, IVsSettingsManager>();

        public static IVsShell VsShell
            => GetGlobalService<SVsShell, IVsShell>();

        public static IVsShell3 VsShell3
            => (IVsShell3)VsShell;

        public static IVsShell4 VsShell4
            => (IVsShell4)VsShell;

        public static IVsShell5 VsShell5
            => (IVsShell5)VsShell;

        public static IVsSolution Solution
            => GetGlobalService<SVsSolution, IVsSolution>();

        public static IVsSolutionBuildManager SolutionBuildManager
            => GetGlobalService<SVsSolutionBuildManager, IVsSolutionBuildManager>();

        public static IVsSolutionPersistence SolutionPersistence
            => GetGlobalService<SVsSolutionPersistence, IVsSolutionPersistence>();

        public static IVsStatusbar StatusBar
            => GetGlobalService<SVsStatusbar, IVsStatusbar>();

        public static IVsUIShell UiShell
            => GetGlobalService<SVsUIShell, IVsUIShell>();

        public static IVsUIShell2 UiShell2
            => (IVsUIShell2)UiShell;

        public static IVsUIShell4 UiShell4
            => (IVsUIShell4)UiShell;

        private static TInterface GetGlobalService<TService, TInterface>()
            where TInterface : class
            => (TInterface)(Package.GetGlobalService(typeof(TService)) as TInterface);
    }
}