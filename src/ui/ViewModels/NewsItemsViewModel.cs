using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.ViewModels
{
    using Core.Interfaces;
    using Interfaces;

    public class NewsItemsViewModel : ColumnViewModel
    {
        private const string DEV_NEWS_FEED_URL = "https://vsstartpage.blob.core.windows.net/news/vs";
        private NewsItemViewModel selectedItem;
        private int selectedIndex;

        public NewsItemsViewModel(INewsItemDataService dataService, INewsItemActionService actionService)
        {
            DataService = dataService;
            ActionService = actionService;
            Heading = "Read Developer News";
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
            IsVisible = true;
        }

        public INewsItemDataService DataService { get; }

        public INewsItemActionService ActionService { get; }

        public ObservableCollection<NewsItemViewModel> Items { get; set; }

        public NewsItemViewModel SelectedItem
        {
            get => selectedItem;
            set
            {
                if (value != null)
                {
                    ActionService.DoAction(value);
                }

                Set(ref selectedItem, value);
            }
        }

        public int SelectedIndex
        {
            get => selectedIndex;
            set => Set(ref selectedIndex, value);
        }

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