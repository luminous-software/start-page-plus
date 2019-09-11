namespace StartPagePlus.UI.Enums
{
    public class RecentItemTypes
    {
        public static RecentItemType CalculateRecentItemType(string path)
        {
            var type = RecentItemType.Unknown;

            return type;

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

    }
}