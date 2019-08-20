using System;

namespace StartPagePlus.UI.Services
{
    public interface IRecentItem
    {
        string Extension { get; set; }

        string Name { get; set; }

        string Folder { get; set; }

        bool Pinned { get; set; }

        DateTime LastAccessed { get; set; }
    }
}