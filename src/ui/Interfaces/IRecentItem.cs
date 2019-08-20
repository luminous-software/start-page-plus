using System;
using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.Services
{
    public interface IRecentItem
    {
        ImageMoniker Moniker { get; set; }

        string Name { get; set; }

        string Folder { get; set; }

        bool Pinned { get; set; }

        DateTime LastAccessed { get; set; }
    }
}