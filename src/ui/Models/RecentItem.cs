using System;
using System.IO;

namespace StartPagePlus.UI.Models
{
    using ViewModels;
    using static Enums.PeriodTypes;
    using static Enums.RecentItemTypes;

    public class RecentItem
    {
        public string Key { get; set; }

        public RecentItemValue Value { get; set; }

        public RecentItem()
        { }

        public static RecentItemViewModel ToViewModel(RecentItem result, DateTime today)
        {
            var path = result.Value.LocalProperties.FullPath;
            var date = result.Value.LastAccessed.Date;
            var name = Path.GetFileName(path);
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