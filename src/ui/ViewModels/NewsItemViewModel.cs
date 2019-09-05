using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace StartPagePlus.UI.ViewModels
{
    public class NewsItemViewModel : ViewModelBase
    {
        public NewsItemViewModel()
            => ActionCommand = new RelayCommand(ExecuteAction, CanExecuteAction);

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public DateTime Date { get; set; }

        public ICommand ActionCommand { get; set; }

        private bool CanExecuteAction()
            => !string.IsNullOrEmpty(Link);

        private void ExecuteAction()
            => MessengerInstance.Send(new NotificationMessage<NewsItemViewModel>(this, Link));
    }
}