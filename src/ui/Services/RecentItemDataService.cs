using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

using Luminous.Code.Extensions.ExceptionExtensions;

using Newtonsoft.Json.Linq;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

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

        public IDateTimeService DateTimeService { get; }

        public RecentItemDataService(IDateTimeService dateTimeService)
            => DateTimeService = dateTimeService;


        public ObservableCollection<RecentItemViewModel> GetItems()
        {

            var items = new ObservableCollection<RecentItemViewModel>();

            try
            {
                var subKey = $"{ROOT}\\{METADATA}\\{BASELINES}\\{CODE_CONTAINERS}";
                using (var regKey = MainViewModel.RegistryRoot.OpenSubKey(subKey))
                {
                    try
                    {
                        if (regKey is null)
                            return items;

                        var offline = ((string)regKey.GetValue(OFFLINE)).Substring(1);
                        if (offline is null)
                            return items;

                        var results = JArray.Parse(offline).ToObject<List<RecentItem>>();
                        var today = DateTimeService.Today.Date;

                        results.ForEach((result)
                            => items.Add(RecentItem.ToViewModel(result, today)));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ExtendedMessage());
                        return items;
                    }
                    finally
                    {
                        regKey?.Close();
                    }
                }
                return items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ExtendedMessage());
                return items;
            }
        }
    }
}