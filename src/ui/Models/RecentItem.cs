using System;
using System.IO;
using Microsoft.VisualStudio.Imaging;

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
            var pinned = result.Value.IsFavorite;
            var date = result.Value.LastAccessed.Date;
            var name = Path.GetFileName(path);
            var folder = Path.GetDirectoryName(path);
            var type = CalculateRecentItemType(path);
            var period = CalculatePeriodType(pinned, today, date);

            return new RecentItemViewModel
            {
                Name = name,
                Description = folder,
                Date = date,
                Path = path,
                Pinned = pinned,
                PeriodType = period,
                ItemType = type,
                Moniker = (pinned)
                    ? KnownMonikers.Pin
                    : KnownMonikers.Unpin
            };
        }

    }
}