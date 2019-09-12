using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.Enums
{
    public static class RecentItemTypes
    {
        public static RecentItemType CalculateRecentItemType(string path)
        {
            var type = RecentItemType.Unknown;

            return type;

            //var ext = value.ToString().TrimStart(new char[] { '.' });
            //var type = string.IsNullOrEmpty("")
            //    ? ""
            //    : Path.GetExtension(path).Substring(1);

            //switch (type)
            //{
            //    case "sln":
            //        dte?.Solution.Open(path);
            //        break;

            //    case "csproj":
            //        dte?.Solution.Open(path);
            //        break;

            //    case "":
            //        dte?.ExecuteCommand("File.OpenFolder", folder);
            //        break;

            //    default:
            //        MessageBox.Show($"Unhandled extension:'{ext}'");
            //        break;
            //}
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