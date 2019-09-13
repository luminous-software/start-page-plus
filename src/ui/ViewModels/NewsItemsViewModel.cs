using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.ViewModels
{
    using Core.Interfaces;
    using GalaSoft.MvvmLight.Messaging;
    using Interfaces;

    public class NewsItemsViewModel : ColumnViewModel
    {
        private const string DEV_NEWS_FEED_URL = "https://vsstartpage.blob.core.windows.net/news/vs";
        private const string HEADING = "Read Developer News";

        private ObservableCollection<NewsItemViewModel> items;

        public NewsItemsViewModel(INewsItemDataService dataService, INewsItemActionService actionService)
        {
            DataService = dataService;
            ActionService = actionService;
            Heading = HEADING;
            ExecuteRefresh();
            Commands = GetCommands();
            IsVisible = true;

            MessengerInstance.Register<NotificationMessage<NewsItemViewModel>>(this,
                (message) => ActionService.DoAction(message.Content));
        }

        public INewsItemDataService DataService { get; }

        public INewsItemActionService ActionService { get; }

        public ObservableCollection<NewsItemViewModel> Items
        {
            get => items;
            set => Set(ref items, value);
        }

        private ObservableCollection<CommandViewModel> GetCommands()
            => new ObservableCollection<CommandViewModel>
            {
                new CommandViewModel
                {
                    Name = "More News",
                    Command = new RelayCommand(ExecuteMoreNews, true)
                },
                new CommandViewModel
                {
                    Name = "Refresh",
                    Command = new RelayCommand(ExecuteRefresh, true)
                }
            };

        private void ExecuteMoreNews()
        { }

        public void ExecuteRefresh()
             => ThreadHelper.JoinableTaskFactory.RunAsync(async ()
                 =>
                 {
                     Items.Clear();

                     return Items = await DataService.GetItemsAsync(DEV_NEWS_FEED_URL);
                 });
    }
}