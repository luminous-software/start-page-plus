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
        public const string PackageVersion = "Version Number";
        public const string OpenLinksInVS = "Open Links in VS";
        public const string MaxWidth = "Max Width";
    }
}