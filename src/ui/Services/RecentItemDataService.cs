using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Luminous.Code.Extensions.ExceptionExtensions;
using Microsoft.VisualStudio.Imaging;
using Newtonsoft.Json.Linq;
using static Luminous.Code.Dates.DateMethods;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;
    using Interfaces;
    using ViewModels;

    public class RecentItemDataService : IRecentItemDataService
    {
        private const string MRUItems_Projects = "{a9c4a31f-f9cb-47a9-abc0-49ce82d0b3ac}";
        public IDateTimeService DateTimeService { get; }

        public RecentItemDataService(IDateTimeService dateTimeService) => DateTimeService = dateTimeService;


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

                    results.ForEach((result) => items.Add(
                        new RecentItemViewModel
                        {
                            Name = Path.GetFileName(result.Key),
                            Key = Path.GetExtension(result.Key),
                            Description = Path.GetDirectoryName(result.Key),
                            Date = result.Value.LastAccessed,
                            DatePeriod = DatePeriod(result.Value.IsFavorite, result.Value.LastAccessed, DateTimeService.Today),
                            Path = result.Key,
                            Pinned = result.Value.IsFavorite,
                            Moniker = (result.Value.IsFavorite)
                                ? KnownMonikers.Pin
                                : KnownMonikers.Unpin
                        })
                    );
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


        public class RootObject
        {
            public Result[] Results { get; set; }

            public RootObject()
            { }
        }

        public class Result
        {
            public string Key { get; set; }
            public Value Value { get; set; }

            public Result()
            {

            }
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


        //public class LocalProperties
        //{
        //    [JsonProperty("FullPath")]
        //    public string FullPath { get; set; }
        //    public int Type { get; set; }

        //    [JsonProperty("SourceControl")]
        //    public object SourceControl { get; set; }
        //}

        //public class Value
        //{
        //    [JsonProperty("LocalProperties")]
        //    public LocalProperties LocalProperties { get; set; }

        //    [JsonProperty("Remote")]
        //    public object Remote { get; set; }

        //    [JsonProperty("IsFavorite")]
        //    public bool IsFavorite { get; set; }

        //    [JsonProperty("LastAccessed")]
        //    public DateTime LastAccessed { get; set; }

        //    [JsonProperty("IsLocal")]
        //    public bool IsLocal { get; set; }

        //    [JsonProperty("HasRemote")]
        //    public bool HasRemote { get; set; }

        //    [JsonProperty("IsSourceControlled")]
        //    public bool IsSourceControlled { get; set; }
        //}

        //public class RootObject
        //{
        //    [JsonProperty("Key")]
        //    public string Key { get; set; }

        //    [JsonProperty("Value")]
        //    public Value Value { get; set; }
        //}
    }
}