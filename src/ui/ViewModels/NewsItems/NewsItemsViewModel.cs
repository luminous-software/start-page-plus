using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Luminous.Code.VisualStudio.Packages;

namespace StartPagePlus.UI.ViewModels.NewsItems
{
    using Core.Interfaces;
    using Options.Pages;

    public class NewsItemsViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        private readonly IBrowserService browserService;
        private List<NewsItemViewModel> feedItems;
        private NewsItemViewModel selectedItem;
        private int selectedIndex;
        private static GeneralDialogPage generalOptions;

        public static GeneralDialogPage GeneralOptions
            => generalOptions ?? (generalOptions = AsyncPackageBase.GetDialogPage<GeneralDialogPage>());

        public RelayCommand RefreshCommand { get; private set; }

        public RelayCommand<string> ViewMoreCommand { get; private set; }

        public string DisplayName { get; internal set; }

        public string NewName { get; internal set; }

        public List<NewsItemViewModel> FeedItems
        {
            get => feedItems;
            set => Set(ref feedItems, value);
        }

        public NewsItemViewModel SelectedItem
        {
            get => selectedItem;
            set
            {
                Set(ref selectedItem, value);

                if (value != null)
                {
                    browserService.OpenUrl(selectedItem.Link, GeneralOptions.OpenLinksInVS);
                    //SelectedItem = null;
                    SelectedIndex = -1;
                }
            }
        }

        public int SelectedIndex
        {
            get => selectedIndex;
            set => Set(ref selectedIndex, value);
        }

        public string DevNewsUrl { get; internal set; }

        public int Count { get; internal set; }

        public string ViewMore { get; internal set; }

        public string ViewMoreUrl { get; internal set; }

        public NewsItemsViewModel(IDataService dataService, IBrowserService browserService)
        {
            this.dataService = dataService;
            this.browserService = browserService;

            RefreshCommand = new RelayCommand(async () => await ExecuteRefreshAsync().ConfigureAwait(false), CanExecuteRefresh);
            ViewMoreCommand = new RelayCommand<string>((link) => ExecuteViewMore(link), CanExecuteViewMore);
        }

        public bool CanExecuteRefresh => true;

        public async Task ExecuteRefreshAsync()
            => await LoadItemsAsync();

        public bool CanExecuteViewMore => true;

        public void ExecuteViewMore(string link)
            => browserService.OpenUrl(link, GeneralOptions.OpenLinksInVS);

        public async Task LoadItemsAsync()
        {
            var items = await dataService.GetItemsAsync(DevNewsUrl, Count);

            FeedItems =
            (
                from item in items
                select new NewsItemViewModel
                {
                    Title = item.Title,
                    Description = item.Description,
                    Link = item.Link,
                    New = NewName,
                    PublishDate = item.PublishDate
                }
            ).ToList();
        }
    }
}