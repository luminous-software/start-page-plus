using System;

namespace StartPagePlus.Options.Constants
{
    public static class OptionsGuids
    {
        internal const string GeneralDialogPageString = "EF07A240-AF64-4D81-8C4D-2D39666A5FD2";
        internal const string SettingsPageGuidString = "12D2A5ED-3C45-4919-8E31-3F3D68FC0159";

        public static Guid GeneralDialogPage = new Guid(GeneralDialogPageString);
        public static Guid SettingsgPageGuid = new Guid(SettingsPageGuidString);
    }
}