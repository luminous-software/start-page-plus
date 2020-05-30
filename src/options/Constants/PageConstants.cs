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
        public const string Enable = "Enable";
        public const string Enabled = "Enabled";
        public const string EnablesDisables = "Enables/disables";
        public const string EnablesDisablesAll = EnablesDisables + Space + "ALL";

        // package

        public const string PackageName = Vsix.Name;
        public const string PackageFeatureSet = PackageName + Space + FeatureSet;

        // Start Page+

        public const string EnableStartPagePlusDispayName = "Enable '" + PackageName + "'";
        public const string EnableStartPagePlusDescription = "Allows the whole set of '" + PackageName + "' features to be turned off together";

        public const string EnableOptionsMenuItemDispayName = "Enable '" + PackageName + "' Options";
        public const string EnableOptionsMenuItemDescription = "Determines if a button to open the options page is added to the Tools | Options menu";

        public const string PackageVersion = "Version Number";

        public const string MaxWidthDisplayName = "Max Width";
        public const string MaxWidthDescription = "Sets the max width of contents of the Start Page+ window";

        // Start Tab

        public const string ShowStartTabTitleDisplayName = "Show 'Start' Tab Title";
        public const string ShowStartTabTitleDescription = "Sets the visibility of the title in the 'Start' tab";

        public const string StartTabTitleTextDisplayName = "'Start' Tab Title Text";
        public const string StartTabTitleTextDescription = "Sets the text of the 'Start' tab title";

        // Recent Items

        public const string RecentItemsToDisplayDisplayName = "Items To Display";
        public const string RecentItemsToDisplayDescription = "Sets the number of items to display in the 'Recent Items' list";

        public const string ShowFileExtensionsDisplayName = "Show File Extensions";
        public const string ShowFileExtensionsDescription = "Sets the visibility of project/solution extensions in the 'Recent Items' list";

        // Developer News

        public const string NewsItemsFeedUrlDisplayName = "Items Feed Url";
        public const string NewsItemsFeedUrlDescription = "Sets the url of the 'Developer News' feed";

        public const string NewsItemsToDisplayDisplayName = "Items To Display";
        public const string NewsItemsToDisplayDescription = "Sets the number of items to display in the 'Developer News' list";

        public const string OpenLinksInVsDisplayName = "Open Links in VS";
        public const string OpenLinksInVsDescription = "Determines if news links are opened in VS or in the user's default browser";
    }
}