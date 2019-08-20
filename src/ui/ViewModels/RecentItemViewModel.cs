using System;

namespace StartPagePlus.UI.ViewModels
{
    using Services;

    public class RecentItemViewModel : IRecentItem
    {
        public string Extension { get; set; }

        public string Name { get; set; }

        public string Folder { get; set; }

        public bool Pinned { get; set; }

        public DateTime LastAccessed { get; set; }
    }
}