using System;

namespace StartPagePlus.UI.Models
{
    public class RecentItemValue
    {
        public RecentItemProperties LocalProperties { get; set; }

        public object Remote { get; set; }

        public bool IsFavorite { get; set; }

        public DateTime LastAccessed { get; set; }

        public bool IsLocal { get; set; }

        public bool HasRemote { get; set; }

        public bool IsSourceControlled { get; set; }
    }
}