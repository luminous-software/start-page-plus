using System;

namespace StartPagePlus.Options.Constants
{
    public static class OptionsGuids
    {
        internal const string GeneralPageGuidString = "EF07A240-AF64-4D81-8C4D-2D39666A5FD2";
        internal const string StartTabPageGuidString = "3970502D-9F22-4D20-B92C-9F3616AA13CA";
        internal const string RecentItemsPageGuidString = "4ED8D76B-C6C4-4F69-A662-44D230CECC39";
        internal const string NewsItemsPageGuidString = "4681A0C2-2D30-41BD-A708-2E7B85191C60";

        public static Guid GeneralPageGuid = new Guid(GeneralPageGuidString);
        public static Guid StartTabPageGuid = new Guid(StartTabPageGuidString);
        public static Guid RecentItemsPageGuid = new Guid(RecentItemsPageGuidString);
        public static Guid NewsItemsPageGuid = new Guid(NewsItemsPageGuidString);
    }
}