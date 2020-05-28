namespace StartPagePlus.Options.Constants
{
    using static Core.Constants.StringConstants;

    public static class PageConstants
    {
        public const string H1 = "1." + Space;
        public const string H2 = "2." + Space;
        public const string H3 = "3." + Space;
        public const string Feature = "Feature";
        public const string Features = "Features";
        public const string FeatureSet = "Feature Set";
        public const string Settings = "Settings";
        public const string Enable = "Enable";
        public const string Enabled = "Enabled";
        public const string EnablesDisables = "Enables/disables";
        public const string EnablesDisablesAll = EnablesDisables + Space + "ALL";

        public const string PackageName = Vsix.Name;
        public const string PackageFeatureSet = PackageName + Space + FeatureSet;

        public const string EnableStartPagePlusOptions = "Start Page+ Options";
        public const string OpenLinksInVS = "Open Links in VS";
        public const string PackageVersion = "Version Number";

        public const string MaxWidthDisplayName = "Max Width";
        public const string MaxWidthDescription = "Sets the max width of contents of the Start Page+ window";

        public const string NewsItemsToDisplayDisplayName = "News Items To Display";
        public const string NewsItemsToDisplayDescription = "Sets the number of items to display in the 'Developer News' list";

        public const string RecentItemsToDisplayDisplayName = "Recent Items To Display";
        public const string RecentItemsToDisplayDescription = "Sets the number of items to display in the 'Recent Items' list";

        public const string ShowRecentItemExtensionsDisplayName = "Show Recent Item Extensions";
        public const string ShowRecentItemExtensionsDescription = "Sets the visibility of a project/solution's extension in the 'Recent Items' list";

        public const string ShowStartTabTitleDisplayName = "Show Start Tab Title";
        public const string ShowStartTabTitleDescription = "Sets the visibility of the title in the 'Start' tab";

        public const string StartTabTitleTextDisplayName = "Start Tab Title Text";
        public const string StartTabTitleTextDescription = "Sets the text of the 'Start' tab title";
    }
}