using System;
using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.Interfaces
{
    public interface IRecentItem
    {
        string Key { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        DateTime Date { get; set; }

        string Path { get; set; }


        ImageMoniker Moniker { get; set; }

        bool Pinned { get; set; }
    }
}