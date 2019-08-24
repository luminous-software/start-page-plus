using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace StartPagePlus.UI.ViewModels
{
    using Microsoft.VisualStudio.Shell;
    using Services;

    public class NewsItemsViewModel : ColumnViewModel
    {
        private const string DEV_NEWS_FEED_URL = "https://vsstartpage.blob.core.windows.net/news/vs";

        public NewsItemsViewModel(INewsItemDataService dataService)
        {
            DataService = dataService;
            Heading = "Read Developer News";
            IsVisible = true;
            Commands = new ObservableCollection<CommandViewModel>
            {
                new CommandViewModel
                {
                    Name = "View More News",
                    Command = new RelayCommand(ExecuteMoreNews, CanExecuteMoreNews)
                },
                new CommandViewModel
                {
                    Name = "Refresh",
                    Command = new RelayCommand(ExecuteRefresh, CanExecuteRefresh)
                }
            };
        }

        public ObservableCollection<NewsItemViewModel> Items { get; set; }

        public INewsItemDataService DataService { get; }

        private bool CanExecuteMoreNews
            => true;

        public void ExecuteMoreNews()
        { }

        private bool CanExecuteRefresh
            => true;

        public void ExecuteRefresh()
            => ThreadHelper.JoinableTaskFactory.RunAsync(async delegate
            {
                Items = await DataService.GetItemsAsync(DEV_NEWS_FEED_URL);
            });
    }
}