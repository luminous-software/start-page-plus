using System;

namespace StartPagePlus.UI.Interfaces
{
    public interface INewsItem
    {
        string Title { get; }

        string Description { get; }

        DateTime Date { get; }

        string Link { get; }
    }
}