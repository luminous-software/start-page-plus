using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Microsoft.Win32;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StartPagePlus.UI.Services
{

    using Core.Interfaces;

    using Extensions;

    using Interfaces;

    using Models;

    using ViewModels;

    public class RecentItemDataService : IRecentItemDataService
    {
        private const string ROOT = "ApplicationPrivateSettings";
        private const string METADATA = "_metadata";
        private const string BASELINES = "baselines";
        private const string CODE_CONTAINERS = "CodeContainers";
        private const string OFFLINE = "Offline";

        private IDateTimeService DateTimeService { get; }

        private IDialogService DialogService { get; }

        private IServiceProvider ServiceProvider { get; }

        public RecentItemDataService(IDateTimeService dateTimeService, IDialogService dialogService, IServiceProvider serviceProvider)
        {
            DateTimeService = dateTimeService;
            DialogService = dialogService;
            ServiceProvider = serviceProvider;
        }

        private string CodeContainersKey
            => $"{ROOT}\\{METADATA}\\{BASELINES}\\{CODE_CONTAINERS}";

        public List<RecentItem> GetRecentItems()
        {
            var items = new List<RecentItem>();

            using (var regKey = MainViewModel.Package.UserRegistryRoot.OpenSubKey(CodeContainersKey))
            {
                try
                {
                    if (regKey is null)
                        return items;

                    var value = ((string)regKey.GetValue(OFFLINE)).Substring(1);
                    if (value is null)
                        return items;

                    items = JArray.Parse(value).ToObject<List<RecentItem>>();
                }
                catch (Exception ex)
                {
                    DialogService.ShowError(ex);
                }
                finally
                {
                    regKey?.Close();
                }

                return items;
            }
        }

        public bool UpdateRecentItems(List<RecentItem> items)
        {
            using (var regKey = MainViewModel.Package.UserRegistryRoot.OpenSubKey(CodeContainersKey, true))
            {
                try
                {
                    if (regKey is null)
                        return false;

                    var recentItems = JsonConvert.SerializeObject(items);
                    var value = $"1{recentItems}";

                    regKey.SetValue(OFFLINE, value, RegistryValueKind.String);
                }
                catch (Exception ex)
                {
                    DialogService.ShowError(ex);
                    return false;
                }
                finally
                {
                    regKey?.Close();
                }

                return true;
            }
        }

        public ObservableCollection<RecentItemViewModel> GetItems(int itemsToDisplay, bool showExtensions)
        {

            var items = new ObservableCollection<RecentItemViewModel>();
            var recentItems = GetRecentItems();

            try
            {
                var today = DateTimeService.Today.Date;

                recentItems
                    .Take(itemsToDisplay)
                    .ToList()
                    .ForEach((recentItem)
                        => items.Add(recentItem.ToViewModel(today, showExtensions)));
            }
            catch (Exception ex)
            {
                DialogService.ShowError(ex);
            }

            return items;
        }

        public bool SetLastAccessed(string path, DateTime date)
        {
            var items = GetRecentItems();
            var item = items.FirstOrDefault(x => x.Key == path);

            item.Value.LastAccessed = date;

            return UpdateRecentItems(items);
        }
    }
}