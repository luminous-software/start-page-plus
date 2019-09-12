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

            switch (ext)
            {
                case "":
                    return RecentItemType.Folder;

                case "sln":
                    return RecentItemType.Solution;

                case "csproj":
                    return RecentItemType.CsProject;

                default:
                    return RecentItemType.Unknown;
            }
        }

        public static ImageMoniker ToImageMoniker(this RecentItemType itemType)
        {
            switch (itemType)
            {
                case RecentItemType.Unknown:
                    return KnownMonikers.QuestionMark;

                case RecentItemType.Folder:
                    return KnownMonikers.FolderOpened;

                case RecentItemType.Solution:
                    return KnownMonikers.Solution;

                case RecentItemType.CsProject:
                    return KnownMonikers.CSProjectNode;

                default:
                    return KnownMonikers.QuestionMark;
            }
        }
    }
}