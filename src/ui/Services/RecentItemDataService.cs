using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Luminous.Code.Extensions.ExceptionExtensions;
using Microsoft.VisualStudio.Imaging;
using Newtonsoft.Json.Linq;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;
    using Interfaces;
    using ViewModels;
    using static DatePeriods.Methods.DatePeriodMethods;

    public class RecentItemDataService : IRecentItemDataService
    {
        public IDateTimeService DateTimeService { get; }

        public RecentItemDataService(IDateTimeService dateTimeService)
            => DateTimeService = dateTimeService;


        public ObservableCollection<RecentItemViewModel> GetItems()
        {

            var items = new ObservableCollection<RecentItemViewModel>();

            using (var regKey = MainViewModel.RegistryRoot
                .OpenSubKey("ApplicationPrivateSettings")
                .OpenSubKey("_metadata")
                .OpenSubKey("baselines")
                .OpenSubKey("CodeContainers")
                )
            {
                try
                {
                    if (regKey == null)
                    {
                        return items;
                    }
                    var offline = ((string)regKey.GetValue("Offline")).Substring(1);
                    var results = JArray.Parse(offline).ToObject<List<Result>>();

                    results.ForEach((result) =>
                    {
                        var path = result.Key;
                        var pinned = result.Value.IsFavorite;
                        var date = result.Value.LastAccessed;

                        items.Add(
                            new RecentItemViewModel
                            {
                                Name = Path.GetFileName(path),
                                Key = Path.GetExtension(path),
                                Description = Path.GetDirectoryName(path),
                                Date = date,
                                DatePeriod = CalculateDatePeriod(pinned, DateTimeService.Today, date),
                                Path = path,
                                Pinned = pinned,
                                Moniker = (pinned)
                                    ? KnownMonikers.Pin
                                    : KnownMonikers.Unpin
                            }
                        );
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ExtendedMessage());
                }
                finally
                {
                    regKey?.Close();
                }
            }

            return items;
        }


        public class Result
        {
            public string Key { get; set; }

            public Value Value { get; set; }

            public Result()
            { }
        }

        public class Value
        {
            public Localproperties LocalProperties { get; set; }
            public object Remote { get; set; }
            public bool IsFavorite { get; set; }
            public DateTime LastAccessed { get; set; }
            public bool IsLocal { get; set; }
            public bool HasRemote { get; set; }
            public bool IsSourceControlled { get; set; }
        }

        public class Localproperties
        {
            public string FullPath { get; set; }
            public int Type { get; set; }
            public object SourceControl { get; set; }
        }
    }
}