using System;
using System.IO;

namespace StartPagePlus.UI.Extensions
{
    using Models;

    using ViewModels;

    using static Enums.PeriodTypes;
    using static Enums.RecentItemTypes;

    public static class RecentItemExtensions
    {
        public static RecentItemViewModel ToViewModel(this RecentItem result, DateTime today, bool hideExtension)
        {
            var path = result.Value.LocalProperties.FullPath;
            var date = result.Value.LastAccessed.Date;
            var name = hideExtension ? Path.GetFileNameWithoutExtension(path) : Path.GetFileName(path);
            var pinned = result.Value.IsFavorite;
            var folder = Path.GetDirectoryName(path);
            var period = CalculatePeriodType(pinned, today, date);
            var type = path.CalculateRecentItemType();
            var moniker = type.ToImageMoniker();

            return new RecentItemViewModel
            {
                Name = name,
                Description = folder,
                Date = date,
                Path = path,
                Pinned = pinned,
                PeriodType = period,
                ItemType = type,
                Moniker = moniker
            };
        }
    }
}