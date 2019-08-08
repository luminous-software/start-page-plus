namespace StartPagePlus.Options.Constants
{
    using static Core.StringConstants;

    public static class PageConstants
    {
        public const string H1 = "1." + Space;
        public const string H2 = "2." + Space;
        public const string Feature = "Feature";
        public const string Features = "Features";
        public const string FeatureSet = "Feature Set";
        public const string Enable = "Enable";
        public const string Enabled = "Enabled";
        public const string EnablesDisables = "Enables/disables";
        public const string EnablesDisablesAll = EnablesDisables + Space + "ALL";

        public const string PackageName = Vsix.Name;
        public const string PackageFeatureSet = PackageName + Space + FeatureSet;
        public const string PackageVersion = "Version Number";
    }
}