using System;
using System.IO;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.Enums
{
    public static class RecentItemTypes
    {
        public static RecentItemType CalculateRecentItemType(this string instance)
        {
            if (instance is null)
                throw new ArgumentException("Recent item type can't be calculated from a null string");

            if (instance == "")
                throw new ArgumentException("Recent item type can't be calculated from an empty string");

            var ext = Path.GetExtension(instance).TrimStart(new char[] { '.' });

            return ext switch
            {
                "" => RecentItemType.Folder,

                "sln" => RecentItemType.Solution,

                "vcxproj" => RecentItemType.CPlusPlusProject,

                "vcxitems" => RecentItemType.CPlusPlusSharedProject,

                "csproj" => RecentItemType.CSharpProject,

                "shproj" => RecentItemType.CSharpSharedProject,

                // "dbproj" => RecentItemType.DatabaseProject,

                "fsproj" => RecentItemType.FSharpProject,

                "jsproj" => RecentItemType.JavascriptProject,

                // "njsproj" => RecentItemType.NodejsProject,

                "pyproj" => RecentItemType.PythonProject,

                "tsproj" => RecentItemType.TypeScriptProject,

                "vbproj" => RecentItemType.VisualBasicProject,

                _ => RecentItemType.Unknown,
            };
        }

        public static ImageMoniker ToImageMoniker(this RecentItemType itemType)
        {
            return itemType switch
            {
                RecentItemType.Unknown => KnownMonikers.QuestionMark,

                RecentItemType.Folder => KnownMonikers.FolderOpened,

                RecentItemType.Solution => KnownMonikers.Solution,

                RecentItemType.CSharpProject => KnownMonikers.CSProjectNode,

                RecentItemType.CSharpSharedProject => KnownMonikers.CSSharedProject,

                RecentItemType.CPlusPlusProject => KnownMonikers.CPPProjectNode,

                RecentItemType.CPlusPlusSharedProject => KnownMonikers.CPPSharedProject,

                // RecentItemType.DatabaseProject => KnownMonikers.Database,

                RecentItemType.FSharpProject => KnownMonikers.FSProjectNode,

                RecentItemType.JavascriptProject => KnownMonikers.JSProjectNode,

                RecentItemType.JavascriptSharedProject => KnownMonikers.JSSharedProject,

                // RecentItemType.NodeJsProject => return KnownMonikers.NodejsProject;

                RecentItemType.PythonProject => KnownMonikers.PYProjectNode,

                RecentItemType.SharedProject => KnownMonikers.SharedProject,

                RecentItemType.TypeScriptProject => KnownMonikers.TSProjectNode,

                RecentItemType.VisualBasicProject => KnownMonikers.VBProjectNode,

                RecentItemType.VisualBasicSharedProject => KnownMonikers.VBSharedProject,

                _ => KnownMonikers.ExclamationPoint
            };
        }
    }
}