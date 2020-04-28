using System;

namespace StartPagePlus.Options.Constants
{
    public static class OptionsGuids
    {
        internal const string GeneralPageGuidString = "EF07A240-AF64-4D81-8C4D-2D39666A5FD2";
        internal const string SettingPageGuidString = "12D2A5ED-3C45-4919-8E31-3F3D68FC0159";
        internal const string FeaturePageGuidString = "1AED709B-1F19-4EC3-A01E-72199B8F5DA5";

        public static Guid GeneralPageGuid = new Guid(GeneralPageGuidString);
        public static Guid SettingPageGuid = new Guid(SettingPageGuidString);
        public static Guid FeaturePageGuid = new Guid(FeaturePageGuidString);
    }
}